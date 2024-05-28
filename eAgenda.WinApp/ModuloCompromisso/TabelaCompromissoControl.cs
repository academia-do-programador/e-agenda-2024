using eAgenda.WinApp.Compartilhado;

namespace eAgenda.WinApp.ModuloCompromisso
{
    public partial class TabelaCompromissoControl : UserControl
    {
        public TabelaCompromissoControl()
        {
            InitializeComponent();

            grid.Columns.AddRange(ObterColunas());

            grid.ConfigurarGridSomenteLeitura();
            grid.ConfigurarGridZebrado();
        }

        public void AtualizarRegistros(List<Compromisso> compromissos)
        {
            grid.Rows.Clear();

            foreach (Compromisso c in compromissos)
                grid.Rows.Add(
                    c.Id,
                    c.Assunto,
                    c.Data.ToShortDateString(),
                    c.HoraInicio.ToString(@"hh\:mm"),
                    c.HoraTermino.ToString(@"hh\:mm"),
                    c.Contato);
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
                new DataGridViewTextBoxColumn { DataPropertyName = "Assunto", HeaderText = "Assunto" },
                new DataGridViewTextBoxColumn { DataPropertyName = "Data", HeaderText = "Data" },
                new DataGridViewTextBoxColumn { DataPropertyName = "HoraInicio", HeaderText = "Começa às" },
                new DataGridViewTextBoxColumn { DataPropertyName = "HoraTermino", HeaderText = "Termina às" },
                new DataGridViewTextBoxColumn { DataPropertyName = "Contato", HeaderText = "Contato" },
                        };
        }
    }
}
