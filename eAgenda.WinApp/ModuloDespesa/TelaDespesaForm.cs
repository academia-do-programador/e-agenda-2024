namespace eAgenda.WinApp.ModuloDespesa
{
    public partial class TelaDespesaForm : Form
    {
        private Despesa despesa;

        public Despesa Despesa
        {
            get { return despesa; }
        }

        public List<Categoria> CategoriasSelecionadas
        {
            get
            {
                return listCategorias.CheckedItems
                    .Cast<Categoria>()
                    .ToList();
            }
        }

        public List<Categoria> CategoriasDesmarcadas
        {
            get
            {
                return listCategorias.Items
                    .Cast<Categoria>()
                    .Except(CategoriasSelecionadas)
                    .ToList();
            }
        }

        public TelaDespesaForm()
        {
            InitializeComponent();

            CarregarFormasDePagamento();
        }

        public void CarregarCategorias(List<Categoria> categorias)
        {
            foreach (Categoria item in categorias)
                listCategorias.Items.Add(item);
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            string descricao = txtDescricao.Text;
            decimal valor = Convert.ToDecimal(txtValor.Text);
            DateTime data = txtData.Value;

            FormaPagamentoEnum formaPagamento = (FormaPagamentoEnum)cmbFormaPgto.SelectedItem;

            despesa = new Despesa(descricao, valor, data, formaPagamento);

            List<string> erros = despesa.Validar();

            if (erros.Count > 0)
            {
                TelaPrincipalForm.Instancia.AtualizarRodape(erros[0]);

                DialogResult = DialogResult.None;
            }
        }

        private void CarregarFormasDePagamento()
        {
            var formasDePagamento = Enum.GetValues(typeof(FormaPagamentoEnum));

            foreach (var item in formasDePagamento)
                cmbFormaPgto.Items.Add(item);
        }
    }
}
