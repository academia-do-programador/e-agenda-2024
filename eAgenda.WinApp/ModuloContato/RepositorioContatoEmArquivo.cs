
using eAgenda.WinApp.Compartilhado;
using eAgenda.WinApp.ModuloCompromisso;

namespace eAgenda.WinApp.ModuloContato
{
    public class RepositorioContatoEmArquivo : RepositorioBaseEmArquivo<Contato>, IRepositorioContato
    {
        public RepositorioContatoEmArquivo(ContextoDados contexto) : base(contexto)
        {
            if (contexto.Contatos.Any())
                contadorId = contexto.Contatos.Max(c => c.Id) + 1;
        }

        protected override List<Contato> ObterRegistros()
        {
            return contexto.Contatos;
        }

        public override bool Excluir(int id)
        {
            Contato contato = SelecionarPorId(id);

            List<Compromisso> compromissosRelacionados =
                contexto.Compromissos.FindAll(c => c.Contato.Id == contato.Id);

            foreach (Compromisso c in compromissosRelacionados)
                c.Contato = null;

            return base.Excluir(id);
        }
    }
}
