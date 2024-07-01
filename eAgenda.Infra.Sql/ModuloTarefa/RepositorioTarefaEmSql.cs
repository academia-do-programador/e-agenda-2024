using eAgenda.Dominio.ModuloTarefa;
using Microsoft.Data.SqlClient;

namespace eAgenda.Infra.Sql.ModuloTarefa
{
    public class RepositorioTarefaEmSql : IRepositorioTarefa
    {
        #region Queries
        private const string sqlInserir =
           @"INSERT INTO [TBTAREFA] 
		        (
			        [TITULO],
			        [DATACRIACAO],
			        [DATACONCLUSAO],
			        [PRIORIDADE],
			        [PERCENTUALCONCLUIDO]
		        )
		        VALUES
		        (
			        @TITULO,
			        @DATACRIACAO,
			        @DATACONCLUSAO,
			        @PRIORIDADE,
			        @PERCENTUALCONCLUIDO
		        );SELECT SCOPE_IDENTITY();";

        private const string sqlEditar =
            @"UPDATE [TBTAREFA]	
		        SET
			        [TITULO] = @TITULO,
			        [DATACRIACAO] = @DATACRIACAO,
			        [DATACONCLUSAO] = @DATACONCLUSAO,
			        [PRIORIDADE] = @PRIORIDADE,
			        [PERCENTUALCONCLUIDO] = @PERCENTUALCONCLUIDO
		        WHERE
			        [ID] = @ID";

        private const string sqlExcluir =
           @"DELETE FROM [TBTAREFA]
		        WHERE
			        [ID] = @ID";

        private const string sqlSelecionarPorId =
           @"SELECT
			        [ID],
			        [TITULO],
			        [PRIORIDADE],
			        [DATACRIACAO],
			        [DATACONCLUSAO],
			        [PERCENTUALCONCLUIDO]
	          FROM 
			        [TBTAREFA]
	          WHERE 
			        [ID] = @ID";

        private const string sqlSelecionarTodos =
          @"SELECT
			    [ID],
			    [TITULO],
			    [PRIORIDADE],
			    [DATACRIACAO],
			    [DATACONCLUSAO],
			    [PERCENTUALCONCLUIDO]
	        FROM 
			    [TBTAREFA]";

        private const string sqlInserirItensTarefa =
            @"INSERT INTO [DBO].[TBITEMTAREFA]
		        (
			        [TITULO],
			        [CONCLUIDO],
			        [TAREFA_ID]
		        )
		         VALUES
		        (
			        @TITULO,
			        @CONCLUIDO,
			        @TAREFA_ID		   
		        ); SELECT SCOPE_IDENTITY();";

        private const string sqlSelecionarItensTarefa =
            @"SELECT 
		        [ID],
		        [TITULO],
		        [CONCLUIDO],
		        [TAREFA_ID]
	          FROM 
		        [TBITEMTAREFA]
	          WHERE 
		        [TAREFA_ID] = @TAREFA_ID";

        private const string sqlEditarItemTarefa =
           @"UPDATE [TBITEMTAREFA]	
		        SET
			        [TITULO] = @TITULO,
			        [CONCLUIDO] = @CONCLUIDO
		        WHERE
			        [ID] = @ID";

        private const string sqlExcluirItensTarefa =
            @"DELETE FROM [TBITEMTAREFA]
		        WHERE
			        [TAREFA_ID] = @TAREFA_ID";
        #endregion

        private string enderecoBanco;

        public RepositorioTarefaEmSql()
        {
            enderecoBanco = "Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=eAgendaDb;Integrated Security=True;Pooling=False";
        }

        public void Cadastrar(Tarefa novaTarefa)
        {
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoInsercao = new SqlCommand(sqlInserir, conexaoComBanco);

            ConfigurarParametrosTarefa(novaTarefa, comandoInsercao);

            conexaoComBanco.Open();

            object id = comandoInsercao.ExecuteScalar();

            novaTarefa.Id = Convert.ToInt32(id);

            conexaoComBanco.Close();
        }

        public bool Editar(int id, Tarefa tarefaEditada)
        {
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoEdicao = new SqlCommand(sqlEditar, conexaoComBanco);

            tarefaEditada.Id = id;

            ConfigurarParametrosTarefa(tarefaEditada, comandoEdicao);

            conexaoComBanco.Open();

            int alteracoesRealizadas = comandoEdicao.ExecuteNonQuery();

            conexaoComBanco.Close();

            if (alteracoesRealizadas < 1)
                return false;

            return true;
        }

        public bool Excluir(int id)
        {
            ExcluirItensTarefa(id);

            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoExclusao = new SqlCommand(sqlExcluir, conexaoComBanco);

            comandoExclusao.Parameters.AddWithValue("ID", id);

            conexaoComBanco.Open();

            int numeroRegistrosExcluidos = comandoExclusao.ExecuteNonQuery();

            if (numeroRegistrosExcluidos < 1)
                return false;

            conexaoComBanco.Close();

            return true;
        }

        public Tarefa SelecionarPorId(int idSelecionado)
        {
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoSelecao = new SqlCommand(sqlSelecionarPorId, conexaoComBanco);

            comandoSelecao.Parameters.AddWithValue("ID", idSelecionado);

            conexaoComBanco.Open();

            SqlDataReader leitorTarefa = comandoSelecao.ExecuteReader();

            Tarefa tarefa = null;

            if (leitorTarefa.Read())
                tarefa = ConverterParaTarefa(leitorTarefa);

            if (tarefa != null)
                CarregarItensTarefa(tarefa);

            conexaoComBanco.Close();

            return tarefa;
        }

        public List<Tarefa> SelecionarTodos()
        {
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoSelecao = new SqlCommand(sqlSelecionarTodos, conexaoComBanco);

            conexaoComBanco.Open();

            SqlDataReader leitorTarefa = comandoSelecao.ExecuteReader();

            List<Tarefa> tarefas = new List<Tarefa>();

            while (leitorTarefa.Read())
            {
                Tarefa tarefa = ConverterParaTarefa(leitorTarefa);

                tarefas.Add(tarefa);
            }

            conexaoComBanco.Close();

            return tarefas;
        }

        public void AdicionarItens(Tarefa tarefaSelecionada, List<ItemTarefa> itens)
        {
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            conexaoComBanco.Open();

            foreach (ItemTarefa item in itens)
            {
                bool itemAdicionado = tarefaSelecionada.AdicionarItem(item);

                if (itemAdicionado)
                {
                    SqlCommand comandoInsercao = new SqlCommand(sqlInserirItensTarefa, conexaoComBanco);

                    ConfigurarParametrosItemTarefa(item, comandoInsercao);

                    object id = comandoInsercao.ExecuteScalar();

                    item.Id = Convert.ToInt32(id);
                }
            }

            Editar(tarefaSelecionada.Id, tarefaSelecionada);

            conexaoComBanco.Close();
        }

        public void AtualizarItens(Tarefa tarefaSelecionada, List<ItemTarefa> itensPendentes, List<ItemTarefa> itensConcluidos)
        {
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            conexaoComBanco.Open();

            foreach (ItemTarefa item in itensPendentes)
            {
                tarefaSelecionada.MarcarPendente(item);

                SqlCommand comandoEdicao = new SqlCommand(sqlEditarItemTarefa, conexaoComBanco);

                ConfigurarParametrosItemTarefa(item, comandoEdicao);

                comandoEdicao.ExecuteNonQuery();
            }

            foreach (ItemTarefa item in itensConcluidos)
            {
                tarefaSelecionada.ConcluirItem(item);

                SqlCommand comandoEdicao = new SqlCommand(sqlEditarItemTarefa, conexaoComBanco);

                ConfigurarParametrosItemTarefa(item, comandoEdicao);

                comandoEdicao.ExecuteNonQuery();
            }

            Editar(tarefaSelecionada.Id, tarefaSelecionada);

            conexaoComBanco.Close();
        }

        private void ConfigurarParametrosTarefa(Tarefa novaTarefa, SqlCommand comando)
        {
            object dataConclusao = novaTarefa.DataConclusao != DateTime.MinValue ?
                novaTarefa.DataConclusao : DBNull.Value;

            comando.Parameters.AddWithValue("ID", novaTarefa.Id);
            comando.Parameters.AddWithValue("TITULO", novaTarefa.Titulo);
            comando.Parameters.AddWithValue("PRIORIDADE", novaTarefa.Prioridade);
            comando.Parameters.AddWithValue("DATACRIACAO", novaTarefa.DataCriacao);
            comando.Parameters.AddWithValue("DATACONCLUSAO", dataConclusao);
            comando.Parameters.AddWithValue("PERCENTUALCONCLUIDO", novaTarefa.PercentualConcluido);
        }

        private Tarefa ConverterParaTarefa(SqlDataReader leitorTarefa)
        {
            int id = Convert.ToInt32(leitorTarefa["ID"]);

            string titulo = Convert.ToString(leitorTarefa["TITULO"]);

            PrioridadeTarefaEnum prioridade = (PrioridadeTarefaEnum)leitorTarefa["PRIORIDADE"];

            DateTime dataCriacao = Convert.ToDateTime(leitorTarefa["DATACRIACAO"]);

            DateTime dataConclusao = DateTime.MinValue;

            if (leitorTarefa["DATACONCLUSAO"] != DBNull.Value)
                dataConclusao = Convert.ToDateTime(leitorTarefa["DATACONCLUSAO"]);

            decimal percentual = Convert.ToDecimal(leitorTarefa["PERCENTUALCONCLUIDO"]);

            Tarefa tarefa = new Tarefa
            {
                Id = id,
                Titulo = titulo,
                DataCriacao = dataCriacao,
                DataConclusao = dataConclusao,
                Prioridade = prioridade,
                PercentualConcluido = percentual
            };

            return tarefa;
        }

        private void ConfigurarParametrosItemTarefa(ItemTarefa item, SqlCommand comandoInsercao)
        {
            comandoInsercao.Parameters.AddWithValue("ID", item.Id);
            comandoInsercao.Parameters.AddWithValue("TITULO", item.Titulo);
            comandoInsercao.Parameters.AddWithValue("CONCLUIDO", item.Concluido);
            comandoInsercao.Parameters.AddWithValue("TAREFA_ID", item.Tarefa.Id);
        }

        private ItemTarefa ConverterParaItemTarefa(SqlDataReader leitorItemTarefa)
        {
            int id = Convert.ToInt32(leitorItemTarefa["ID"]);
            string titulo = Convert.ToString(leitorItemTarefa["TITULO"]);
            bool concluido = Convert.ToBoolean(leitorItemTarefa["CONCLUIDO"]);

            ItemTarefa itemTarefa = new ItemTarefa
            {
                Id = id,
                Titulo = titulo,
                Concluido = concluido
            };

            return itemTarefa;
        }

        private void CarregarItensTarefa(Tarefa tarefa)
        {
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoSelecao =
                new SqlCommand(sqlSelecionarItensTarefa, conexaoComBanco);

            comandoSelecao.Parameters.AddWithValue("TAREFA_ID", tarefa.Id);

            conexaoComBanco.Open();

            SqlDataReader leitorItemTarefa = comandoSelecao.ExecuteReader();

            while (leitorItemTarefa.Read())
            {
                ItemTarefa itemTarefa = ConverterParaItemTarefa(leitorItemTarefa);

                tarefa.AdicionarItem(itemTarefa);
            }

            conexaoComBanco.Close();
        }

        private void ExcluirItensTarefa(int idTarefa)
        {
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoExclusao = new SqlCommand(sqlExcluirItensTarefa, conexaoComBanco);

            comandoExclusao.Parameters.AddWithValue("TAREFA_ID", idTarefa);

            conexaoComBanco.Open();

            comandoExclusao.ExecuteNonQuery();

            conexaoComBanco.Close();
        }
    }
}
