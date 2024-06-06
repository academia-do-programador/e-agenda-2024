using eAgenda.ConsoleApp.Compartilhado;

namespace eAgenda.WinApp.ModuloDespesa
{
    public class Categoria : EntidadeBase
    {
        public string Titulo { get; set; }

        public Categoria()
        {

        }

        public Categoria(string titulo)
        {
            this.Titulo = titulo;
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
    }
}
