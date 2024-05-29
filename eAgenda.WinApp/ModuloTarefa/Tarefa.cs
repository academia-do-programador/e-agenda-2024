using eAgenda.ConsoleApp.Compartilhado;

namespace eAgenda.WinApp.ModuloTarefa
{
    public class Tarefa : EntidadeBase
    {
        public string Titulo { get; set; }
        public PrioridadeTarefaEnum Prioridade { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataConclusao { get; set; }

        public List<ItemTarefa> Itens { get; set; }

        public decimal PercentualConcluido
        {
            get
            {
                if (Itens.Count == 0)
                    return 0;

                int qtdConcluidos = Itens.Count(i => i.Concluido);

                decimal percentualBase = (qtdConcluidos / (decimal)Itens.Count) * 100;

                return Math.Round(percentualBase, 2);
            }
        }

        public Tarefa(string titulo, PrioridadeTarefaEnum prioridade)
        {
            Titulo = titulo;
            Prioridade = prioridade;
            DataCriacao = DateTime.Now;
            DataConclusao = DateTime.MinValue;

            Itens = new List<ItemTarefa>();
        }

        public bool AdicionarItem(ItemTarefa item)
        {
            if (Itens.Exists(i => i.Titulo == item.Titulo))
                return false;

            item.Tarefa = this;
            Itens.Add(item);

            DataConclusao = DateTime.MinValue;

            return true;
        }

        public void ConcluirItem(ItemTarefa item)
        {
            ItemTarefa itemTarefa = Itens.Find(i => i.Titulo == item.Titulo);

            if (itemTarefa == null)
                return;

            itemTarefa.Concluir();

            if (Itens.All(i => i.Concluido))
                DataConclusao = DateTime.Now;
        }

        public void MarcarPendente(ItemTarefa item)
        {
            ItemTarefa itemTarefa = Itens.Find(i => i.Titulo == item.Titulo);

            if (itemTarefa == null)
                return;

            itemTarefa.MarcarPendente();
        }

        public override void AtualizarRegistro(EntidadeBase novoRegistro)
        {
            Tarefa nova = (Tarefa)novoRegistro;

            Titulo = nova.Titulo;
            Prioridade = nova.Prioridade;
        }

        public override List<string> Validar()
        {
            List<string> erros = new List<string>();

            if (string.IsNullOrEmpty(Titulo.Trim()))
                erros.Add("O campo \"título\" é obrigatório");

            return erros;
        }
    }
}
