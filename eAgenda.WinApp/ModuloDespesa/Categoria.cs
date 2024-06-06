using eAgenda.ConsoleApp.Compartilhado;

namespace eAgenda.WinApp.ModuloDespesa
{
    public class Categoria : EntidadeBase
    {
        public string Titulo { get; set; }

        public List<Despesa> Despesas = new List<Despesa>();

        public Categoria()
        {

        }

        public Categoria(string titulo)
        {
            this.Titulo = titulo;
        }

        public void RegistrarDespesa(Despesa despesa)
        {
            if (Despesas.Any(d => d.Id == despesa.Id))
                return;

            Despesas.Add(despesa);

            despesa.AtribuirCategoria(this);
        }

        public void RemoverDespesa(Despesa despesa)
        {
            if (!Despesas.Any(d => d.Id == despesa.Id))
                return;

            Despesa despesaSelecionada = Despesas.Find(d => d.Id == despesa.Id);

            Despesas.Remove(despesaSelecionada);

            despesa.RemoverCategoria(this);
        }

        public override void AtualizarRegistro(EntidadeBase novoRegistro)
        {
            Categoria categoriaAtualizada = (Categoria)novoRegistro;

            this.Titulo = categoriaAtualizada.Titulo;
        }

        public override List<string> Validar()
        {
            List<string> erros = new List<string>();

            if (string.IsNullOrEmpty(Titulo.Trim()))
                erros.Add("O campo \"título\" é obrigatório");

            return erros;
        }

        public override string ToString()
        {
            return Titulo;
        }
    }
}
