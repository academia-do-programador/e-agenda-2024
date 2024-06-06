namespace eAgenda.WinApp.ModuloDespesa
{
    public interface IRepositorioCategoria
    {
        void Cadastrar(Categoria novaCategoria);
        bool Editar(int id, Categoria categoriaEditada);
        bool Excluir(int id);
        Categoria SelecionarPorId(int idSelecionado);
        List<Categoria> SelecionarTodos();
    }
}
