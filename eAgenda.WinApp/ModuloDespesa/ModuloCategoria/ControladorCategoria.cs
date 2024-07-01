using eAgenda.Dominio.ModuloCategoria;
using eAgenda.WinApp.Compartilhado;

namespace eAgenda.WinApp.ModuloDespesa.ModuloCategoria
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
            int idSelecionado = tabelaCategorias.ObterRegistroSelecionado();

            Categoria categoriaSelecionada =
                repositorioCategoria.SelecionarPorId(idSelecionado);

            if (categoriaSelecionada == null)
            {
                MessageBox.Show(
                    "Não é possível realizar esta ação sem um registro selecionado.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            TelaCategoriaForm telaCategoria = new TelaCategoriaForm();

            telaCategoria.Categoria = categoriaSelecionada;

            DialogResult resultado = telaCategoria.ShowDialog();

            if (resultado != DialogResult.OK)
                return;

            Categoria categoriaEditada = telaCategoria.Categoria;

            repositorioCategoria.Editar(idSelecionado, categoriaEditada);

            CarregarCategorias();

            TelaPrincipalForm
                .Instancia
                .AtualizarRodape($"O registro \"{categoriaEditada.Titulo}\" foi editado com sucesso!");
        }

        public override void Excluir()
        {
            int idSelecionado = tabelaCategorias.ObterRegistroSelecionado();

            Categoria categoriaSelecionada =
                repositorioCategoria.SelecionarPorId(idSelecionado);

            if (categoriaSelecionada == null)
            {
                MessageBox.Show(
                    "Não é possível realizar esta ação sem um registro selecionado.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            DialogResult resposta = MessageBox.Show(
                $"Você deseja realmente excluir o registro \"{categoriaSelecionada.Titulo}\"?",
                "Confirmar Exclusão",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (resposta != DialogResult.Yes)
                return;

            repositorioCategoria.Excluir(idSelecionado);

            CarregarCategorias();

            TelaPrincipalForm
                .Instancia
                .AtualizarRodape($"O registro \"{categoriaSelecionada.Titulo}\" foi excluído com sucesso!");
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
