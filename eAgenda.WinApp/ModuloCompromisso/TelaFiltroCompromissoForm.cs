namespace eAgenda.WinApp.ModuloCompromisso
{
    public partial class TelaFiltroCompromissoForm : Form
    {
        public TipoFiltroCompromissoEnum FiltroSelecionado { get; private set; }

        public TelaFiltroCompromissoForm()
        {
            InitializeComponent();
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            if (rdbTodosCompromissos.Checked)
                FiltroSelecionado = TipoFiltroCompromissoEnum.Todos;

            else if (rdbCompromissosPassados.Checked)
                FiltroSelecionado = TipoFiltroCompromissoEnum.Passados;

            else if (rdbCompromissosFuturos.Checked)
                FiltroSelecionado = TipoFiltroCompromissoEnum.Futuros;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbCompromissosPeriodo.Checked)
            {
                lblInicioPeriodo.Enabled = true;
                lblInicioPeriodo.Visible = true;

                txtInicioPeriodo.Enabled = true;
                txtInicioPeriodo.Visible = true;

                lblTerminoPeriodo.Enabled = true;
                lblTerminoPeriodo.Visible = true;

                txtTerminoPeriodo.Enabled = true;
                txtTerminoPeriodo.Visible = true;
            }
            else
            {
                lblInicioPeriodo.Enabled = false;
                lblInicioPeriodo.Visible = false;

                txtInicioPeriodo.Enabled = false;
                txtInicioPeriodo.Visible = false;

                lblTerminoPeriodo.Enabled = false;
                lblTerminoPeriodo.Visible = false;

                txtTerminoPeriodo.Enabled = false;
                txtTerminoPeriodo.Visible = false;
            }
        }
    }
}
