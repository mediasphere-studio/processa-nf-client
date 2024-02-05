using processa_nf_infra.domain;
using processa_nf_infra.repository;

namespace processa_nf_service
{
    public class WindowsBackgroundService : BackgroundService
    {
        private readonly ProcessaNfService _processaNfService;
        private readonly ILogger<WindowsBackgroundService> _logger;
        private readonly Configuracao _config;

        public WindowsBackgroundService(ProcessaNfService processaNfService, ILogger<WindowsBackgroundService> logger)
        {
            _processaNfService = processaNfService;
            _logger = logger;
            _config = ConfiguracaoRepository.Get();
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            try
            {
                while (!stoppingToken.IsCancellationRequested)
                {
                    await _processaNfService.Execute();
                    await Task.Delay(TimeSpan.FromMinutes(_config.IntervaloRastreamento), stoppingToken);
                }
            }
            catch (TaskCanceledException)
            {
                // When the stopping token is canceled, for example, a call made from services.msc,
                // we shouldn't exit with a non-zero exit code. In other words, this is expected...
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Message}", ex.Message);

                // Terminates this process and returns an exit code to the operating system.
                // This is required to avoid the 'BackgroundServiceExceptionBehavior', which
                // performs one of two scenarios:
                // 1. When set to "Ignore": will do nothing at all, errors cause zombie services.
                // 2. When set to "StopHost": will cleanly stop the host, and log errors.
                //
                // In order for the Windows Service Management system to leverage configured
                // recovery options, we need to terminate the process with a non-zero exit code.
                Environment.Exit(1);
            }
        }
    }
}