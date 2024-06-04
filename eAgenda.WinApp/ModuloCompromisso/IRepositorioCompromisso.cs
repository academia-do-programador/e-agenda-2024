

namespace eAgenda.WinApp.ModuloCompromisso
{
    public interface IRepositorioCompromisso
    {
        void Cadastrar(Compromisso novoCompromisso);
        bool Editar(int id, Compromisso compromissoEditado);
        bool Excluir(int id);
        List<Compromisso> SelecionarCompromissosFuturos();
        List<Compromisso> SelecionarCompromissosPassados();
        List<Compromisso> SelecionarCompromissosPorPeriodo(DateTime dataInicio, DateTime dataTermino);
        List<Compromisso> SelecionarTodos();
        Compromisso SelecionarPorId(int idSelecionado);
    }
}
