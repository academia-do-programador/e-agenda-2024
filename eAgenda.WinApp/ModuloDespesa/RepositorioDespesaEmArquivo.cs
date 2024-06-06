using eAgenda.WinApp.Compartilhado;

namespace eAgenda.WinApp.ModuloDespesa
{
    public class RepositorioDespesaEmArquivo : RepositorioBaseEmArquivo<Despesa>, IRepositorioDespesa
    {
        public RepositorioDespesaEmArquivo(ContextoDados contexto) : base(contexto)
        {
        }

        public void AdicionarCategorias(Despesa despesa, List<Categoria> categorias)
        {
            foreach (Categoria categoria in categorias)
            {
                despesa.AtribuirCategoria(categoria);
                categoria.RegistrarDespesa(despesa);
            }

            contexto.Gravar();
        }

        public void AtualizarCategorias(Despesa despesaSelecionada, List<Categoria> categoriasSelecionadas, List<Categoria> categoriasDesmarcadas)
        {
            foreach (Categoria categoria in categoriasSelecionadas)
                despesaSelecionada.AtribuirCategoria(categoria);

            foreach (Categoria categoria in categoriasDesmarcadas)
                despesaSelecionada.RemoverCategoria(categoria);

            contexto.Gravar();
        }

        protected override List<Despesa> ObterRegistros()
        {
            return contexto.Despesas;
        }
    }
}
