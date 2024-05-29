namespace eAgenda.WinApp.Compartilhado
{
    public interface IControladorSubItens
    {
        string ToolTipAdicionarItens { get; }
        string ToolTipConcluirItens { get; }
        void AdicionarItens();
        void AtualizarItens();
    }
}
