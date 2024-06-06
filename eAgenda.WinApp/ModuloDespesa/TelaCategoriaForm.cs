namespace eAgenda.WinApp.ModuloDespesa
{
    public partial class TelaCategoriaForm : Form
    {
        private Categoria categoria;

        public Categoria Categoria
        {
            get
            {
                return categoria;
            }
            set
            {
                txtId.Text = value.Id.ToString();
                txtTitulo.Text = value.Titulo;
            }
        }

        public TelaCategoriaForm()
        {
            InitializeComponent();
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            string titulo = txtTitulo.Text;

            categoria = new Categoria(titulo);

            List<string> erros = categoria.Validar();

            if (erros.Count > 0)
            {
                TelaPrincipalForm.Instancia.AtualizarRodape(erros[0]);

                DialogResult = DialogResult.None;
            }
        }
    }
}
