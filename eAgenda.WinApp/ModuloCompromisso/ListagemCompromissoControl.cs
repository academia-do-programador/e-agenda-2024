namespace eAgenda.WinApp.ModuloCompromisso
{
    public partial class ListagemCompromissoControl : UserControl
    {
        public ListagemCompromissoControl()
        {
            InitializeComponent();
        }

        public void AtualizarRegistros(List<Compromisso> compromissos)
        {
            listCompromissos.Items.Clear();

            foreach (Compromisso compromisso in compromissos)
                listCompromissos.Items.Add(compromisso);
        }

        public Compromisso ObterRegistroSelecionado()
        {
            if (listCompromissos.SelectedItem == null)
                return null;

            return (Compromisso)listCompromissos.SelectedItem;
        }
    }
}
