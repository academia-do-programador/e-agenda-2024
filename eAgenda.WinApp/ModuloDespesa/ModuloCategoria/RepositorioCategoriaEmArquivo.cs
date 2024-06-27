using eAgenda.WinApp.Compartilhado;

namespace eAgenda.WinApp.ModuloDespesa.ModuloCategoria
{
    public class RepositorioCategoriaEmArquivo : RepositorioBaseEmArquivo<Categoria>, IRepositorioCategoria
    {
        public RepositorioCategoriaEmArquivo(ContextoDados contexto) : base(contexto)
        {
        }

        protected override List<Categoria> ObterRegistros()
        {
            return contexto.Categorias;
        }
    }
}
