using System.ComponentModel;
using System.Windows.Forms;
using processa_nf_infra.domain;
using processa_nf_infra.repository;

namespace processa_nf_ui
{
    public partial class ConfigForm : Form
    {
        private readonly BindingList<ContaEmail> contasEmail;
        private readonly Configuracao config;

        private bool modificacoesPendentes = false;

        public ConfigForm()
        {
            InitializeComponent();
            contasEmail = new(ContaEmailRepository.List());
            config = ConfiguracaoRepository.Get();
        }

        private void ConfigForm_Load(object sender, EventArgs e)
        {
            grdContas.DataSource = contasEmail;
            grdContas.Columns["Senha"].Visible = false;

            AjustaStatusBotoes();

            txtIntervaloRastreamento.Text = config.IntervaloRastreamento.ToString();
            txtDiretorioTemporario.Text = config.DiretorioTemporario;

            modificacoesPendentes = false;
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            EditContaEmailForm form = new()
            {
                ContaEmEdicao = new()
            };
            form.ShowDialog();

            if (form.DialogResult == DialogResult.OK)
            {
                contasEmail.Add(form.ContaEmEdicao);
                AjustaStatusBotoes();

                modificacoesPendentes = true;
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            this.EditarContaSelecionada();
        }

        private void grdContas_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.EditarContaSelecionada();
        }

        private void EditarContaSelecionada()
        {
            if (grdContas.CurrentRow.DataBoundItem is ContaEmail contaSelecionada)
            {
                EditContaEmailForm form = new()
                {
                    ContaEmEdicao = contaSelecionada.Clone()
                };
                form.ShowDialog();

                if (form.DialogResult == DialogResult.OK)
                {
                    contaSelecionada.CopyFrom(form.ContaEmEdicao);
                    grdContas.Refresh();

                    modificacoesPendentes = true;
                }
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (grdContas.CurrentRow.DataBoundItem is ContaEmail contaSelecionada &&
                MessageBox.Show($"Confirma e exclusão da conta {contaSelecionada.Servidor}@{contaSelecionada.Usuario}?", "Config", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                contasEmail.Remove(contaSelecionada);
                AjustaStatusBotoes();

                modificacoesPendentes = true;
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (!ValidarFormulario())
                return;

            ContaEmailRepository.Save(contasEmail.ToList());

            config.IntervaloRastreamento = Convert.ToInt32(txtIntervaloRastreamento.Text);
            config.DiretorioTemporario = txtDiretorioTemporario.Text;

            ConfiguracaoRepository.Save(config);

            modificacoesPendentes = false;

            MessageBox.Show("Alterações salvas com sucesso", "Config", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void AjustaStatusBotoes()
        {
            btnEditar.Enabled = contasEmail.Count > 0;
            btnExcluir.Enabled = contasEmail.Count > 0;
        }

        private void ConfigForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.modificacoesPendentes)
            {
                if (MessageBox.Show("Existem alterações pendentes deseja fechar assim mesmo?", "Config", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                {
                    e.Cancel = true;
                }
            }
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txt_TextChanged(object sender, EventArgs e)
        {
            this.modificacoesPendentes = true;
        }

        private void LimparErros()
        {
            errProvider.Clear();
            foreach (Control control in new Control[] { txtIntervaloRastreamento, txtDiretorioTemporario })
                control.BackColor = Color.White;
        }

        private void ApontarErro(Control control, string mensagem)
        {
            errProvider.SetError(control, mensagem);
            control.BackColor = Color.OrangeRed;
        }

        private bool ValidarFormulario()
        {
            bool returnValue = true;
            LimparErros();

            int intervalo;
            if (txtIntervaloRastreamento.Text.Trim().Length == 0 || !int.TryParse(txtIntervaloRastreamento.Text, out intervalo) || intervalo <= 0 || intervalo > 60)
            {
                this.ApontarErro(txtIntervaloRastreamento, "Conteúdo não é um intervalo válido. Informe o tempo em minutos [entre 1 e 60 minutos]");
                returnValue = false;
            }

            if (txtDiretorioTemporario.Text.Trim().Length == 0 || !Directory.Exists(txtDiretorioTemporario.Text.Trim()))
            {
                this.ApontarErro(txtDiretorioTemporario, "Conteúdo informado não é um caminho válido");
                returnValue = false;
            }
            return returnValue;
        }

        private void btnSelecionarDiretorioTemporario_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new()
            {
                Description = "Selecione um diretório para arquivos temporários e de log...",
                SelectedPath = txtDiretorioTemporario.Text
            };

            DialogResult result = dialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                txtDiretorioTemporario.Text = dialog.SelectedPath;
            }
        }
    }
}
