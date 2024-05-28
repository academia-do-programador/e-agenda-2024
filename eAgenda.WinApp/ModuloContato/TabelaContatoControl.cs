
using eAgenda.WinApp.Compartilhado;

namespace eAgenda.WinApp.ModuloContato
{
    public partial class TabelaContatoControl : UserControl
    {
        public TabelaContatoControl()
        {
            InitializeComponent();

            grid.ConfigurarGridSomenteLeitura();
            grid.ConfigurarGridZebrado();
        }

        public void AtualizarRegistros(List<Contato> contatos)
        {
            // linhas
            grid.Rows.Clear();

            foreach (Contato c in contatos)
                grid.Rows.Add(c.Id, c.Nome.ToTitleCase(), c.Telefone, c.Email, c.Empresa, c.Cargo);
        }

        public Contato ObterRegistroSelecionado()
        {
            return null;
        }
    }
}
