namespace eAgenda.WinApp.ModuloCompromisso
{
    public partial class TelaFiltroCompromissoForm : Form
    {
        public TipoFiltroCompromissoEnum TipoEscolhido { get; private set; }

        public TelaFiltroCompromissoForm()
        {
            InitializeComponent();
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            if (rdbTodosCompromissos.Checked)
                TipoEscolhido = TipoFiltroCompromissoEnum.Todos;

            else if (rdbCompromissosPassados.Checked)
                TipoEscolhido = TipoFiltroCompromissoEnum.Passados;

            else if (rdbCompromissosFuturos.Checked)
                TipoEscolhido = TipoFiltroCompromissoEnum.Futuros;
        }
    }
}
