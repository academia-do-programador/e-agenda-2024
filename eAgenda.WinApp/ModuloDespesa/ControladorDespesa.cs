using eAgenda.WinApp.Compartilhado;

namespace eAgenda.WinApp.ModuloDespesa
{
    public class ControladorDespesa : ControladorBase
    {
        private IRepositorioDespesa repositorioDespesa;
        private TabelaDespesaControl tabelaDespesas;

        public override string TipoCadastro { get { return "Despesas"; } }

        public override string ToolTipAdicionar { get { return "Cadastrar nova despesa"; } }

        public override string ToolTipEditar { get { return "Editar uma despesa existente"; } }

        public override string ToolTipExcluir { get { return "Excluír uma despesa existente"; } }

        public ControladorDespesa(IRepositorioDespesa repositorioDespesa)
        {
            this.repositorioDespesa = repositorioDespesa;
        }

        public override void Adicionar()
        {
            throw new NotImplementedException();
        }

        public override void Editar()
        {
            throw new NotImplementedException();
        }

        public override void Excluir()
        {
            throw new NotImplementedException();
        }

        public override UserControl ObterListagem()
        {
            if (tabelaDespesas == null)
                tabelaDespesas = new TabelaDespesaControl();

            CarregarDespesas();

            return tabelaDespesas;
        }

        private void CarregarDespesas()
        {
            List<Despesa> Categorias = repositorioDespesa.SelecionarTodos();

            tabelaDespesas.AtualizarRegistros(Categorias);
        }
    }
}
