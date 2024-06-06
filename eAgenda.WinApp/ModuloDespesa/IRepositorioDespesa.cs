namespace eAgenda.WinApp.ModuloDespesa
{
    public interface IRepositorioDespesa
    {
        void Cadastrar(Despesa novaDespesa);
        bool Editar(int id, Despesa despesaEditada);
        bool Excluir(int id);
        Despesa SelecionarPorId(int idSelecionado);
        List<Despesa> SelecionarTodos();

        void AdicionarCategorias(Despesa despesa, List<Categoria> categorias);
        void AtualizarCategorias(Despesa despesaSelecionada, List<Categoria> categoriasSelecionadas, List<Categoria> categoriasDesmarcadas);
    }
}
