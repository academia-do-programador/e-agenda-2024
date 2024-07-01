using eAgenda.Dominio.ModuloContato;
using eAgenda.Infra.Sql.ModuloContato;

namespace eAgenda.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Contato contato = new Contato()
            {
                Nome = "Alexandre Rech",
                Email = "rech@gmail.com",
                Telefone = "49 91222-3333",
                Cargo = "CEO",
                Empresa = "Academia do Programador"
            };

            RepositorioContatoEmSql repositorioContato =
                new RepositorioContatoEmSql();

            List<Contato> contatos = repositorioContato.SelecionarTodos();

            foreach (var c in contatos)
                Console.WriteLine(c.ToString());

            Console.ReadLine();
        }
    }
}
