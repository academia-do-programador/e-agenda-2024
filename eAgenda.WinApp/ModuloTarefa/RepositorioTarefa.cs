using eAgenda.ConsoleApp.Compartilhado;

namespace eAgenda.WinApp.ModuloTarefa
{
    public class RepositorioTarefa : RepositorioBase<Tarefa>
    {
        public void AdicionarItens(Tarefa tarefaSelecionada, List<ItemTarefa> itens)
        {
            foreach (ItemTarefa item in itens)
                tarefaSelecionada.AdicionarItem(item);
        }
    }
}
