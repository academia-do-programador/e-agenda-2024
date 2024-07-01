using eAgenda.Dominio.ModuloCategoria;
using eAgenda.Infra.Arquivos.Compartilhado;

namespace eAgenda.Infra.Arquivos.ModuloCategoria
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
