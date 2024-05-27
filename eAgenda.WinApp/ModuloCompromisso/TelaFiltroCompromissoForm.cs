namespace eAgenda.WinApp.ModuloCompromisso
{
    public partial class TelaFiltroCompromissoForm : Form
    {
        public TipoFiltroCompromissoEnum FiltroSelecionado { get; private set; }

        public DateTime InicioPeriodo
        {
            get
            {
                return txtInicioPeriodo.Value;
            }
        }

        public DateTime TerminoPeriodo
        {
            get
            {
                return txtTerminoPeriodo.Value;
            }
        }

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

            else if (rdbCompromissosPeriodo.Checked)
                FiltroSelecionado = TipoFiltroCompromissoEnum.Periodo;
        }

        private void rdbCompromissosPeriodo_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbCompromissosPeriodo.Checked)
            {
                txtInicioPeriodo.Enabled = true;
                txtTerminoPeriodo.Enabled = true;
            }
            else
            {
                txtInicioPeriodo.Enabled = false;
                txtTerminoPeriodo.Enabled = false;
            }
        }
    }
}
