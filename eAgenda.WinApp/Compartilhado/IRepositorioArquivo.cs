using eAgenda.ConsoleApp.Compartilhado;

namespace eAgenda.WinApp.Compartilhado
{
    public interface IRepositorioArquivo<T> where T : EntidadeBase
    {
        void SerializarRegistros();
        List<T> DeserializarRegistros();
    }
}
