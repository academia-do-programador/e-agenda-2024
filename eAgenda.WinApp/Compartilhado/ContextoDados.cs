using eAgenda.WinApp.ModuloCompromisso;
using eAgenda.WinApp.ModuloContato;
using eAgenda.WinApp.ModuloDespesa;
using eAgenda.WinApp.ModuloTarefa;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace eAgenda.WinApp.Compartilhado
{
    public class ContextoDados
    {
        public List<Contato> Contatos { get; set; }
        public List<Compromisso> Compromissos { get; set; }
        public List<Tarefa> Tarefas { get; set; }
        public List<Categoria> Categorias { get; set; }
        public List<Despesa> Despesas { get; set; }

        private string caminho = $"C:\\temp\\eAgenda\\dados.json";

        public ContextoDados()
        {
            Contatos = new List<Contato>();

            Compromissos = new List<Compromisso>();

            Tarefas = new List<Tarefa>();

            Categorias = new List<Categoria>();

            Despesas = new List<Despesa>();
        }

        public ContextoDados(bool carregarDados) : this()
        {
            if (carregarDados)
                CarregarDados();
        }

        public void Gravar()
        {
            FileInfo arquivo = new FileInfo(caminho);

            arquivo.Directory.Create();

            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                WriteIndented = true,
                ReferenceHandler = ReferenceHandler.Preserve
            };

            byte[] registrosEmBytes = JsonSerializer.SerializeToUtf8Bytes(this, options);

            File.WriteAllBytes(caminho, registrosEmBytes);
        }

        protected void CarregarDados()
        {
            FileInfo arquivo = new FileInfo(caminho);

            if (!arquivo.Exists)
                return;

            byte[] registrosEmBytes = File.ReadAllBytes(caminho);

            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                ReferenceHandler = ReferenceHandler.Preserve
            };

            ContextoDados ctx = JsonSerializer.Deserialize<ContextoDados>(registrosEmBytes, options);

            if (ctx == null) return;

            Contatos = ctx.Contatos;

            Compromissos = ctx.Compromissos;

            Tarefas = ctx.Tarefas;

            Categorias = ctx.Categorias;

            Despesas = ctx.Despesas;
        }
    }
}
