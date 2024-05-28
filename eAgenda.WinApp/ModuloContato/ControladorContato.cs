using eAgenda.WinApp.Compartilhado;

namespace eAgenda.WinApp.ModuloContato
{
    public class ControladorContato : ControladorBase
    {
        private RepositorioContato repositorioContato;
        private TabelaContatoControl tabelaContato;

        public ControladorContato(RepositorioContato repositorio)
        {
            repositorioContato = repositorio;
        }

        public override string TipoCadastro { get { return "Contatos"; } }

        public override string ToolTipAdicionar { get { return "Cadastrar um novo contato"; } }

        public override string ToolTipEditar { get { return "Editar um contato existente"; } }

        public override string ToolTipExcluir { get { return "Excluir um contato existente"; } }

        public override void Adicionar()
        {
            TelaContatoForm telaContato = new TelaContatoForm();

            DialogResult resultado = telaContato.ShowDialog();

            // guardas = bloquear momentos em que a aplicação toma um "caminho triste"
            if (resultado != DialogResult.OK)
                return;

            Contato novoContato = telaContato.Contato;

            repositorioContato.Cadastrar(novoContato);

            CarregarContatos();

            TelaPrincipalForm
                .Instancia
                .AtualizarRodape($"O registro \"{novoContato.Nome}\" foi criado com sucesso!");
        }

        public override void Editar()
        {
            TelaContatoForm telaContato = new TelaContatoForm();

            int idSelecionado = tabelaContato.ObterRegistroSelecionado();

            Contato contatoSelecionado =
                repositorioContato.SelecionarPorId(idSelecionado);

            if (contatoSelecionado == null)
            {
                MessageBox.Show(
                    "Não é possível realizar esta ação sem um registro selecionado.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            telaContato.Contato = contatoSelecionado;

            DialogResult resultado = telaContato.ShowDialog();

            if (resultado != DialogResult.OK)
                return;

            Contato contatoEditado = telaContato.Contato;

            repositorioContato.Editar(contatoSelecionado.Id, contatoEditado);

            CarregarContatos();

            TelaPrincipalForm
                .Instancia
                .AtualizarRodape($"O registro \"{contatoEditado.Nome}\" foi editado com sucesso!");
        }

        public override void Excluir()
        {
            int idSelecionado = tabelaContato.ObterRegistroSelecionado();

            Contato contatoSelecionado =
                repositorioContato.SelecionarPorId(idSelecionado);

            if (contatoSelecionado == null)
            {
                MessageBox.Show(
                    "Não é possível realizar esta ação sem um registro selecionado.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            DialogResult resposta = MessageBox.Show(
                $"Você deseja realmente excluir o registro \"{contatoSelecionado.Nome}\"?",
                "Confirmar Exclusão",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (resposta != DialogResult.Yes)
                return;

            repositorioContato.Excluir(contatoSelecionado.Id);

            CarregarContatos();

            TelaPrincipalForm
                .Instancia
                .AtualizarRodape($"O registro \"{contatoSelecionado.Nome}\" foi excluído com sucesso!");
        }

        private void CarregarContatos()
        {
            List<Contato> contatos = repositorioContato.SelecionarTodos();

            tabelaContato.AtualizarRegistros(contatos);
        }

        public override UserControl ObterListagem()
        {
            if (tabelaContato == null)
                tabelaContato = new TabelaContatoControl();

            CarregarContatos();

            return tabelaContato;
        }
    }
}
