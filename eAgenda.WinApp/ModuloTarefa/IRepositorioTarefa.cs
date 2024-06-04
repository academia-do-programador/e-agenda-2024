namespace eAgenda.WinApp.ModuloTarefa
{
    public interface IRepositorioTarefa
    {
        void Cadastrar(Tarefa novoRegistro);
        bool Editar(int id, Tarefa novaEntidade);
        bool Excluir(int id);
        Tarefa SelecionarPorId(int id);
        List<Tarefa> SelecionarTodos();

        void AdicionarItens(Tarefa tarefaSelecionada, List<ItemTarefa> itens);
        void AtualizarItens(Tarefa tarefaSelecionada, List<ItemTarefa> itensPendentes, List<ItemTarefa> itensConcluidos);
    }
}
