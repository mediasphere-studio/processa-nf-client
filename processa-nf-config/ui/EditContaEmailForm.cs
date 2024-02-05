using System.Net;

using MailKit;
using MailKit.Net.Imap;
using MailKit.Net.Pop3;

using processa_nf_infra.domain;

namespace processa_nf_ui
{
    public partial class EditContaEmailForm : Form
    {
        public ContaEmail ContaEmEdicao { get; set; } = new();

        private bool modificacoesPendentes = false;
        private bool contaValidada = true;

        public EditContaEmailForm()
        {
            InitializeComponent();
        }

        private void EditContaEmailForm_Load(object sender, EventArgs e)
        {
            if (ContaEmEdicao.TipoConta == TipoContaEnum.POP3)
                rbPop3.Checked = true;
            else
                rbIMAP.Checked = true;

            txtServidor.Text = ContaEmEdicao.Servidor;
            txtUsuario.Text = ContaEmEdicao.Usuario;
            txtPorta.Text = ContaEmEdicao.Porta;
            ckRequerSsl.Checked = ContaEmEdicao.RequerSsl;
            txtUsuario.Text = ContaEmEdicao.Usuario;
            txtSenha.Text = ContaEmEdicao.Senha;
            txtEnderecoAPI.Text = ContaEmEdicao.EnderecoAPI;
            txtCabecalhoAutorizacao.Text = ContaEmEdicao.CabecalhoAutorizacao;

            this.modificacoesPendentes = false;
            this.contaValidada = true;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            // Validar campos, verificar se o email foi validado. 
            if (!this.modificacoesPendentes)
            {
                MessageBox.Show("Nenhuma modificação", "Config", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (!ValidarFormulario())
                return;

            if (!contaValidada)
            {
                MessageBox.Show("Antes de salvar é preciso testar a conexão à conta", "Config", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            if (rbPop3.Checked)
                ContaEmEdicao.TipoConta = TipoContaEnum.POP3;
            else
                ContaEmEdicao.TipoConta = TipoContaEnum.IMAP;

            ContaEmEdicao.Servidor = txtServidor.Text.Trim();
            ContaEmEdicao.Usuario = txtUsuario.Text.Trim();
            ContaEmEdicao.Porta = txtPorta.Text.Trim();
            ContaEmEdicao.RequerSsl = ckRequerSsl.Checked;
            ContaEmEdicao.Usuario = txtUsuario.Text.Trim();
            ContaEmEdicao.Senha = txtSenha.Text.Trim();
            ContaEmEdicao.EnderecoAPI = txtEnderecoAPI.Text.Trim();
            ContaEmEdicao.CabecalhoAutorizacao = txtCabecalhoAutorizacao.Text.Trim();

            this.DialogResult = DialogResult.OK;
            this.modificacoesPendentes = false;
            this.Close();
        }

        private void btnTestar_Click(object sender, EventArgs e)
        {
            if (!ValidarFormulario())
                return;

            try
            {
                this.Cursor = Cursors.WaitCursor;

                IMailService client = rbIMAP.Checked ? new ImapClient() : new Pop3Client();

                client.Connect(txtServidor.Text.Trim(), Convert.ToInt32(txtPorta.Text.Trim()), ckRequerSsl.Checked);
                client.Authenticate(txtUsuario.Text.Trim(), txtSenha.Text.Trim());

                this.contaValidada = client.IsConnected && client.IsAuthenticated;

                client.Disconnect(true);

                this.Cursor = Cursors.Default;

                MessageBox.Show("Acesso à conta efetuado com sucesso", "Config", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                this.contaValidada = false;
                this.Cursor = Cursors.Default;

                MessageBox.Show("Erro na tentativa de testar o acesso à conta: " + ex.Message, "Config", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void EditContaEmailForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.modificacoesPendentes)
            {
                if (MessageBox.Show("Existem alterações pendentes deseja fechar assim mesmo?", "Config", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                {
                    e.Cancel = true;
                }
            }
        }

        private void txt_TextChanged(object sender, EventArgs e)
        {
            this.modificacoesPendentes = true;
            this.contaValidada = false;
        }

        private void rb_CheckedChanged(object sender, EventArgs e)
        {
            this.modificacoesPendentes = true;
            this.contaValidada = false;
        }

        private void LimparErros()
        {
            errProvider.Clear();
            foreach (Control control in this.Controls)
            {
                if (control is TextBox)
                    control.BackColor = Color.White;
            }
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

            if (txtServidor.Text.Trim().Length == 0 || !ValidarCampoServidor(txtServidor.Text.Trim()))
            {
                this.ApontarErro(txtServidor, "Conteúdo não é um endereço válido");
                returnValue = false;
            }

            int porta;
            if (txtPorta.Text.Trim().Length == 0 || !int.TryParse(txtPorta.Text, out porta) || (porta < 0 || porta > 65535))
            {
                this.ApontarErro(txtPorta, "Conteúdo não é um número de porta válido. Intervalo válido: 0 a 65535");
                returnValue = false;
            }

            if (txtUsuario.Text.Trim().Length == 0)
            {
                this.ApontarErro(txtUsuario, "Conteúdo não é um nome de usuário válido");
                returnValue = false;
            }

            if (txtSenha.Text.Trim().Length == 0)
            {
                this.ApontarErro(txtSenha, "Conteúdo não é uma senha válida");
                returnValue = false;
            }

            //if (txtEnderecoAPI.Text.Trim().Length == 0)
            //{
            //    this.ApontarErro(txtEnderecoAPI, "Conteúdo não é um endereço de API válido");
            //    returnValue = false;
            //}

            //if (txtCabecalhoAutorizacao.Text.Trim().Length == 0)
            //{
            //    this.ApontarErro(txtCabecalhoAutorizacao, "Conteúdo não é um cabeçalho de autorização válido");
            //    returnValue = false;
            //}

            return returnValue;
        }

        private static bool ValidarCampoServidor(string enderecoServidor)
        {
            if (IsDomainValid(enderecoServidor))
            {
                return true;
            }
            else if (IsIPAddressValid(enderecoServidor))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static bool IsDomainValid(string input)
        {
            // Expressão regular para validar um nome de domínio
            string pattern = @"^[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            return System.Text.RegularExpressions.Regex.IsMatch(input, pattern);
        }

        private static bool IsIPAddressValid(string input)
        {
            IPAddress ipAddress;
            return IPAddress.TryParse(input, out ipAddress);
        }

    }
}
