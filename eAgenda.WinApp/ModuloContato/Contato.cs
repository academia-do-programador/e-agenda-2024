using eAgenda.ConsoleApp.Compartilhado;
using eAgenda.WinApp.Compartilhado;

namespace eAgenda.WinApp.ModuloContato
{
    public class Contato : EntidadeBase
    {
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Empresa { get; set; }
        public string Cargo { get; set; }

        public Contato(string nome, string telefone, string email, string empresa, string cargo)
        {
            Nome = nome;
            Telefone = telefone;
            Email = email;
            Empresa = empresa;
            Cargo = cargo;
        }

        public override List<string> Validar()
        {
            List<string> erros = new List<string>();

            if (string.IsNullOrEmpty(Nome.Trim()))
                erros.Add("O campo \"nome\" é obrigatório");

            if (string.IsNullOrEmpty(Email.Trim()))
                erros.Add("O campo \"email\" é obrigatório");

            if (string.IsNullOrEmpty(Telefone.Trim()))
                erros.Add("O campo \"telefone\" é obrigatório");

            if (string.IsNullOrEmpty(Cargo.Trim()))
                erros.Add("O campo \"cargo\" é obrigatório");

            if (string.IsNullOrEmpty(Empresa.Trim()))
                erros.Add("O campo \"empresa\" é obrigatório");

            return erros;
        }

        public override void AtualizarRegistro(EntidadeBase novoRegistro)
        {
            Contato atualizado = (Contato)novoRegistro;

            Nome = atualizado.Nome;
            Email = atualizado.Email;
            Telefone = atualizado.Telefone;
            Cargo = atualizado.Cargo;
            Empresa = atualizado.Empresa;
        }

        public override string ToString()
        {
            return Nome.ToTitleCase();
        }
    }
}
