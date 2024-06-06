using eAgenda.WinApp.Compartilhado;

namespace eAgenda.WinApp.ModuloDespesa
{
    public class ControladorCategoria : ControladorBase
    {
        private IRepositorioCategoria repositorioCategoria;
        private TabelaCategoriaControl tabelaCategorias;

        public override string TipoCadastro { get { return "Categorias"; } }

        public override string ToolTipAdicionar { get { return "Cadastrar nova categoria"; } }

        public override string ToolTipEditar { get { return "Editar uma categoria existente"; } }


        public override string ToolTipExcluir { get { return "Excluír uma categoria existente"; } }

        public ControladorCategoria(IRepositorioCategoria repositorioCategoria)
        {
            this.repositorioCategoria = repositorioCategoria;
        }

        public override void Adicionar()
        {
            TelaCategoriaForm telaCategoria = new TelaCategoriaForm();

            DialogResult resultado = telaCategoria.ShowDialog();

            if (resultado != DialogResult.OK)
                return;

            Categoria novoCategoria = telaCategoria.Categoria;

            repositorioCategoria.Cadastrar(novoCategoria);

            CarregarCategorias();

            TelaPrincipalForm
                .Instancia
                .AtualizarRodape($"O registro \"{novoCategoria.Titulo}\" foi criado com sucesso!");
        }

        public override void Editar()
        {
            throw new NotImplementedException();
        }

        public override void Excluir()
        {
            throw new NotImplementedException();
        }

        public override UserControl ObterListagem()
        {
            if (tabelaCategorias == null)
                tabelaCategorias = new TabelaCategoriaControl();

            CarregarCategorias();

            return tabelaCategorias;
        }

        private void CarregarCategorias()
        {
            List<Categoria> Categorias = repositorioCategoria.SelecionarTodos();

            tabelaCategorias.AtualizarRegistros(Categorias);
        }
    }
}
