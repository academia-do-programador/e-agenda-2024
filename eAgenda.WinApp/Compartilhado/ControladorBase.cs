namespace eAgenda.WinApp.Compartilhado
{
    public abstract class ControladorBase
    {
        public abstract string TipoCadastro { get; }

        public abstract string ToolTipAdicionar { get; }
        public abstract string ToolTipEditar { get; }
        public abstract string ToolTipExcluir { get; }

        public abstract UserControl ObterListagem();

        public abstract void Adicionar();
        public abstract void Editar();
        public abstract void Excluir();
    }
}
