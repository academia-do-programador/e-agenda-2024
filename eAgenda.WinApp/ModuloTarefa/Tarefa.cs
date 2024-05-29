using eAgenda.ConsoleApp.Compartilhado;

namespace eAgenda.WinApp.ModuloTarefa
{
    public class Tarefa : EntidadeBase
    {
        public string Titulo { get; set; }
        public PrioridadeTarefaEnum Prioridade { get; set; }
        public DateTime DataCriacao { get; set; }

        public Tarefa(string titulo, PrioridadeTarefaEnum prioridade)
        {
            Titulo = titulo;
            Prioridade = prioridade;
            DataCriacao = DateTime.Now;
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
