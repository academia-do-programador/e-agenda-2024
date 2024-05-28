namespace eAgenda.WinApp.ModuloContato
{
    partial class ListagemContatoControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            listContatos = new ListBox();
            SuspendLayout();
            // 
            // listContatos
            // 
            listContatos.Dock = DockStyle.Fill;
            listContatos.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            listContatos.FormattingEnabled = true;
            listContatos.ItemHeight = 20;
            listContatos.Location = new Point(0, 0);
            listContatos.Name = "listContatos";
            listContatos.Size = new Size(551, 323);
            listContatos.TabIndex = 0;
            // 
            // ListagemContatoControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(listContatos);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Name = "ListagemContatoControl";
            Size = new Size(551, 323);
            ResumeLayout(false);
        }

        #endregion

        private ListBox listContatos;
    }
}
