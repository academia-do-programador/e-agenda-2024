using eAgenda.ConsoleApp.Compartilhado;

namespace eAgenda.WinApp.Compartilhado
{
    public abstract class RepositorioBaseEmArquivo<T> where T : EntidadeBase
    {
        protected abstract List<T> ObterRegistros();

        protected int contadorId = 1;

        protected ContextoDados contexto;

        public RepositorioBaseEmArquivo(ContextoDados contexto)
        {
            this.contexto = contexto;
        }

        public void Cadastrar(T novoRegistro)
        {
            novoRegistro.Id = contadorId++;

            ObterRegistros().Add(novoRegistro);

            contexto.Gravar();
        }

        public bool Editar(int id, T novaEntidade)
        {
            T registro = SelecionarPorId(id);

            if (registro == null)
                return false;

            registro.AtualizarRegistro(novaEntidade);

            contexto.Gravar();

            return true;
        }

        public virtual bool Excluir(int id)
        {
            bool conseguiuExcluir = ObterRegistros().Remove(SelecionarPorId(id));

            if (!conseguiuExcluir)
                return false;

            contexto.Gravar();

            return true;
        }

        public List<T> SelecionarTodos()
        {
            return ObterRegistros();
        }

        public T SelecionarPorId(int id)
        {
            return ObterRegistros().Find(x => x.Id == id);
        }

        public bool Existe(int id)
        {
            return ObterRegistros().Any(x => x.Id == id);
        }
    }
}
