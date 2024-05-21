namespace eAgenda.WinApp.ModuloContato
{
    public partial class ListagemContatoControl : UserControl
    {
        public ListagemContatoControl()
        {
            InitializeComponent();
        }

        public void AtualizarRegistros(List<Contato> contatos)
        {
            listContatos.Items.Clear();

            foreach (Contato contato in contatos)
                listContatos.Items.Add(contato);
        }

        public Contato ObterRegistroSelecionado()
        {
            if (listContatos.SelectedItem == null)
                return null;

            return (Contato)listContatos.SelectedItem;
        }
    }
}
