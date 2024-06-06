using eAgenda.WinApp.Compartilhado;

namespace eAgenda.WinApp.ModuloTarefa
{
    public class RepositorioTarefaEmArquivo : RepositorioBaseEmArquivo<Tarefa>, IRepositorioTarefa
    {
        public RepositorioTarefaEmArquivo(ContextoDados contexto) : base(contexto)
        {
            if (contexto.Tarefas.Any())
                contadorId = contexto.Tarefas.Max(c => c.Id) + 1;
        }

        protected override List<Tarefa> ObterRegistros()
        {
            return contexto.Tarefas;
        }

        public void AdicionarItens(Tarefa tarefaSelecionada, List<ItemTarefa> itens)
        {
            foreach (ItemTarefa item in itens)
                tarefaSelecionada.AdicionarItem(item);

            contexto.Gravar();
        }

        public void AtualizarItens(Tarefa tarefaSelecionada, List<ItemTarefa> itensPendentes, List<ItemTarefa> itensConcluidos)
        {
            foreach (ItemTarefa i in itensPendentes)
                tarefaSelecionada.MarcarPendente(i);

            foreach (ItemTarefa i in itensConcluidos)
                tarefaSelecionada.ConcluirItem(i);

            contexto.Gravar();
        }
    }
}
