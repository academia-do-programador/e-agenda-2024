using eAgenda.WinApp.Compartilhado;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace eAgenda.WinApp.ModuloTarefa
{
    public class RepositorioTarefaEmArquivo : IRepositorioArquivo<Tarefa>, IRepositorioTarefa
    {
        private int contador = 1;

        private List<Tarefa> tarefas = new List<Tarefa>();

        private string caminho = $"C:\\temp\\eAgenda\\tarefas.bin";

        public RepositorioTarefaEmArquivo()
        {
            tarefas = DeserializarRegistros();
        }

        public void Cadastrar(Tarefa novoRegistro)
        {
            novoRegistro.Id = contador++;

            tarefas.Add(novoRegistro);

            SerializarRegistros();
        }

        public bool Editar(int id, Tarefa novaEntidade)
        {
            Tarefa registro = SelecionarPorId(id);

            if (registro == null)
                return false;

            registro.AtualizarRegistro(novaEntidade);

            SerializarRegistros();

            return true;
        }

        public bool Excluir(int id)
        {
            bool conseguiuRemover = tarefas.Remove(SelecionarPorId(id));

            if (!conseguiuRemover)
                return false;

            SerializarRegistros();

            return true;
        }

        public Tarefa SelecionarPorId(int id)
        {
            return tarefas.Find(t => t.Id == id);
        }

        public List<Tarefa> SelecionarTodos()
        {
            return tarefas;
        }

        public void AdicionarItens(Tarefa tarefaSelecionada, List<ItemTarefa> itens)
        {
            foreach (ItemTarefa item in itens)
                tarefaSelecionada.AdicionarItem(item);

            SerializarRegistros();
        }

        public void AtualizarItens(Tarefa tarefaSelecionada, List<ItemTarefa> itensPendentes, List<ItemTarefa> itensConcluidos)
        {
            foreach (ItemTarefa i in itensPendentes)
                tarefaSelecionada.MarcarPendente(i);

            foreach (ItemTarefa i in itensConcluidos)
                tarefaSelecionada.ConcluirItem(i);

            SerializarRegistros();
        }

        public void SerializarRegistros()
        {
            FileInfo file = new FileInfo(caminho);

            file.Directory.Create();

            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                ReferenceHandler = ReferenceHandler.Preserve
            };

            byte[] tarefasEmBytes = JsonSerializer.SerializeToUtf8Bytes(tarefas, options);

            File.WriteAllBytes(caminho, tarefasEmBytes);
        }

        public List<Tarefa> DeserializarRegistros()
        {
            FileInfo file = new FileInfo(caminho);

            if (!file.Exists)
                return new List<Tarefa>();

            byte[] tarefasEmBytes = File.ReadAllBytes(caminho);

            MemoryStream stream = new MemoryStream(tarefasEmBytes);

            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                ReferenceHandler = ReferenceHandler.Preserve
            };

            List<Tarefa> tarefas = JsonSerializer.Deserialize<List<Tarefa>>(stream, options);

            return tarefas;
        }
    }
}
