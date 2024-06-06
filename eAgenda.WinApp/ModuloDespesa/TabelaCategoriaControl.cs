using eAgenda.WinApp.Compartilhado;

namespace eAgenda.WinApp.ModuloDespesa
{
    public partial class TabelaCategoriaControl : UserControl
    {
        public TabelaCategoriaControl()
        {
            InitializeComponent();

            grid.Columns.AddRange(ObterColunas());

            grid.ConfigurarGridSomenteLeitura();
            grid.ConfigurarGridZebrado();
        }

        public void AtualizarRegistros(List<Categoria> categorias)
        {
            grid.Rows.Clear();

            foreach (Categoria c in categorias)
                grid.Rows.Add(c.Id, c.Titulo.ToTitleCase());
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
                new DataGridViewTextBoxColumn { DataPropertyName = "Titulo", HeaderText = "Título" },
                        };
        }
    }
}
