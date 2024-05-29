namespace eAgenda.WinApp.ModuloTarefa
{
    public partial class TelaTarefaForm : Form
    {
        public TelaTarefaForm()
        {
            InitializeComponent();

            Type tipo = typeof(PrioridadeTarefaEnum);

            Array nomesEnum = Enum.GetValues(tipo);

            foreach (var nome in nomesEnum)
                cmbPrioridades.Items.Add(nome);

            cmbPrioridades.SelectedItem = PrioridadeTarefaEnum.Baixa;
        }
    }
}
