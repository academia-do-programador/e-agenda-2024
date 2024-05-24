namespace eAgenda.WinApp.ModuloCompromisso
{
    partial class TelaFiltroCompromissoForm
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
            btnGravar = new Button();
            btnCancelar = new Button();
            groupBox1 = new GroupBox();
            rdbTodosCompromissos = new RadioButton();
            rdbCompromissosPassados = new RadioButton();
            rdbCompromissosFuturos = new RadioButton();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // btnGravar
            // 
            btnGravar.DialogResult = DialogResult.OK;
            btnGravar.Font = new Font("Segoe UI", 11.25F);
            btnGravar.Location = new Point(218, 161);
            btnGravar.Name = "btnGravar";
            btnGravar.Size = new Size(100, 37);
            btnGravar.TabIndex = 10;
            btnGravar.Text = "Gravar";
            btnGravar.UseVisualStyleBackColor = true;
            btnGravar.Click += btnGravar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.Font = new Font("Segoe UI", 11.25F);
            btnCancelar.Location = new Point(324, 161);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(100, 37);
            btnCancelar.TabIndex = 9;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(rdbCompromissosFuturos);
            groupBox1.Controls.Add(rdbCompromissosPassados);
            groupBox1.Controls.Add(rdbTodosCompromissos);
            groupBox1.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(412, 143);
            groupBox1.TabIndex = 11;
            groupBox1.TabStop = false;
            groupBox1.Text = "Selecione um Filtro:";
            // 
            // rdbTodosCompromissos
            // 
            rdbTodosCompromissos.AutoSize = true;
            rdbTodosCompromissos.Location = new Point(24, 36);
            rdbTodosCompromissos.Name = "rdbTodosCompromissos";
            rdbTodosCompromissos.Size = new Size(188, 24);
            rdbTodosCompromissos.TabIndex = 0;
            rdbTodosCompromissos.TabStop = true;
            rdbTodosCompromissos.Text = "Todos os Compromissos";
            rdbTodosCompromissos.UseVisualStyleBackColor = true;
            // 
            // rdbCompromissosPassados
            // 
            rdbCompromissosPassados.AutoSize = true;
            rdbCompromissosPassados.Location = new Point(24, 66);
            rdbCompromissosPassados.Name = "rdbCompromissosPassados";
            rdbCompromissosPassados.Size = new Size(188, 24);
            rdbCompromissosPassados.TabIndex = 0;
            rdbCompromissosPassados.TabStop = true;
            rdbCompromissosPassados.Text = "Compromissos Passados";
            rdbCompromissosPassados.UseVisualStyleBackColor = true;
            // 
            // rdbCompromissosFuturos
            // 
            rdbCompromissosFuturos.AutoSize = true;
            rdbCompromissosFuturos.Location = new Point(24, 96);
            rdbCompromissosFuturos.Name = "rdbCompromissosFuturos";
            rdbCompromissosFuturos.Size = new Size(177, 24);
            rdbCompromissosFuturos.TabIndex = 0;
            rdbCompromissosFuturos.TabStop = true;
            rdbCompromissosFuturos.Text = "Compromissos Futuros";
            rdbCompromissosFuturos.UseVisualStyleBackColor = true;
            // 
            // TelaFiltroCompromissoForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(436, 205);
            Controls.Add(groupBox1);
            Controls.Add(btnGravar);
            Controls.Add(btnCancelar);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "TelaFiltroCompromissoForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Filtro de Compromissos";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button btnGravar;
        private Button btnCancelar;
        private GroupBox groupBox1;
        private RadioButton rdbTodosCompromissos;
        private RadioButton rdbCompromissosFuturos;
        private RadioButton rdbCompromissosPassados;
    }
}