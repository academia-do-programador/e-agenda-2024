using eAgenda.ConsoleApp.Compartilhado;

namespace eAgenda.WinApp.ModuloCompromisso
{
    public class RepositorioCompromisso : RepositorioBase<Compromisso>
    {
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
