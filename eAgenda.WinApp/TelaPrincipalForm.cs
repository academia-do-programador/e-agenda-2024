using eAgenda.WinApp.Compartilhado;
using eAgenda.WinApp.ModuloCompromisso;
using eAgenda.WinApp.ModuloContato;

namespace eAgenda.WinApp
{
    public partial class TelaPrincipalForm : Form
    {
        ControladorBase controlador;

        RepositorioContato repositorioContato;
        RepositorioCompromisso repositorioCompromisso;

        public static TelaPrincipalForm Instancia { get; private set; }

        public TelaPrincipalForm()
        {
            InitializeComponent();
            lblTipoCadastro.Text = string.Empty;

            repositorioContato = new RepositorioContato();
            repositorioCompromisso = new RepositorioCompromisso();

            Contato contato = new Contato("Alexandre Rech", "49 985052123", "rech@gmail.com", "Academia do Programador", "CEO");
            repositorioContato.Cadastrar(contato);

            DateTime data = DateTime.Today.AddDays(-3);
            TimeSpan horaInicio = new TimeSpan(09, 00, 00);
            TimeSpan horaTermino = new TimeSpan(10, 00, 00);

            Compromisso compromisso = new Compromisso("Reunião", "", "www.discord.com", data, horaInicio, horaTermino, contato);
            repositorioCompromisso.Cadastrar(compromisso);

            Instancia = this;
        }

        public void AtualizarRodape(string texto)
        {
            statusLabelPrincipal.Text = texto;
        }

        private void contatosMenuItem_Click(object sender, EventArgs e)
        {
            controlador = new ControladorContato(repositorioContato);

            lblTipoCadastro.Text = "Cadastro de " + controlador.TipoCadastro;

            ConfigurarToolTips(controlador);
            ConfigurarListagem(controlador);
        }

        private void compromissosMenuItem_Click(object sender, EventArgs e)
        {
            controlador = new ControladorCompromisso(repositorioCompromisso, repositorioContato);

            lblTipoCadastro.Text = "Cadastro de " + controlador.TipoCadastro;

            ConfigurarToolTips(controlador);
            ConfigurarListagem(controlador);
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            controlador.Adicionar();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            controlador.Editar();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            controlador.Excluir();
        }

        private void ConfigurarToolTips(ControladorBase controladorSelecionado)
        {
            btnAdicionar.ToolTipText = controladorSelecionado.ToolTipAdicionar;
            btnEditar.ToolTipText = controladorSelecionado.ToolTipEditar;
            btnExcluir.ToolTipText = controladorSelecionado.ToolTipExcluir;
        }
        private void ConfigurarListagem(ControladorBase controladorSelecionado)
        {
            UserControl listagemContato = controladorSelecionado.ObterListagem();
            listagemContato.Dock = DockStyle.Fill;

            pnlRegistros.Controls.Clear();
            pnlRegistros.Controls.Add(listagemContato);
        }
    }
}
