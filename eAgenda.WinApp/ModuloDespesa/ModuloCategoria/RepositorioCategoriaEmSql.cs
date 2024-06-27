using Microsoft.Data.SqlClient;

namespace eAgenda.WinApp.ModuloDespesa.ModuloCategoria
{
    public class RepositorioCategoriaEmSql
    {
        private string enderecoBanco;

        public RepositorioCategoriaEmSql()
        {
            enderecoBanco = "Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=eAgendaDb;Integrated Security=True;Pooling=False";
        }

        #region Sql Queries
        private const string sqlInserir =
            @"INSERT INTO [TBCATEGORIA] 
                (
                    [TITULO]    
                )                
	            VALUES
                (
                    @TITULO
                );SELECT SCOPE_IDENTITY();";

        private const string sqlEditar =
            @"UPDATE [TBCATEGORIA]	
		        SET
			        [TITULO] = @TITULO 
		        WHERE
			        [ID] = @ID";

        private const string sqlExcluir =
            @"DELETE FROM [TBCATEGORIA]
		        WHERE
			        [ID] = @ID";

        private const string sqlSelecionarTodos =
            @"SELECT 
		            [ID], 
		            [TITULO] 
	            FROM 
		            [TBCATEGORIA]";

        private const string sqlSelecionarPorId =
            @"SELECT 
		            [ID], 
		            [TITULO]  
	            FROM 
		            [TBCATEGORIA]
		        WHERE
                    [ID] = @ID";
        #endregion

        public void Cadastrar(Categoria novaCategoria)
        {
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoInsercao = new SqlCommand(sqlInserir, conexaoComBanco);

            ConfigurarParametrosCategoria(novaCategoria, comandoInsercao);

            conexaoComBanco.Open();

            var id = comandoInsercao.ExecuteScalar();

            novaCategoria.Id = Convert.ToInt32(id);

            conexaoComBanco.Close();
        }

        public bool Editar(int id, Categoria categoriaEditada)
        {
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoExclusao = new SqlCommand(sqlEditar, conexaoComBanco);

            categoriaEditada.Id = id;

            ConfigurarParametrosCategoria(categoriaEditada, comandoExclusao);

            conexaoComBanco.Open();

            int numeroRegistrosAfetados = comandoExclusao.ExecuteNonQuery();

            conexaoComBanco.Close();

            if (numeroRegistrosAfetados < 1)
                return false;

            return true;
        }

        public bool Excluir(int id)
        {
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoExclusao = new SqlCommand(sqlExcluir, conexaoComBanco);

            comandoExclusao.Parameters.AddWithValue("ID", id);

            conexaoComBanco.Open();

            int numeroRegistrosExcluidos = comandoExclusao.ExecuteNonQuery();

            conexaoComBanco.Close();

            if (numeroRegistrosExcluidos < 1)
                return false;

            return true;
        }

        public Categoria SelecionarPorId(int idSelecionado)
        {
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoSelecao = new SqlCommand(sqlSelecionarPorId, conexaoComBanco);

            comandoSelecao.Parameters.AddWithValue("ID", idSelecionado);

            conexaoComBanco.Open();

            SqlDataReader leitorCategoria = comandoSelecao.ExecuteReader();

            Categoria categoria = null;

            if (leitorCategoria.Read())
                categoria = ConverterParaCategoria(leitorCategoria);

            conexaoComBanco.Close();

            return categoria;
        }

        public List<Categoria> SelecionarTodos()
        {
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoSelecao = new SqlCommand(sqlSelecionarTodos, conexaoComBanco);

            conexaoComBanco.Open();

            SqlDataReader leitorCategoria = comandoSelecao.ExecuteReader();

            List<Categoria> categorias = new List<Categoria>();

            while (leitorCategoria.Read())
            {
                Categoria categoria = ConverterParaCategoria(leitorCategoria);

                categorias.Add(categoria);
            }

            conexaoComBanco.Close();

            return categorias;
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

        private void ConfigurarParametrosCategoria(Categoria categoria, SqlCommand comando)
        {
            comando.Parameters.AddWithValue("ID", categoria.Id);
            comando.Parameters.AddWithValue("TITULO", categoria.Titulo);
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
    }
}
