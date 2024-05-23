namespace eAgenda.WinApp.ModuloCompromisso
{
    public partial class TelaCompromissoForm : Form
    {
        public TelaCompromissoForm()
        {
            InitializeComponent();
        }

        private void checkMarcarContato_CheckedChanged(object sender, EventArgs e)
        {
            if (checkMarcarContato.Checked)
                cmbContatos.Enabled = true;
            else
            {
                cmbContatos.SelectedItem = null;
                cmbContatos.Enabled = false;
            }
        }

        private void rdbPresencial_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbPresencial.Checked)
            {
                txtLink.Text = string.Empty;
                txtLink.Enabled = false;
            }
            else
            {
                txtLink.Enabled = true;
            }
        }

        private void rdbRemoto_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbRemoto.Checked)
            {
                txtLocal.Text = string.Empty;
                txtLocal.Enabled = false;
            }
            else
            {
                txtLocal.Enabled = true;
            }
        }
    }
}
