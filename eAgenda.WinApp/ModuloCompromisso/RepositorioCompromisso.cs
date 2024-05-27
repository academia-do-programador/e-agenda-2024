using eAgenda.ConsoleApp.Compartilhado;

namespace eAgenda.WinApp.ModuloCompromisso
{
    public class RepositorioCompromisso : RepositorioBase<Compromisso>
    {
        public List<Compromisso> SelecionarCompromissosFuturos()
        {
            List<Compromisso> compromissosFuturos = new List<Compromisso>();

            foreach (Compromisso compromisso in registros)
            {
                if (compromisso.Data >= DateTime.Today)
                    compromissosFuturos.Add(compromisso);
            }

            return compromissosFuturos;
        }

        public List<Compromisso> SelecionarCompromissosPassados()
        {
            List<Compromisso> compromissosPassados = new List<Compromisso>();

            foreach (Compromisso compromisso in registros)
            {
                if (compromisso.Data < DateTime.Today)
                    compromissosPassados.Add(compromisso);
            }

            return compromissosPassados;
        }

        public List<Compromisso> SelecionarCompromissosPorPeriodo(DateTime dataInicio, DateTime dataTermino)
        {
            List<Compromisso> compromissosDoPeriodo = new List<Compromisso>();

            foreach (Compromisso c in registros)
            {
                if (c.Data >= dataInicio && c.Data <= dataTermino)
                    compromissosDoPeriodo.Add(c);
            }

            return compromissosDoPeriodo;
        }
    }
}
