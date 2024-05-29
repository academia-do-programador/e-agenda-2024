namespace eAgenda.WinApp.ModuloTarefa
{
    partial class TelaTarefaForm
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
            label1 = new Label();
            txtId = new TextBox();
            label2 = new Label();
            txtTitulo = new TextBox();
            label3 = new Label();
            cmbPrioridades = new ComboBox();
            btnGravar = new Button();
            btnCancelar = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11.25F);
            label1.Location = new Point(90, 36);
            label1.Name = "label1";
            label1.Size = new Size(25, 20);
            label1.TabIndex = 0;
            label1.Text = "Id:";
            // 
            // txtId
            // 
            txtId.Enabled = false;
            txtId.Font = new Font("Segoe UI", 11.25F);
            txtId.Location = new Point(121, 36);
            txtId.Name = "txtId";
            txtId.Size = new Size(88, 27);
            txtId.TabIndex = 1;
            txtId.Text = "0";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11.25F);
            label2.Location = new Point(65, 72);
            label2.Name = "label2";
            label2.Size = new Size(50, 20);
            label2.TabIndex = 0;
            label2.Text = "Título:";
            // 
            // txtTitulo
            // 
            txtTitulo.Font = new Font("Segoe UI", 11.25F);
            txtTitulo.Location = new Point(121, 69);
            txtTitulo.Name = "txtTitulo";
            txtTitulo.Size = new Size(380, 27);
            txtTitulo.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11.25F);
            label3.Location = new Point(34, 105);
            label3.Name = "label3";
            label3.Size = new Size(81, 20);
            label3.TabIndex = 0;
            label3.Text = "Prioridade:";
            // 
            // cmbPrioridades
            // 
            cmbPrioridades.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPrioridades.FormattingEnabled = true;
            cmbPrioridades.Location = new Point(121, 105);
            cmbPrioridades.Name = "cmbPrioridades";
            cmbPrioridades.Size = new Size(165, 23);
            cmbPrioridades.TabIndex = 2;
            // 
            // btnGravar
            // 
            btnGravar.DialogResult = DialogResult.OK;
            btnGravar.Font = new Font("Segoe UI", 11.25F);
            btnGravar.Location = new Point(295, 162);
            btnGravar.Name = "btnGravar";
            btnGravar.Size = new Size(100, 37);
            btnGravar.TabIndex = 8;
            btnGravar.Text = "Gravar";
            btnGravar.UseVisualStyleBackColor = true;
            btnGravar.Click += btnGravar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.Font = new Font("Segoe UI", 11.25F);
            btnCancelar.Location = new Point(401, 162);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(100, 37);
            btnCancelar.TabIndex = 7;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // TelaTarefaForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(528, 207);
            Controls.Add(btnGravar);
            Controls.Add(btnCancelar);
            Controls.Add(cmbPrioridades);
            Controls.Add(label3);
            Controls.Add(txtTitulo);
            Controls.Add(label2);
            Controls.Add(txtId);
            Controls.Add(label1);
            Name = "TelaTarefaForm";
            Text = "Cadastro de Tarefas";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtId;
        private Label label2;
        private TextBox txtTitulo;
        private Label label3;
        private ComboBox cmbPrioridades;
        private Button btnGravar;
        private Button btnCancelar;
    }
}