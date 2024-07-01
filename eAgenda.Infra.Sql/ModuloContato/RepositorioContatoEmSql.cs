using eAgenda.Dominio.ModuloContato;
using Microsoft.Data.SqlClient;

namespace eAgenda.Infra.Sql.ModuloContato
{
    public class RepositorioContatoEmSql : IRepositorioContato
    {
        private string enderecoBanco;

        public RepositorioContatoEmSql()
        {
            enderecoBanco = "Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=eAgendaDb;Integrated Security=True;Pooling=False";
        }

        public void Cadastrar(Contato novoContato)
        {
            string sqlInserir =
                @"INSERT INTO [TBCONTATO]
                    (
                        [NOME],
                        [EMAIL],
                        [TELEFONE],
                        [EMPRESA],
                        [CARGO]
                    )
                    VALUES
                    (
                        @NOME,
                        @EMAIL,
                        @TELEFONE,
                        @EMPRESA,
                        @CARGO
                    ); SELECT SCOPE_IDENTITY();";

            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoInsercao = new SqlCommand(sqlInserir, conexaoComBanco);

            ConfigurarParametrosContato(novoContato, comandoInsercao);

            conexaoComBanco.Open();

            object id = comandoInsercao.ExecuteScalar();

            novoContato.Id = Convert.ToInt32(id);

            conexaoComBanco.Close();
        }

        public bool Editar(int id, Contato contatoEditado)
        {
            string sqlEditar =
                @"UPDATE [TBCONTATO]	
		            SET
			            [NOME] = @NOME,
			            [EMAIL] = @EMAIL,
			            [TELEFONE] = @TELEFONE,
			            [EMPRESA] = @EMPRESA,
			            [CARGO] = @CARGO
		            WHERE
			            [ID] = @ID";

            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoEdicao = new SqlCommand(sqlEditar, conexaoComBanco);

            contatoEditado.Id = id;

            ConfigurarParametrosContato(contatoEditado, comandoEdicao);

            conexaoComBanco.Open();

            int numeroRegistrosAfetados = comandoEdicao.ExecuteNonQuery();

            conexaoComBanco.Close();

            if (numeroRegistrosAfetados < 1)
                return false;

            return true;
        }

        public bool Excluir(int id)
        {
            string sqlExcluir =
                @"DELETE FROM [TBCONTATO]
		            WHERE
			            [ID] = @ID";

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

        public Contato SelecionarPorId(int idSelecionado)
        {
            string sqlSelecionarPorId =
                @"SELECT 
		            [ID], 
		            [NOME], 
		            [EMAIL],
		            [TELEFONE],
		            [EMPRESA],
		            [CARGO]
	            FROM 
		            [TBCONTATO]
                WHERE
                    [ID] = @ID";

            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoSelecao =
                new SqlCommand(sqlSelecionarPorId, conexaoComBanco);

            comandoSelecao.Parameters.AddWithValue("ID", idSelecionado);

            conexaoComBanco.Open();

            SqlDataReader leitor = comandoSelecao.ExecuteReader();

            Contato contato = null;

            if (leitor.Read())
                contato = ConverterParaContato(leitor);

            conexaoComBanco.Close();

            return contato;
        }

        public List<Contato> SelecionarTodos()
        {
            string sqlSelecionarTodos =
                @"SELECT 
		            [ID], 
		            [NOME], 
		            [EMAIL],
		            [TELEFONE],
		            [EMPRESA],
		            [CARGO]
	            FROM 
		            [TBCONTATO]";

            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoSelecao =
                new SqlCommand(sqlSelecionarTodos, conexaoComBanco);

            conexaoComBanco.Open();

            SqlDataReader leitorContato = comandoSelecao.ExecuteReader();

            List<Contato> contatos = new List<Contato>();

            while (leitorContato.Read())
            {
                Contato contato = ConverterParaContato(leitorContato);

                contatos.Add(contato);
            }

            conexaoComBanco.Close();

            return contatos;
        }

        private Contato ConverterParaContato(SqlDataReader leitor)
        {
            Contato contato = new Contato()
            {
                Id = Convert.ToInt32(leitor["ID"]),
                Nome = Convert.ToString(leitor["NOME"]),
                Email = Convert.ToString(leitor["EMAIL"]),
                Telefone = Convert.ToString(leitor["TELEFONE"]),
                Empresa = Convert.ToString(leitor["EMPRESA"]),
                Cargo = Convert.ToString(leitor["CARGO"]),
            };

            return contato;
        }

        private void ConfigurarParametrosContato(Contato contato, SqlCommand comando)
        {
            comando.Parameters.AddWithValue("ID", contato.Id);
            comando.Parameters.AddWithValue("NOME", contato.Nome);
            comando.Parameters.AddWithValue("EMAIL", contato.Email);
            comando.Parameters.AddWithValue("TELEFONE", contato.Telefone);
            comando.Parameters.AddWithValue("EMPRESA", contato.Empresa);
            comando.Parameters.AddWithValue("CARGO", contato.Cargo);
        }
    }
}
