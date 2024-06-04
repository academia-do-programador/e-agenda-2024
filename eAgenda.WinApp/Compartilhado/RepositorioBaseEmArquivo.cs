using eAgenda.ConsoleApp.Compartilhado;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace eAgenda.WinApp.Compartilhado
{
    public class RepositorioBaseEmArquivo<T> where T : EntidadeBase
    {
        protected List<T> registros = new List<T>();

        protected int contadorId = 1;

        public void Cadastrar(T novoRegistro)
        {
            novoRegistro.Id = contadorId++;

            registros.Add(novoRegistro);

            SerializarRegistros();
        }

        public bool Editar(int id, T novaEntidade)
        {
            T registro = SelecionarPorId(id);

            if (registro == null)
                return false;

            registro.AtualizarRegistro(novaEntidade);

            return true;
        }

        public bool Excluir(int id)
        {
            return registros.Remove(SelecionarPorId(id));
        }

        public List<T> SelecionarTodos()
        {
            return registros;
        }

        public T SelecionarPorId(int id)
        {
            return registros.Find(x => x.Id == id);
        }

        public bool Existe(int id)
        {
            return registros.Any(x => x.Id == id);
        }

        protected void SerializarRegistros()
        {
            FileInfo arquivo = new FileInfo($"C:\\temp\\eAgenda\\contatos.json");

            arquivo.Directory.Create();

            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                WriteIndented = true,
                ReferenceHandler = ReferenceHandler.Preserve
            };

            byte[] registrosEmBytes = JsonSerializer.SerializeToUtf8Bytes(registros, options);

            File.WriteAllBytes($"C:\\temp\\eAgenda\\contatos.json", registrosEmBytes);
        }
    }
}
