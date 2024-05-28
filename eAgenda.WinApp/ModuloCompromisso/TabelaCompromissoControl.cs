namespace eAgenda.WinApp.ModuloCompromisso
{
    public partial class TabelaCompromissoControl : UserControl
    {
        public TabelaCompromissoControl()
        {
            InitializeComponent();

            grid.Columns.AddRange(ObterColunas());

            ConfigurarGridSomenteLeitura();
        }

        private void ConfigurarGridSomenteLeitura()
        {
            grid.AllowUserToAddRows = false;
            grid.AllowUserToDeleteRows = false;

            grid.BorderStyle = BorderStyle.None;

            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;

            grid.MultiSelect = false;
            grid.ReadOnly = true;

            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.AutoGenerateColumns = false;

            grid.AllowUserToResizeRows = false;
            grid.RowHeadersVisible = false;
        }

        public void AtualizarRegistros(List<Compromisso> compromissos)
        {
            grid.Rows.Clear();

            foreach (Compromisso c in compromissos)
                grid.Rows.Add(c.Id, c.Assunto, c.Data, c.HoraInicio, c.HoraTermino, c.Contato);
        }

        public Compromisso ObterRegistroSelecionado()
        {
            return null;
        }

        private DataGridViewColumn[] ObterColunas()
        {
            return new DataGridViewColumn[]
                        {
                new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "Id" },
                new DataGridViewTextBoxColumn { DataPropertyName = "Assunto", HeaderText = "Assunto" },
                new DataGridViewTextBoxColumn { DataPropertyName = "Data", HeaderText = "Data" },
                new DataGridViewTextBoxColumn { DataPropertyName = "HoraInicio", HeaderText = "Começa às" },
                new DataGridViewTextBoxColumn { DataPropertyName = "HoraTermino", HeaderText = "Termina às" },
                new DataGridViewTextBoxColumn { DataPropertyName = "Contato", HeaderText = "Contato" },
                        };
        }
    }
}
