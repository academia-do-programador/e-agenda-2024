namespace eAgenda.WinApp.ModuloDespesa
{
    partial class TelaDespesaForm
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
            txtNumero = new TextBox();
            txtDescricao = new TextBox();
            label2 = new Label();
            txtValor = new TextBox();
            label3 = new Label();
            label4 = new Label();
            txtData = new DateTimePicker();
            cmbFormaPgto = new ComboBox();
            label5 = new Label();
            groupBox1 = new GroupBox();
            listCategorias = new CheckedListBox();
            btnGravar = new Button();
            btnCancelar = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11.25F);
            label1.Location = new Point(97, 16);
            label1.Name = "label1";
            label1.Size = new Size(25, 20);
            label1.TabIndex = 0;
            label1.Text = "Id:";
            // 
            // txtNumero
            // 
            txtNumero.Enabled = false;
            txtNumero.Font = new Font("Segoe UI", 11.25F);
            txtNumero.Location = new Point(128, 13);
            txtNumero.Name = "txtNumero";
            txtNumero.Size = new Size(79, 27);
            txtNumero.TabIndex = 1;
            txtNumero.Text = "0";
            // 
            // txtDescricao
            // 
            txtDescricao.Font = new Font("Segoe UI", 11.25F);
            txtDescricao.Location = new Point(128, 46);
            txtDescricao.Name = "txtDescricao";
            txtDescricao.Size = new Size(288, 27);
            txtDescricao.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11.25F);
            label2.Location = new Point(45, 49);
            label2.Name = "label2";
            label2.Size = new Size(77, 20);
            label2.TabIndex = 2;
            label2.Text = "Descrição:";
            // 
            // txtValor
            // 
            txtValor.Font = new Font("Segoe UI", 11.25F);
            txtValor.Location = new Point(128, 79);
            txtValor.Name = "txtValor";
            txtValor.Size = new Size(123, 27);
            txtValor.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11.25F);
            label3.Location = new Point(76, 82);
            label3.Name = "label3";
            label3.Size = new Size(46, 20);
            label3.TabIndex = 4;
            label3.Text = "Valor:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 11.25F);
            label4.Location = new Point(78, 149);
            label4.Name = "label4";
            label4.Size = new Size(44, 20);
            label4.TabIndex = 6;
            label4.Text = "Data:";
            // 
            // txtData
            // 
            txtData.Font = new Font("Segoe UI", 11.25F);
            txtData.Format = DateTimePickerFormat.Short;
            txtData.Location = new Point(128, 146);
            txtData.Name = "txtData";
            txtData.Size = new Size(123, 27);
            txtData.TabIndex = 4;
            // 
            // cmbFormaPgto
            // 
            cmbFormaPgto.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFormaPgto.Font = new Font("Segoe UI", 11.25F);
            cmbFormaPgto.FormattingEnabled = true;
            cmbFormaPgto.Location = new Point(128, 112);
            cmbFormaPgto.Name = "cmbFormaPgto";
            cmbFormaPgto.Size = new Size(123, 28);
            cmbFormaPgto.TabIndex = 6;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 11.25F);
            label5.Location = new Point(13, 116);
            label5.Name = "label5";
            label5.Size = new Size(109, 20);
            label5.TabIndex = 9;
            label5.Text = "Forma de Pgto:";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(listCategorias);
            groupBox1.Font = new Font("Segoe UI", 11.25F);
            groupBox1.Location = new Point(22, 181);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(394, 211);
            groupBox1.TabIndex = 10;
            groupBox1.TabStop = false;
            groupBox1.Text = "Categorias";
            // 
            // listCategorias
            // 
            listCategorias.CheckOnClick = true;
            listCategorias.Dock = DockStyle.Fill;
            listCategorias.FormattingEnabled = true;
            listCategorias.Location = new Point(3, 23);
            listCategorias.Name = "listCategorias";
            listCategorias.Size = new Size(388, 185);
            listCategorias.TabIndex = 0;
            // 
            // btnGravar
            // 
            btnGravar.DialogResult = DialogResult.OK;
            btnGravar.Font = new Font("Segoe UI", 11.25F);
            btnGravar.Location = new Point(210, 404);
            btnGravar.Name = "btnGravar";
            btnGravar.Size = new Size(100, 37);
            btnGravar.TabIndex = 17;
            btnGravar.Text = "Gravar";
            btnGravar.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.Font = new Font("Segoe UI", 11.25F);
            btnCancelar.Location = new Point(316, 404);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(100, 37);
            btnCancelar.TabIndex = 16;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // TelaDespesaForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(431, 447);
            Controls.Add(btnGravar);
            Controls.Add(btnCancelar);
            Controls.Add(groupBox1);
            Controls.Add(label5);
            Controls.Add(cmbFormaPgto);
            Controls.Add(txtData);
            Controls.Add(label4);
            Controls.Add(txtValor);
            Controls.Add(label3);
            Controls.Add(txtDescricao);
            Controls.Add(label2);
            Controls.Add(txtNumero);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "TelaDespesaForm";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Controle de Despesas";
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtValor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker txtData;
        private System.Windows.Forms.ComboBox cmbFormaPgto;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckedListBox listCategorias;
        private Button btnGravar;
        private Button btnCancelar;
    }
}