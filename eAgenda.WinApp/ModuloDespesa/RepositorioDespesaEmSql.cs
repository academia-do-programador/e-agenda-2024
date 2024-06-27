using eAgenda.WinApp.ModuloDespesa.ModuloCategoria;
using Microsoft.Data.SqlClient;

namespace eAgenda.WinApp.ModuloDespesa
{
    public class RepositorioDespesaEmSql : IRepositorioDespesa
    {
        private string enderecoBanco;

        public RepositorioDespesaEmSql()
        {
            enderecoBanco = "Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=eAgendaTestDb;Integrated Security=True;Pooling=False";
        }

        #region Sql Queries
        private const string sqlInserir =
            @"INSERT INTO [TBDESPESA] 
                (
                    [DESCRICAO],
                    [VALOR],
                    [DATA],
                    [FORMAPAGAMENTO]
	            )
	            VALUES
                (
                    @DESCRICAO,
                    @VALOR,
                    @DATA,
                    @FORMAPAGAMENTO
                );SELECT SCOPE_IDENTITY();";

        private const string sqlEditar =
            @"UPDATE [TBDESPESA]	
		        SET
			        [DESCRICAO] = @DESCRICAO,
			        [VALOR] = @VALOR,
			        [DATA] = @DATA,
			        [FORMAPAGAMENTO] = @FORMAPAGAMENTO
		        WHERE
			        [ID] = @ID";

        private const string sqlExcluir =
            @"DELETE FROM [TBDESPESA]
		        WHERE
			        [ID] = @ID";

        private const string sqlSelecionarTodos =
            @"SELECT 
		            [ID], 
		            [DESCRICAO], 
		            [VALOR],
		            [DATA],
		            [FORMAPAGAMENTO]
	            FROM 
		            [TBDESPESA]";

        private const string sqlSelecionarPorId =
            @"SELECT 
		            [ID], 
		            [DESCRICAO], 
		            [VALOR],
		            [DATA],
		            [FORMAPAGAMENTO]
	            FROM 
		            [TBDESPESA]
		        WHERE
                    [ID] = @ID";
        #endregion

        public void Cadastrar(Despesa novaDespesa)
        {
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoInsercao = new SqlCommand(sqlInserir, conexaoComBanco);

            ConfigurarParametrosDespesa(novaDespesa, comandoInsercao);

            conexaoComBanco.Open();

            object id = comandoInsercao.ExecuteScalar();

            novaDespesa.Id = Convert.ToInt32(id);

            conexaoComBanco.Close();
        }

        public bool Editar(int id, Despesa despesaEditada)
        {
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoExclusao = new SqlCommand(sqlEditar, conexaoComBanco);

            despesaEditada.Id = id;

            ConfigurarParametrosDespesa(despesaEditada, comandoExclusao);

            conexaoComBanco.Open();

            int numeroRegistrosAfetados = comandoExclusao.ExecuteNonQuery();

            conexaoComBanco.Close();

            if (numeroRegistrosAfetados < 1)
                return false;

            return true;
        }

        public bool Excluir(int id)
        {
            Despesa despesa = SelecionarPorId(id);

            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoExclusao = new SqlCommand(sqlExcluir, conexaoComBanco);

            comandoExclusao.Parameters.AddWithValue("ID", despesa.Id);

            conexaoComBanco.Open();

            int numeroRegistrosExcluidos = comandoExclusao.ExecuteNonQuery();

            conexaoComBanco.Close();

            if (numeroRegistrosExcluidos < 1)
                return false;

            return true;
        }

        public Despesa SelecionarPorId(int idSelecionado)
        {
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoSelecao = new SqlCommand(sqlSelecionarPorId, conexaoComBanco);

            comandoSelecao.Parameters.AddWithValue("ID", idSelecionado);

            conexaoComBanco.Open();

            SqlDataReader leitorDespesa = comandoSelecao.ExecuteReader();

            Despesa despesa = null;

            if (leitorDespesa.Read())
                despesa = ConverterParaDespesa(leitorDespesa);

            conexaoComBanco.Close();

            return despesa;
        }

        public List<Despesa> SelecionarTodos()
        {
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoSelecao = new SqlCommand(sqlSelecionarTodos, conexaoComBanco);

            conexaoComBanco.Open();

            SqlDataReader leitorDespesa = comandoSelecao.ExecuteReader();

            List<Despesa> despesas = new List<Despesa>();

            while (leitorDespesa.Read())
            {
                Despesa despesa = ConverterParaDespesa(leitorDespesa);

                despesas.Add(despesa);
            }

            conexaoComBanco.Close();

            return despesas;
        }

        public void AdicionarCategorias(Despesa despesa, List<Categoria> categorias)
        {
            throw new NotImplementedException();
        }

        public void AtualizarCategorias(Despesa despesaSelecionada, List<Categoria> categoriasSelecionadas, List<Categoria> categoriasDesmarcadas)
        {
            throw new NotImplementedException();
        }

        private Despesa ConverterParaDespesa(SqlDataReader leitorDespesa)
        {
            var numero = Convert.ToInt32(leitorDespesa["ID"]);
            var descricao = Convert.ToString(leitorDespesa["DESCRICAO"]);
            var valor = Convert.ToDecimal(leitorDespesa["VALOR"]);
            var data = Convert.ToDateTime(leitorDespesa["DATA"]);
            var formaPgto = (FormaPagamentoEnum)leitorDespesa["FORMAPAGAMENTO"];

            var despesa = new Despesa
            {
                Id = numero,
                Descricao = descricao,
                Valor = valor,
                Data = data,
                FormaPagamento = formaPgto
            };

            return despesa;
        }

        private void ConfigurarParametrosDespesa(Despesa despesa, SqlCommand comando)
        {
            comando.Parameters.AddWithValue("ID", despesa.Id);
            comando.Parameters.AddWithValue("DESCRICAO", despesa.Descricao);
            comando.Parameters.AddWithValue("VALOR", despesa.Valor);
            comando.Parameters.AddWithValue("DATA", despesa.Data);
            comando.Parameters.AddWithValue("FORMAPAGAMENTO", despesa.FormaPagamento);
        }
    }
}
