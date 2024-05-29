using eAgenda.WinApp.Compartilhado;

namespace eAgenda.WinApp.ModuloTarefa
{
    public class ControladorTarefa : ControladorBase
    {
        private TabelaTarefaControl listTarefas;

        private RepositorioTarefa repositorioTarefa;

        public override string TipoCadastro { get { return "Tarefas"; } }

        public override string ToolTipAdicionar { get { return "Cadastrar uma nova tarefa"; } }

        public override string ToolTipEditar { get { return "Editar uma tarefa existente"; } }

        public override string ToolTipExcluir { get { return "Excluir uma tarefa existente"; } }

        public ControladorTarefa(RepositorioTarefa repositorioTarefa)
        {
            this.repositorioTarefa = repositorioTarefa;
        }

        public override void Adicionar()
        {
            throw new NotImplementedException();
        }

        public override void Editar()
        {
            throw new NotImplementedException();
        }

        public override void Excluir()
        {
            throw new NotImplementedException();
        }

        private void CarregarTarefas()
        {
            List<Tarefa> contatos = repositorioTarefa.SelecionarTodos();

            listTarefas.AtualizarRegistros(contatos);
        }

        public override UserControl ObterListagem()
        {
            if (listTarefas == null)
                listTarefas = new TabelaTarefaControl();

            CarregarTarefas();

            return listTarefas;
        }
    }
}
