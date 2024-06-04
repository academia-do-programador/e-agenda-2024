using eAgenda.WinApp.Compartilhado;

namespace eAgenda.WinApp.ModuloCompromisso
{
    public class RepositorioCompromissoEmArquivo :
        RepositorioBaseEmArquivo<Compromisso>, IRepositorioCompromisso
    {
        public RepositorioCompromissoEmArquivo() : base("compromissos.json")
        {
        }

        public List<Compromisso> SelecionarCompromissosPorPeriodo(DateTime dataInicio, DateTime dataTermino)
        {
            return registros
                .FindAll(c => c.Data >= dataInicio && c.Data <= dataTermino);
        }

        public List<Compromisso> SelecionarCompromissosFuturos()
        {
            return registros.FindAll(c => c.Data >= DateTime.Today);
        }

        public List<Compromisso> SelecionarCompromissosPassados()
        {
            return registros.FindAll(c => c.Data < DateTime.Today);
        }
    }
}
