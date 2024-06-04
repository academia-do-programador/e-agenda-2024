
namespace eAgenda.WinApp.ModuloContato
{
    public interface IRepositorioContato
    {
        void Cadastrar(Contato novoContato);
        bool Editar(int id, Contato contatoEditado);
        bool Excluir(int id);
        Contato SelecionarPorId(int idSelecionado);
        List<Contato> SelecionarTodos();
    }
}
