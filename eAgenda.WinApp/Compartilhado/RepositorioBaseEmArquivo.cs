using eAgenda.ConsoleApp.Compartilhado;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace eAgenda.WinApp.Compartilhado
{
    public class RepositorioBaseEmArquivo<T> where T : EntidadeBase
    {
        protected List<T> registros = new List<T>();

        protected int contadorId = 1;

        private string caminho = string.Empty;

        public RepositorioBaseEmArquivo(string nomeArquivo)
        {
            caminho = $"C:\\temp\\eAgenda\\{nomeArquivo}";

            registros = DeserializarRegistros();
        }

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

            SerializarRegistros();

            return true;
        }

        public bool Excluir(int id)
        {
            bool conseguiuRemover = registros.Remove(SelecionarPorId(id));

            if (!conseguiuRemover)
                return false;

            SerializarRegistros();

            return true;
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

        public void CadastrarVarios(List<T> registrosAdicionados)
        {
            foreach (T registro in registrosAdicionados)
            {
                registro.Id = contadorId++;
                registros.Add(registro);
            }

            SerializarRegistros();
        }

        protected void SerializarRegistros()
        {
            FileInfo file = new FileInfo(caminho);

            file.Directory.Create();

            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                ReferenceHandler = ReferenceHandler.Preserve,
                WriteIndented = true
            };

            byte[] registrosEmBytes = JsonSerializer.SerializeToUtf8Bytes(registros, options);

            File.WriteAllBytes(caminho, registrosEmBytes);
        }

        protected List<T> DeserializarRegistros()
        {
            FileInfo file = new FileInfo(caminho);

            if (!file.Exists)
                return new List<T>();

            byte[] registrosEmBytes = File.ReadAllBytes(caminho);

            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                ReferenceHandler = ReferenceHandler.Preserve
            };

            List<T> registros = JsonSerializer.Deserialize<List<T>>(registrosEmBytes, options);

            return registros;
        }
    }
}
