namespace eAgenda.WinApp.ModuloTarefa
{
    public partial class TelaCadastroItemTarefa : Form
    {
        private Tarefa tarefa;

        public Tarefa Tarefa
        {
            get
            {
                return tarefa;
            }
            set
            {
                tarefa = value;
            }
        }

        public List<ItemTarefa> ItensAdicionados
        {
            get
            {
                return listItensTarefa.Items.Cast<ItemTarefa>().ToList();
            }
        }

        public TelaCadastroItemTarefa(Tarefa tarefaSelecionada)
        {
            InitializeComponent();

            Tarefa = tarefaSelecionada;

            labelTituloTarefa.Text = tarefaSelecionada.Titulo;

            foreach (ItemTarefa item in tarefaSelecionada.Itens)
                listItensTarefa.Items.Add(item);
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            List<string> titulos = ItensAdicionados.Select(x => x.Titulo).ToList();

            if (titulos.Contains(txtTituloItem.Text))
                return;

            ItemTarefa itemTarefa = new ItemTarefa(txtTituloItem.Text);

            listItensTarefa.Items.Add(itemTarefa);
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            return;
        }
    }
}
