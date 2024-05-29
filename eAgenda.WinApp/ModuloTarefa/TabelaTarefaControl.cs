namespace eAgenda.WinApp.ModuloTarefa
{
    public partial class TabelaTarefaControl : UserControl
    {
        public TabelaTarefaControl()
        {
            InitializeComponent();

            ConfigurarColunas();
            ConfigurarListView();
        }

        public void AtualizarRegistros(List<Tarefa> tarefas)
        {
            listTarefas.Items.Clear();

            foreach (Tarefa t in tarefas)
            {
                ListViewItem item = new ListViewItem(t.Id.ToString());

                item.SubItems.Add(t.Titulo);
                item.SubItems.Add(t.DataCriacao.ToShortDateString());

                listTarefas.Items.Add(item);
            }
        }

        private void ConfigurarColunas()
        {
            ColumnHeader[] colunas = new ColumnHeader[]
            {
                new ColumnHeader() { Text = "Id", Width = 80 },
                new ColumnHeader() { Text = "Título", Width = 200 },
                new ColumnHeader() { Text = "Data de Criação", Width = 100 },
            };

            listTarefas.Columns.AddRange(colunas);
        }

        private void ConfigurarListView()
        {
            listTarefas.MultiSelect = false;
            listTarefas.FullRowSelect = true;
            listTarefas.GridLines = true;

            listTarefas.View = View.Details;
        }
    }
}
