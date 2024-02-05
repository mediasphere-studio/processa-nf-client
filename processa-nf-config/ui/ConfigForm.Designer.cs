namespace processa_nf_ui
{
    partial class ConfigForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigForm));
            gpoEmails = new GroupBox();
            btnEditar = new Button();
            grdContas = new DataGridView();
            btnExcluir = new Button();
            btnIncluir = new Button();
            btnFechar = new Button();
            gpoOpcoes = new GroupBox();
            btnSelecionarDiretorioTemporario = new Button();
            txtDiretorioTemporario = new TextBox();
            label1 = new Label();
            txtIntervaloRastreamento = new TextBox();
            lblIntervalo = new Label();
            btnSalvar = new Button();
            errProvider = new ErrorProvider(components);
            gpoEmails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)grdContas).BeginInit();
            gpoOpcoes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errProvider).BeginInit();
            SuspendLayout();
            // 
            // gpoEmails
            // 
            gpoEmails.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gpoEmails.Controls.Add(btnEditar);
            gpoEmails.Controls.Add(grdContas);
            gpoEmails.Controls.Add(btnExcluir);
            gpoEmails.Controls.Add(btnIncluir);
            gpoEmails.Location = new Point(8, 5);
            gpoEmails.Name = "gpoEmails";
            gpoEmails.Size = new Size(750, 261);
            gpoEmails.TabIndex = 0;
            gpoEmails.TabStop = false;
            gpoEmails.Text = "Contas Configuradas para Rastreamento:";
            // 
            // btnEditar
            // 
            btnEditar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnEditar.Location = new Point(89, 226);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(76, 23);
            btnEditar.TabIndex = 2;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = true;
            btnEditar.Click += btnEditar_Click;
            // 
            // grdContas
            // 
            grdContas.AllowUserToAddRows = false;
            grdContas.AllowUserToDeleteRows = false;
            grdContas.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            grdContas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grdContas.Location = new Point(10, 22);
            grdContas.Name = "grdContas";
            grdContas.ReadOnly = true;
            grdContas.RowHeadersVisible = false;
            grdContas.RowTemplate.Height = 25;
            grdContas.Size = new Size(720, 192);
            grdContas.TabIndex = 0;
            grdContas.MouseDoubleClick += grdContas_MouseDoubleClick;
            // 
            // btnExcluir
            // 
            btnExcluir.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnExcluir.Location = new Point(169, 226);
            btnExcluir.Name = "btnExcluir";
            btnExcluir.Size = new Size(76, 23);
            btnExcluir.TabIndex = 3;
            btnExcluir.Text = "Excluir";
            btnExcluir.UseVisualStyleBackColor = true;
            btnExcluir.Click += btnExcluir_Click;
            // 
            // btnIncluir
            // 
            btnIncluir.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnIncluir.Location = new Point(10, 226);
            btnIncluir.Name = "btnIncluir";
            btnIncluir.Size = new Size(76, 23);
            btnIncluir.TabIndex = 1;
            btnIncluir.Text = "Incluir";
            btnIncluir.UseVisualStyleBackColor = true;
            btnIncluir.Click += btnIncluir_Click;
            // 
            // btnFechar
            // 
            btnFechar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnFechar.Location = new Point(687, 413);
            btnFechar.Name = "btnFechar";
            btnFechar.Size = new Size(74, 23);
            btnFechar.TabIndex = 8;
            btnFechar.Text = "Fechar";
            btnFechar.UseVisualStyleBackColor = true;
            btnFechar.Click += btnFechar_Click;
            // 
            // gpoOpcoes
            // 
            gpoOpcoes.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gpoOpcoes.Controls.Add(btnSelecionarDiretorioTemporario);
            gpoOpcoes.Controls.Add(txtDiretorioTemporario);
            gpoOpcoes.Controls.Add(label1);
            gpoOpcoes.Controls.Add(txtIntervaloRastreamento);
            gpoOpcoes.Controls.Add(lblIntervalo);
            gpoOpcoes.Location = new Point(8, 272);
            gpoOpcoes.Name = "gpoOpcoes";
            gpoOpcoes.Size = new Size(750, 135);
            gpoOpcoes.TabIndex = 15;
            gpoOpcoes.TabStop = false;
            gpoOpcoes.Text = "Outras Configurações:";
            // 
            // btnSelecionarDiretorioTemporario
            // 
            btnSelecionarDiretorioTemporario.Location = new Point(463, 71);
            btnSelecionarDiretorioTemporario.Name = "btnSelecionarDiretorioTemporario";
            btnSelecionarDiretorioTemporario.Size = new Size(91, 23);
            btnSelecionarDiretorioTemporario.TabIndex = 18;
            btnSelecionarDiretorioTemporario.Text = "Selecionar...";
            btnSelecionarDiretorioTemporario.UseVisualStyleBackColor = true;
            btnSelecionarDiretorioTemporario.Click += btnSelecionarDiretorioTemporario_Click;
            // 
            // txtDiretorioTemporario
            // 
            txtDiretorioTemporario.BackColor = Color.White;
            txtDiretorioTemporario.Location = new Point(21, 70);
            txtDiretorioTemporario.Name = "txtDiretorioTemporario";
            txtDiretorioTemporario.ReadOnly = true;
            txtDiretorioTemporario.Size = new Size(436, 23);
            txtDiretorioTemporario.TabIndex = 17;
            txtDiretorioTemporario.Text = "c:\\temp\\";
            txtDiretorioTemporario.TextChanged += txt_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(10, 52);
            label1.Name = "label1";
            label1.Size = new Size(267, 15);
            label1.TabIndex = 19;
            label1.Text = "Caminho para gravação de arquivos temporários:";
            // 
            // txtIntervaloRastreamento
            // 
            txtIntervaloRastreamento.Location = new Point(220, 20);
            txtIntervaloRastreamento.Name = "txtIntervaloRastreamento";
            txtIntervaloRastreamento.Size = new Size(33, 23);
            txtIntervaloRastreamento.TabIndex = 4;
            txtIntervaloRastreamento.Text = "10";
            txtIntervaloRastreamento.TextChanged += txt_TextChanged;
            // 
            // lblIntervalo
            // 
            lblIntervalo.AutoSize = true;
            lblIntervalo.Location = new Point(10, 23);
            lblIntervalo.Name = "lblIntervalo";
            lblIntervalo.Size = new Size(296, 15);
            lblIntervalo.TabIndex = 5;
            lblIntervalo.Text = "Rastrear as contas configuradas a cada             minutos.";
            // 
            // btnSalvar
            // 
            btnSalvar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSalvar.Location = new Point(597, 413);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(84, 23);
            btnSalvar.TabIndex = 7;
            btnSalvar.Text = "Salvar";
            btnSalvar.UseVisualStyleBackColor = true;
            btnSalvar.Click += btnSalvar_Click;
            // 
            // errProvider
            // 
            errProvider.ContainerControl = this;
            // 
            // ConfigForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnFechar;
            ClientSize = new Size(770, 443);
            Controls.Add(btnSalvar);
            Controls.Add(gpoOpcoes);
            Controls.Add(btnFechar);
            Controls.Add(gpoEmails);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "ConfigForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Processamento de NFs - Configuração";
            FormClosing += ConfigForm_FormClosing;
            Load += ConfigForm_Load;
            gpoEmails.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)grdContas).EndInit();
            gpoOpcoes.ResumeLayout(false);
            gpoOpcoes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)errProvider).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox gpoEmails;
        private Button btnExcluir;
        private Button btnIncluir;
        private Button btnFechar;
        private GroupBox gpoOpcoes;
        private TextBox txtIntervaloRastreamento;
        private Label lblIntervalo;
        private Button btnSalvar;
        private DataGridView grdContas;
        private Button btnEditar;
        private Button btnSelecionarDiretorioTemporario;
        private TextBox txtDiretorioTemporario;
        private Label label1;
        private ErrorProvider errProvider;
    }
}