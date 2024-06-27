using eAgenda.WinApp.ModuloDespesa.ModuloCategoria;
using Microsoft.Data.SqlClient;

namespace eAgenda.WinApp.ModuloDespesa
{
    public class RepositorioDespesaEmSql : IRepositorioDespesa
    {
        private string enderecoBanco;

        public RepositorioDespesaEmSql()
        {
            enderecoBanco = "Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=eAgendaDb;Integrated Security=True;Pooling=False";
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

        private const string sqlAdicionarCategoriaNaDespesa =
            @"INSERT INTO [TBDESPESA_TBCATEGORIA]
            (
                [DESPESA_ID],
                [CATEGORIA_ID]
            )
            VALUES
            (
                @DESPESA_ID,
                @CATEGORIA_ID
            )";

        private const string sqlSelecionarCategoriasDaDespesa =
            @"SELECT
                CAT.[ID],
                CAT.[TITULO]
            FROM
                [TBCATEGORIA] AS CAT INNER JOIN
                [TBDESPESA_TBCATEGORIA] AS DC
            ON
                CAT.[ID] = DC.[CATEGORIA_ID]
            WHERE
                DC.[DESPESA_ID] = @DESPESA_ID";

        private const string sqlRemoverCategoriaDaDespesa =
            @"DELETE FROM 
                [TBDESPESA_TBCATEGORIA]
            WHERE
                [CATEGORIA_ID] = @CATEGORIA_ID AND
                [DESPESA_ID] = @DESPESA_ID";
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

            RemoverCategorias(despesa, despesa.Categorias);

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

            if (despesa != null)
                CarregarCategorias(despesa);

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
            foreach (Categoria cat in categorias)
            {
                if (despesa.ContemCategoria(cat))
                    continue;

                despesa.AtribuirCategoria(cat);

                SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

                SqlCommand comandoInsercao = new SqlCommand(sqlAdicionarCategoriaNaDespesa, conexaoComBanco);

                comandoInsercao.Parameters.AddWithValue("DESPESA_ID", despesa.Id);
                comandoInsercao.Parameters.AddWithValue("CATEGORIA_ID", cat.Id);

                conexaoComBanco.Open();

                comandoInsercao.ExecuteNonQuery();

                conexaoComBanco.Close();
            }
        }

        public void AtualizarCategorias(Despesa despesaSelecionada, List<Categoria> categoriasSelecionadas, List<Categoria> categoriasDesmarcadas)
        {
            AdicionarCategorias(despesaSelecionada, categoriasSelecionadas);

            RemoverCategorias(despesaSelecionada, categoriasDesmarcadas);
        }

        private void RemoverCategorias(Despesa despesaSelecionada, List<Categoria> categoriasDesmarcadas)
        {
            for (int i = 0; i < categoriasDesmarcadas.Count; i++)
            {
                Categoria cat = categoriasDesmarcadas[i];

                despesaSelecionada.RemoverCategoria(cat);

                SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

                SqlCommand comandoExclusao = new SqlCommand(sqlRemoverCategoriaDaDespesa, conexaoComBanco);

                comandoExclusao.Parameters.AddWithValue("CATEGORIA_ID", cat.Id);
                comandoExclusao.Parameters.AddWithValue("DESPESA_ID", despesaSelecionada.Id);

                conexaoComBanco.Open();

                comandoExclusao.ExecuteNonQuery();

                conexaoComBanco.Close();
            }
        }

        private void CarregarCategorias(Despesa despesa)
        {
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoSelecao = new SqlCommand(sqlSelecionarCategoriasDaDespesa, conexaoComBanco);

            comandoSelecao.Parameters.AddWithValue("DESPESA_ID", despesa.Id);

            conexaoComBanco.Open();

            SqlDataReader leitorCategoria = comandoSelecao.ExecuteReader();

            while (leitorCategoria.Read())
            {
                Categoria categoria = ConverterParaCategoria(leitorCategoria);

                despesa.AtribuirCategoria(categoria);
            }

            conexaoComBanco.Close();
        }

        private void ConfigurarParametrosDespesa(Despesa despesa, SqlCommand comando)
        {
            comando.Parameters.AddWithValue("ID", despesa.Id);
            comando.Parameters.AddWithValue("DESCRICAO", despesa.Descricao);
            comando.Parameters.AddWithValue("VALOR", despesa.Valor);
            comando.Parameters.AddWithValue("DATA", despesa.Data);
            comando.Parameters.AddWithValue("FORMAPAGAMENTO", despesa.FormaPagamento);
        }

        private Despesa ConverterParaDespesa(SqlDataReader leitorDespesa)
        {
            int id = Convert.ToInt32(leitorDespesa["ID"]);
            string descricao = Convert.ToString(leitorDespesa["DESCRICAO"]);
            decimal valor = Convert.ToDecimal(leitorDespesa["VALOR"]);
            DateTime data = Convert.ToDateTime(leitorDespesa["DATA"]);
            FormaPagamentoEnum formaPgto = (FormaPagamentoEnum)leitorDespesa["FORMAPAGAMENTO"];

            Despesa despesa = new Despesa
            {
                Id = id,
                Descricao = descricao,
                Valor = valor,
                Data = data,
                FormaPagamento = formaPgto
            };

            return despesa;
        }

        private Categoria ConverterParaCategoria(SqlDataReader leitorCategoria)
        {
            int numero = Convert.ToInt32(leitorCategoria["ID"]);
            string titulo = Convert.ToString(leitorCategoria["TITULO"]);

            Categoria categoria = new Categoria
            {
                Id = numero,
                Titulo = titulo
            };

            return categoria;
        }
    }
}
