using eAgenda.WinApp.Compartilhado;

namespace eAgenda.WinApp.ModuloCompromisso
{
    public class RepositorioCompromissoEmArquivo : RepositorioBaseEmArquivo<Compromisso>, IRepositorioCompromisso
    {
        public RepositorioCompromissoEmArquivo(ContextoDados contexto) : base(contexto)
        {
            if (contexto.Compromissos.Any())
                contadorId = contexto.Compromissos.Max(c => c.Id) + 1;
        }

        protected override List<Compromisso> ObterRegistros()
        {
            return contexto.Compromissos;
        }

        public List<Compromisso> SelecionarCompromissosPorPeriodo(DateTime dataInicio, DateTime dataTermino)
        {
            return ObterRegistros()
                .FindAll(c => c.Data >= dataInicio && c.Data <= dataTermino);
        }

        public List<Compromisso> SelecionarCompromissosFuturos()
        {
            return ObterRegistros().FindAll(c => c.Data >= DateTime.Today);
        }

        public List<Compromisso> SelecionarCompromissosPassados()
        {
            return ObterRegistros().FindAll(c => c.Data < DateTime.Today);
        }
    }
}
