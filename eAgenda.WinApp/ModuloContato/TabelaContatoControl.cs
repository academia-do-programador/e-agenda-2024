
using eAgenda.WinApp.Compartilhado;

namespace eAgenda.WinApp.ModuloContato
{
    public partial class TabelaContatoControl : UserControl
    {
        public TabelaContatoControl()
        {
            InitializeComponent();

            grid.Columns.AddRange(ObterColunas());

            grid.ConfigurarGridSomenteLeitura();
            grid.ConfigurarGridZebrado();
        }

        public void AtualizarRegistros(List<Contato> contatos)
        {
            grid.Rows.Clear();

            foreach (Contato c in contatos)
                grid.Rows.Add(c.Id, c.Nome.ToTitleCase(), c.Telefone, c.Email, c.Empresa, c.Cargo);
        }

        public int ObterRegistroSelecionado()
        {
            return grid.SelecionarId();
        }

        private DataGridViewColumn[] ObterColunas()
        {
            return new DataGridViewColumn[]
                        {
                new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "Id" },
                new DataGridViewTextBoxColumn { DataPropertyName = "Nome", HeaderText = "Nome" },
                new DataGridViewTextBoxColumn { DataPropertyName = "Telefone", HeaderText = "Telefone" },
                new DataGridViewTextBoxColumn { DataPropertyName = "Email", HeaderText = "Email" },
                new DataGridViewTextBoxColumn { DataPropertyName = "Empresa", HeaderText = "Empresa" },
                new DataGridViewTextBoxColumn { DataPropertyName = "Cargo", HeaderText = "Cargo" },
                        };
        }
    }
}
