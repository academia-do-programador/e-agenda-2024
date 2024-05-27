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
            txtTerminoPeriodo = new DateTimePicker();
            txtInicioPeriodo = new DateTimePicker();
            label1 = new Label();
            lblInicioPeriodo = new Label();
            rdbCompromissosPeriodo = new RadioButton();
            rdbCompromissosFuturos = new RadioButton();
            rdbCompromissosPassados = new RadioButton();
            rdbTodosCompromissos = new RadioButton();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // btnGravar
            // 
            btnGravar.DialogResult = DialogResult.OK;
            btnGravar.Font = new Font("Segoe UI", 11.25F);
            btnGravar.Location = new Point(218, 222);
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
            btnCancelar.Location = new Point(324, 222);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(100, 37);
            btnCancelar.TabIndex = 9;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtTerminoPeriodo);
            groupBox1.Controls.Add(txtInicioPeriodo);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(lblInicioPeriodo);
            groupBox1.Controls.Add(rdbCompromissosPeriodo);
            groupBox1.Controls.Add(rdbCompromissosFuturos);
            groupBox1.Controls.Add(rdbCompromissosPassados);
            groupBox1.Controls.Add(rdbTodosCompromissos);
            groupBox1.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(412, 204);
            groupBox1.TabIndex = 11;
            groupBox1.TabStop = false;
            groupBox1.Text = "Selecione um Filtro:";
            // 
            // txtTerminoPeriodo
            // 
            txtTerminoPeriodo.Enabled = false;
            txtTerminoPeriodo.Format = DateTimePickerFormat.Short;
            txtTerminoPeriodo.Location = new Point(278, 156);
            txtTerminoPeriodo.Name = "txtTerminoPeriodo";
            txtTerminoPeriodo.Size = new Size(123, 27);
            txtTerminoPeriodo.TabIndex = 2;
            txtTerminoPeriodo.Value = new DateTime(2024, 5, 30, 0, 0, 0, 0);
            // 
            // txtInicioPeriodo
            // 
            txtInicioPeriodo.Enabled = false;
            txtInicioPeriodo.Format = DateTimePickerFormat.Short;
            txtInicioPeriodo.Location = new Point(78, 156);
            txtInicioPeriodo.Name = "txtInicioPeriodo";
            txtInicioPeriodo.Size = new Size(123, 27);
            txtInicioPeriodo.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(207, 159);
            label1.Name = "label1";
            label1.Size = new Size(66, 20);
            label1.TabIndex = 1;
            label1.Text = "Término:";
            // 
            // lblInicioPeriodo
            // 
            lblInicioPeriodo.AutoSize = true;
            lblInicioPeriodo.Location = new Point(24, 159);
            lblInicioPeriodo.Name = "lblInicioPeriodo";
            lblInicioPeriodo.Size = new Size(48, 20);
            lblInicioPeriodo.TabIndex = 1;
            lblInicioPeriodo.Text = "Início:";
            // 
            // rdbCompromissosPeriodo
            // 
            rdbCompromissosPeriodo.AutoSize = true;
            rdbCompromissosPeriodo.Location = new Point(24, 126);
            rdbCompromissosPeriodo.Name = "rdbCompromissosPeriodo";
            rdbCompromissosPeriodo.Size = new Size(230, 24);
            rdbCompromissosPeriodo.TabIndex = 0;
            rdbCompromissosPeriodo.TabStop = true;
            rdbCompromissosPeriodo.Text = "Compromissos em um Período";
            rdbCompromissosPeriodo.UseVisualStyleBackColor = true;
            rdbCompromissosPeriodo.CheckedChanged += rdbCompromissosPeriodo_CheckedChanged;
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
            // TelaFiltroCompromissoForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(436, 265);
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
        private DateTimePicker txtTerminoPeriodo;
        private DateTimePicker txtInicioPeriodo;
        private Label label1;
        private Label lblInicioPeriodo;
        private RadioButton rdbCompromissosPeriodo;
    }
}