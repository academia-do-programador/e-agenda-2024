namespace eAgenda.Dominio.Compartilhado
{
    public interface IControladorFiltravel
    {
        string ToolTipFiltrar { get; }

        void Filtrar();
    }
}
