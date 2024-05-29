namespace eAgenda.WinApp.ModuloTarefa
{
    partial class TelaCadastroItemTarefa
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
            txtTituloItem = new TextBox();
            label1 = new Label();
            listItensTarefa = new ListBox();
            btnAdicionar = new Button();
            label2 = new Label();
            labelTituloTarefa = new Label();
            btnGravar = new Button();
            btnCancelar = new Button();
            SuspendLayout();
            // 
            // txtTituloItem
            // 
            txtTituloItem.Font = new Font("Segoe UI", 11.25F);
            txtTituloItem.Location = new Point(68, 54);
            txtTituloItem.Name = "txtTituloItem";
            txtTituloItem.Size = new Size(239, 27);
            txtTituloItem.TabIndex = 8;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11.25F);
            label1.Location = new Point(12, 57);
            label1.Name = "label1";
            label1.Size = new Size(50, 20);
            label1.TabIndex = 9;
            label1.Text = "Título:";
            // 
            // listItensTarefa
            // 
            listItensTarefa.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            listItensTarefa.FormattingEnabled = true;
            listItensTarefa.ItemHeight = 20;
            listItensTarefa.Location = new Point(12, 101);
            listItensTarefa.Name = "listItensTarefa";
            listItensTarefa.Size = new Size(384, 164);
            listItensTarefa.TabIndex = 10;
            // 
            // btnAdicionar
            // 
            btnAdicionar.Font = new Font("Segoe UI", 11.25F);
            btnAdicionar.Location = new Point(313, 54);
            btnAdicionar.Name = "btnAdicionar";
            btnAdicionar.Size = new Size(83, 27);
            btnAdicionar.TabIndex = 11;
            btnAdicionar.Text = "Adicionar";
            btnAdicionar.UseVisualStyleBackColor = true;
            btnAdicionar.Click += btnAdicionar_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(10, 19);
            label2.Name = "label2";
            label2.Size = new Size(52, 20);
            label2.TabIndex = 12;
            label2.Text = "Tarefa:";
            // 
            // labelTituloTarefa
            // 
            labelTituloTarefa.AutoSize = true;
            labelTituloTarefa.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelTituloTarefa.Location = new Point(70, 19);
            labelTituloTarefa.Name = "labelTituloTarefa";
            labelTituloTarefa.Size = new Size(110, 20);
            labelTituloTarefa.TabIndex = 13;
            labelTituloTarefa.Text = "[Titulo Tarefa]";
            // 
            // btnGravar
            // 
            btnGravar.DialogResult = DialogResult.OK;
            btnGravar.Font = new Font("Segoe UI", 11.25F);
            btnGravar.Location = new Point(190, 296);
            btnGravar.Name = "btnGravar";
            btnGravar.Size = new Size(100, 37);
            btnGravar.TabIndex = 15;
            btnGravar.Text = "Gravar";
            btnGravar.UseVisualStyleBackColor = true;
            btnGravar.Click += btnGravar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.Font = new Font("Segoe UI", 11.25F);
            btnCancelar.Location = new Point(296, 296);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(100, 37);
            btnCancelar.TabIndex = 14;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // TelaCadastroItemTarefa
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(408, 343);
            Controls.Add(btnGravar);
            Controls.Add(btnCancelar);
            Controls.Add(labelTituloTarefa);
            Controls.Add(label2);
            Controls.Add(btnAdicionar);
            Controls.Add(listItensTarefa);
            Controls.Add(label1);
            Controls.Add(txtTituloItem);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "TelaCadastroItemTarefa";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cadastro de Itens da Tarefa";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.TextBox txtTituloItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listItensTarefa;
        private System.Windows.Forms.Button btnAdicionar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelTituloTarefa;
        private Button btnGravar;
        private Button btnCancelar;
    }
}