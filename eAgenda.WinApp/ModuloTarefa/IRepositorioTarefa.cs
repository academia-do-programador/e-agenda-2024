namespace eAgenda.WinApp.ModuloTarefa
{
    public interface IRepositorioTarefa
    {
        void Cadastrar(Tarefa novaTarefa);
        bool Editar(int id, Tarefa tarefaEditada);
        bool Excluir(int id);
        Tarefa SelecionarPorId(int idSelecionado);
        List<Tarefa> SelecionarTodos();
        void AdicionarItens(Tarefa tarefaSelecionada, List<ItemTarefa> itens);
        void AtualizarItens(Tarefa tarefaSelecionada, List<ItemTarefa> itensPendentes, List<ItemTarefa> itensConcluidos);
    }
}
