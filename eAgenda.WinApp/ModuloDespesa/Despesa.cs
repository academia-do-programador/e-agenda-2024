using eAgenda.ConsoleApp.Compartilhado;

namespace eAgenda.WinApp.ModuloDespesa
{
    public class Despesa : EntidadeBase
    {
        public string Descricao { get; set; }

        public decimal Valor { get; set; }

        public DateTime Data { get; set; }

        public FormaPagamentoEnum FormaPagamento { get; set; }

        public List<Categoria> Categorias { get; set; } = new List<Categoria>();

        public Despesa()
        {
        }

        public Despesa(string descricao, decimal valor, DateTime data, FormaPagamentoEnum formaPagamento)
        {
            Descricao = descricao;
            Valor = valor;
            Data = data;
            FormaPagamento = formaPagamento;
        }

        public override void AtualizarRegistro(EntidadeBase novoRegistro)
        {
            throw new NotImplementedException();
        }

        public override List<string> Validar()
        {
            return new List<string>();
        }

        public void AtribuirCategoria(Categoria categoria)
        {
            if (Categorias.Any(c => c.Id == categoria.Id))
                return;

            Categorias.Add(categoria);

            categoria.RegistrarDespesa(this);
        }
    }
}
