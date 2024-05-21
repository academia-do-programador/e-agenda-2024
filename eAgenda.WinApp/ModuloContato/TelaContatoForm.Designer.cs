namespace eAgenda.WinApp.ModuloContato
{
    partial class TelaContatoForm
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
            txtNome = new TextBox();
            label2 = new Label();
            label3 = new Label();
            txtEmail = new TextBox();
            label4 = new Label();
            txtTelefone = new TextBox();
            label5 = new Label();
            txtCargo = new TextBox();
            label6 = new Label();
            txtEmpresa = new TextBox();
            btnCancelar = new Button();
            btnGravar = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11.25F);
            label1.Location = new Point(91, 41);
            label1.Name = "label1";
            label1.Size = new Size(25, 20);
            label1.TabIndex = 0;
            label1.Text = "Id:";
            // 
            // txtId
            // 
            txtId.Enabled = false;
            txtId.Font = new Font("Segoe UI", 11.25F);
            txtId.Location = new Point(122, 38);
            txtId.Name = "txtId";
            txtId.Size = new Size(100, 27);
            txtId.TabIndex = 1;
            txtId.Text = "0";
            // 
            // txtNome
            // 
            txtNome.Font = new Font("Segoe UI", 11.25F);
            txtNome.Location = new Point(122, 71);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(393, 27);
            txtNome.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11.25F);
            label2.Location = new Point(63, 74);
            label2.Name = "label2";
            label2.Size = new Size(53, 20);
            label2.TabIndex = 2;
            label2.Text = "Nome:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11.25F);
            label3.Location = new Point(63, 107);
            label3.Name = "label3";
            label3.Size = new Size(49, 20);
            label3.TabIndex = 2;
            label3.Text = "Email:";
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Segoe UI", 11.25F);
            txtEmail.Location = new Point(122, 104);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(393, 27);
            txtEmail.TabIndex = 1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 11.25F);
            label4.Location = new Point(47, 140);
            label4.Name = "label4";
            label4.Size = new Size(69, 20);
            label4.TabIndex = 2;
            label4.Text = "Telefone:";
            // 
            // txtTelefone
            // 
            txtTelefone.Font = new Font("Segoe UI", 11.25F);
            txtTelefone.Location = new Point(122, 137);
            txtTelefone.Name = "txtTelefone";
            txtTelefone.Size = new Size(393, 27);
            txtTelefone.TabIndex = 2;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 11.25F);
            label5.Location = new Point(60, 173);
            label5.Name = "label5";
            label5.Size = new Size(52, 20);
            label5.TabIndex = 2;
            label5.Text = "Cargo:";
            // 
            // txtCargo
            // 
            txtCargo.Font = new Font("Segoe UI", 11.25F);
            txtCargo.Location = new Point(122, 170);
            txtCargo.Name = "txtCargo";
            txtCargo.Size = new Size(157, 27);
            txtCargo.TabIndex = 3;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 11.25F);
            label6.Location = new Point(285, 173);
            label6.Name = "label6";
            label6.Size = new Size(69, 20);
            label6.TabIndex = 2;
            label6.Text = "Empresa:";
            // 
            // txtEmpresa
            // 
            txtEmpresa.Font = new Font("Segoe UI", 11.25F);
            txtEmpresa.Location = new Point(358, 170);
            txtEmpresa.Name = "txtEmpresa";
            txtEmpresa.Size = new Size(157, 27);
            txtEmpresa.TabIndex = 4;
            // 
            // btnCancelar
            // 
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.Font = new Font("Segoe UI", 11.25F);
            btnCancelar.Location = new Point(415, 233);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(100, 37);
            btnCancelar.TabIndex = 5;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnGravar
            // 
            btnGravar.DialogResult = DialogResult.OK;
            btnGravar.Font = new Font("Segoe UI", 11.25F);
            btnGravar.Location = new Point(309, 233);
            btnGravar.Name = "btnGravar";
            btnGravar.Size = new Size(100, 37);
            btnGravar.TabIndex = 6;
            btnGravar.Text = "Gravar";
            btnGravar.UseVisualStyleBackColor = true;
            btnGravar.Click += btnGravar_Click;
            // 
            // TelaContatoForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(573, 277);
            Controls.Add(btnGravar);
            Controls.Add(btnCancelar);
            Controls.Add(txtEmpresa);
            Controls.Add(txtCargo);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(txtTelefone);
            Controls.Add(label4);
            Controls.Add(txtEmail);
            Controls.Add(label3);
            Controls.Add(txtNome);
            Controls.Add(label2);
            Controls.Add(txtId);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "TelaContatoForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Cadastro de Contato";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtId;
        private TextBox txtNome;
        private Label label2;
        private Label label3;
        private TextBox txtEmail;
        private Label label4;
        private TextBox txtTelefone;
        private Label label5;
        private TextBox txtCargo;
        private Label label6;
        private TextBox txtEmpresa;
        private Button btnCancelar;
        private Button btnGravar;
    }
}