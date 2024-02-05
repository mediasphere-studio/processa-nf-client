namespace processa_nf_ui
{
    partial class EditContaEmailForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            txtCabecalhoAutorizacao = new TextBox();
            lblCabecalhoAutorizacao = new Label();
            txtEnderecoAPI = new TextBox();
            lblEnderecoAPI = new Label();
            btnTestar = new Button();
            btnSalvar = new Button();
            txtSenha = new TextBox();
            txtUsuario = new TextBox();
            txtPorta = new TextBox();
            txtServidor = new TextBox();
            rbIMAP = new RadioButton();
            rbPop3 = new RadioButton();
            lblSenha = new Label();
            lblUsuario = new Label();
            lblPorta = new Label();
            lblServidor = new Label();
            lblTipoConta = new Label();
            btnCancelar = new Button();
            errProvider = new ErrorProvider(components);
            ckRequerSsl = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)errProvider).BeginInit();
            SuspendLayout();
            // 
            // txtCabecalhoAutorizacao
            // 
            txtCabecalhoAutorizacao.Location = new Point(171, 178);
            txtCabecalhoAutorizacao.Name = "txtCabecalhoAutorizacao";
            txtCabecalhoAutorizacao.Size = new Size(337, 23);
            txtCabecalhoAutorizacao.TabIndex = 7;
            txtCabecalhoAutorizacao.TextChanged += txt_TextChanged;
            // 
            // lblCabecalhoAutorizacao
            // 
            lblCabecalhoAutorizacao.AutoSize = true;
            lblCabecalhoAutorizacao.Location = new Point(21, 181);
            lblCabecalhoAutorizacao.Name = "lblCabecalhoAutorizacao";
            lblCabecalhoAutorizacao.Size = new Size(148, 15);
            lblCabecalhoAutorizacao.TabIndex = 35;
            lblCabecalhoAutorizacao.Text = "Cabecalho de Autorização:";
            // 
            // txtEnderecoAPI
            // 
            txtEnderecoAPI.Location = new Point(107, 147);
            txtEnderecoAPI.Name = "txtEnderecoAPI";
            txtEnderecoAPI.Size = new Size(401, 23);
            txtEnderecoAPI.TabIndex = 6;
            txtEnderecoAPI.TextChanged += txt_TextChanged;
            // 
            // lblEnderecoAPI
            // 
            lblEnderecoAPI.AutoSize = true;
            lblEnderecoAPI.Location = new Point(21, 150);
            lblEnderecoAPI.Name = "lblEnderecoAPI";
            lblEnderecoAPI.Size = new Size(80, 15);
            lblEnderecoAPI.TabIndex = 34;
            lblEnderecoAPI.Text = "Endereço API:";
            // 
            // btnTestar
            // 
            btnTestar.Location = new Point(355, 96);
            btnTestar.Name = "btnTestar";
            btnTestar.Size = new Size(84, 23);
            btnTestar.TabIndex = 5;
            btnTestar.Text = "Testar";
            btnTestar.UseVisualStyleBackColor = true;
            btnTestar.Click += btnTestar_Click;
            // 
            // btnSalvar
            // 
            btnSalvar.Location = new Point(335, 213);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(84, 23);
            btnSalvar.TabIndex = 8;
            btnSalvar.Text = "Salvar";
            btnSalvar.UseVisualStyleBackColor = true;
            btnSalvar.Click += btnSalvar_Click;
            // 
            // txtSenha
            // 
            txtSenha.Location = new Point(80, 112);
            txtSenha.Name = "txtSenha";
            txtSenha.Size = new Size(145, 23);
            txtSenha.TabIndex = 4;
            txtSenha.UseSystemPasswordChar = true;
            txtSenha.TextChanged += txt_TextChanged;
            // 
            // txtUsuario
            // 
            txtUsuario.Location = new Point(80, 77);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(198, 23);
            txtUsuario.TabIndex = 3;
            txtUsuario.TextChanged += txt_TextChanged;
            // 
            // txtPorta
            // 
            txtPorta.Location = new Point(337, 43);
            txtPorta.Name = "txtPorta";
            txtPorta.Size = new Size(72, 23);
            txtPorta.TabIndex = 1;
            txtPorta.TextChanged += txt_TextChanged;
            // 
            // txtServidor
            // 
            txtServidor.Location = new Point(80, 43);
            txtServidor.Name = "txtServidor";
            txtServidor.Size = new Size(198, 23);
            txtServidor.TabIndex = 0;
            txtServidor.TextChanged += txt_TextChanged;
            // 
            // rbIMAP
            // 
            rbIMAP.AutoSize = true;
            rbIMAP.Checked = true;
            rbIMAP.Location = new Point(108, 16);
            rbIMAP.Name = "rbIMAP";
            rbIMAP.Size = new Size(54, 19);
            rbIMAP.TabIndex = 10;
            rbIMAP.TabStop = true;
            rbIMAP.Text = "IMAP";
            rbIMAP.UseVisualStyleBackColor = true;
            rbIMAP.CheckedChanged += rb_CheckedChanged;
            // 
            // rbPop3
            // 
            rbPop3.AutoSize = true;
            rbPop3.Location = new Point(163, 16);
            rbPop3.Name = "rbPop3";
            rbPop3.Size = new Size(54, 19);
            rbPop3.TabIndex = 11;
            rbPop3.Text = "POP3";
            rbPop3.UseVisualStyleBackColor = true;
            rbPop3.CheckedChanged += rb_CheckedChanged;
            // 
            // lblSenha
            // 
            lblSenha.AutoSize = true;
            lblSenha.Location = new Point(21, 115);
            lblSenha.Name = "lblSenha";
            lblSenha.Size = new Size(42, 15);
            lblSenha.TabIndex = 25;
            lblSenha.Text = "Senha:";
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Location = new Point(21, 80);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(50, 15);
            lblUsuario.TabIndex = 23;
            lblUsuario.Text = "Usuário:";
            // 
            // lblPorta
            // 
            lblPorta.AutoSize = true;
            lblPorta.Location = new Point(293, 46);
            lblPorta.Name = "lblPorta";
            lblPorta.Size = new Size(38, 15);
            lblPorta.TabIndex = 21;
            lblPorta.Text = "Porta:";
            // 
            // lblServidor
            // 
            lblServidor.AutoSize = true;
            lblServidor.Location = new Point(21, 46);
            lblServidor.Name = "lblServidor";
            lblServidor.Size = new Size(53, 15);
            lblServidor.TabIndex = 20;
            lblServidor.Text = "Servidor:";
            // 
            // lblTipoConta
            // 
            lblTipoConta.AutoSize = true;
            lblTipoConta.Location = new Point(21, 17);
            lblTipoConta.Name = "lblTipoConta";
            lblTipoConta.Size = new Size(84, 15);
            lblTipoConta.TabIndex = 19;
            lblTipoConta.Text = "Tipo de Conta:";
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(425, 213);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(84, 23);
            btnCancelar.TabIndex = 9;
            btnCancelar.TabStop = false;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // errProvider
            // 
            errProvider.ContainerControl = this;
            // 
            // ckRequerSsl
            // 
            ckRequerSsl.AutoSize = true;
            ckRequerSsl.Checked = true;
            ckRequerSsl.CheckState = CheckState.Checked;
            ckRequerSsl.Location = new Point(424, 45);
            ckRequerSsl.Name = "ckRequerSsl";
            ckRequerSsl.Size = new Size(84, 19);
            ckRequerSsl.TabIndex = 2;
            ckRequerSsl.Text = "Requer SSL";
            ckRequerSsl.UseVisualStyleBackColor = true;
            // 
            // EditContaEmailForm
            // 
            AcceptButton = btnSalvar;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancelar;
            ClientSize = new Size(524, 246);
            ControlBox = false;
            Controls.Add(ckRequerSsl);
            Controls.Add(btnCancelar);
            Controls.Add(txtCabecalhoAutorizacao);
            Controls.Add(lblCabecalhoAutorizacao);
            Controls.Add(txtEnderecoAPI);
            Controls.Add(lblEnderecoAPI);
            Controls.Add(btnTestar);
            Controls.Add(btnSalvar);
            Controls.Add(txtSenha);
            Controls.Add(txtUsuario);
            Controls.Add(txtPorta);
            Controls.Add(txtServidor);
            Controls.Add(rbIMAP);
            Controls.Add(rbPop3);
            Controls.Add(lblSenha);
            Controls.Add(lblUsuario);
            Controls.Add(lblPorta);
            Controls.Add(lblServidor);
            Controls.Add(lblTipoConta);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "EditContaEmailForm";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Editar Informações da Conta...";
            FormClosing += EditContaEmailForm_FormClosing;
            Load += EditContaEmailForm_Load;
            ((System.ComponentModel.ISupportInitialize)errProvider).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtCabecalhoAutorizacao;
        private Label lblCabecalhoAutorizacao;
        private TextBox txtEnderecoAPI;
        private Label lblEnderecoAPI;
        private Button btnTestar;
        private Button btnSalvar;
        private TextBox txtSenha;
        private TextBox txtUsuario;
        private TextBox txtPorta;
        private TextBox txtServidor;
        private RadioButton rbIMAP;
        private RadioButton rbPop3;
        private Label lblSenha;
        private Label lblUsuario;
        private Label lblPorta;
        private Label lblServidor;
        private Label lblTipoConta;
        private Button btnCancelar;
        private ErrorProvider errProvider;
        private CheckBox ckRequerSsl;
    }
}