using eAgenda.WinApp.Compartilhado;

namespace eAgenda.WinApp.ModuloDespesa
{
    public partial class TabelaDespesaControl : UserControl
    {
        public TabelaDespesaControl()
        {
            InitializeComponent();

            grid.Columns.AddRange(ObterColunas());

            grid.ConfigurarGridZebrado();
            grid.ConfigurarGridSomenteLeitura();
        }

        public void AtualizarRegistros(List<Despesa> despesas)
        {
            grid.Rows.Clear();

            foreach (Despesa despesa in despesas)
                grid.Rows.Add(despesa.Id, despesa.Descricao, despesa.Valor, despesa.Data);
        }

        public int ObterRegistroSelecionado()
        {
            return grid.SelecionarId();
        }

        private DataGridViewColumn[] ObterColunas()
        {
            var colunas = new DataGridViewColumn[]
           {
                new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "Id"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Descricao", HeaderText = "Descrição"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Valor", HeaderText = "Valor"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Data", HeaderText = "Data"}
           };

            return colunas;
        }
    }
}
