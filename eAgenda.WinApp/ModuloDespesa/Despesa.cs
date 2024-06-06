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
            Despesa despesaAtualizada = (Despesa)novoRegistro;

            this.Descricao = despesaAtualizada.Descricao;
            this.Valor = despesaAtualizada.Valor;
            this.Data = despesaAtualizada.Data;
            this.FormaPagamento = despesaAtualizada.FormaPagamento;
        }

        public override List<string> Validar()
        {
            List<string> erros = new List<string>();

            if (string.IsNullOrEmpty(Descricao.Trim()))
                erros.Add("O campo \"descricao\" é obrigatório");

            if (Valor < 0)
                erros.Add("O campo \"valor\" não pode ser menor que zero.");

            return erros;
        }

        public void AtribuirCategoria(Categoria categoria)
        {
            if (Categorias.Any(c => c.Id == categoria.Id))
                return;

            Categorias.Add(categoria);

            categoria.RegistrarDespesa(this);
        }

        public void RemoverCategoria(Categoria categoria)
        {
            if (!Categorias.Any(c => c.Id == categoria.Id))
                return;

            Categoria categoriaSelecionada = Categorias.Find(c => c.Id == categoria.Id);
            Categorias.Remove(categoriaSelecionada);

            categoria.RemoverDespesa(this);
        }
    }
}
