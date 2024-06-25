
using eAgenda.WinApp.ModuloContato;
using Microsoft.Data.SqlClient;

namespace eAgenda.WinApp.ModuloCompromisso
{
    public class RepositorioCompromissoEmSql : IRepositorioCompromisso
    {
        private string enderecoBanco;

        public RepositorioCompromissoEmSql()
        {
            enderecoBanco = "Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=eAgendaDb;Integrated Security=True;Pooling=False";
        }

        private const string sqlInserir =
            @"INSERT INTO [TBCOMPROMISSO]
                (
                    [ASSUNTO],
                    [LOCAL],       
                    [LINK],            
                    [DATA], 
                    [HORAINICIO],                    
                    [HORATERMINO],                                                           
                    [CONTATO_ID]
                )
                VALUES
                (
                    @ASSUNTO,
                    @LOCAL,
                    @LINK,
                    @DATA,
                    @HORAINICIO,
                    @HORATERMINO,
                    @CONTATO_ID
                ); SELECT SCOPE_IDENTITY();";

        private const string sqlEditar =
          @"UPDATE [TBCOMPROMISSO]
                SET 
                    [ASSUNTO] = @ASSUNTO,
                    [LOCAL] = @LOCAL, 
                    [LINK] = @LINK,
                    [DATA] = @DATA, 
                    [HORAINICIO] = @HORAINICIO, 
                    [HORATERMINO] = @HORATERMINO,
                    [CONTATO_ID] = @CONTATO_ID
                WHERE 
                    [ID] = @ID";

        private const string sqlExcluir =
            @"DELETE FROM [TBCOMPROMISSO]
		        WHERE
			        [ID] = @ID";

        private const string sqlSelecionarPorId =
          @"SELECT
                CP.[ID],
                CP.[ASSUNTO],
                CP.[LOCAL],
                CP.[LINK],
                CP.[DATA],
                CP.[HORAINICIO],
                CP.[HORATERMINO],
                CP.[CONTATO_ID],
                CT.[NOME],
                CT.[EMAIL],
                CT.[TELEFONE],
                CT.[CARGO],
                CT.[EMPRESA]
            FROM
                [TBCompromisso] AS CP LEFT JOIN
                [TBContato] AS CT
            ON
                CT.ID = CP.CONTATO_ID
            WHERE
                CP.[ID] = @ID;";

        private const string sqlSelecionarTodos =
            @"SELECT
                CP.[ID],
                CP.[ASSUNTO],
                CP.[LOCAL],
                CP.[LINK],
                CP.[DATA],
                CP.[HORAINICIO],
                CP.[HORATERMINO],
                CP.[CONTATO_ID],
                CT.[NOME],
                CT.[EMAIL],
                CT.[TELEFONE],
                CT.[CARGO],
                CT.[EMPRESA]
            FROM
                [TBCompromisso] AS CP LEFT JOIN
                [TBContato] AS CT
            ON
                CT.ID = CP.CONTATO_ID;";

        private const string sqlSelecionarFuturos =
            @"SELECT
                CP.[ID],
                CP.[ASSUNTO],
                CP.[LOCAL],
                CP.[LINK],
                CP.[DATA],
                CP.[HORAINICIO],
                CP.[HORATERMINO],
                CP.[CONTATO_ID],
                CT.[NOME],
                CT.[EMAIL],
                CT.[TELEFONE],
                CT.[CARGO],
                CT.[EMPRESA]
            FROM
                [TBCompromisso] AS CP LEFT JOIN
                [TBContato] AS CT
            ON
                CT.ID = CP.CONTATO_ID
            WHERE
                CP.[DATA] >= @DATA;";

        private const string sqlSelecionarPassados =
          @"SELECT
                CP.[ID],
                CP.[ASSUNTO],
                CP.[LOCAL],
                CP.[LINK],
                CP.[DATA],
                CP.[HORAINICIO],
                CP.[HORATERMINO],
                CP.[CONTATO_ID],
                CT.[NOME],
                CT.[EMAIL],
                CT.[TELEFONE],
                CT.[CARGO],
                CT.[EMPRESA]
            FROM
                [TBCompromisso] AS CP LEFT JOIN
                [TBContato] AS CT
            ON
                CT.ID = CP.CONTATO_ID
            WHERE
                CP.[DATA] < @DATA;";

        private const string sqlSelecionarPeriodo =
            @"SELECT
                CP.[ID],
                CP.[ASSUNTO],
                CP.[LOCAL],
                CP.[LINK],
                CP.[DATA],
                CP.[HORAINICIO],
                CP.[HORATERMINO],
                CP.[CONTATO_ID],
                CT.[NOME],
                CT.[EMAIL],
                CT.[TELEFONE],
                CT.[CARGO],
                CT.[EMPRESA]
            FROM
                [TBCompromisso] AS CP LEFT JOIN
                [TBContato] AS CT
            ON
                CT.ID = CP.CONTATO_ID
            WHERE
               CP.[DATA] BETWEEN @DATAINICIO AND @DATATERMINO";

        public void Cadastrar(Compromisso novoCompromisso)
        {
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoInsercao = new SqlCommand(sqlInserir, conexaoComBanco);

            ConfigurarParametrosCompromisso(novoCompromisso, comandoInsercao);

            conexaoComBanco.Open();

            object id = comandoInsercao.ExecuteScalar();

            novoCompromisso.Id = Convert.ToInt32(id);

            conexaoComBanco.Close();
        }

        public bool Editar(int id, Compromisso compromissoEditado)
        {
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoEdicao = new SqlCommand(sqlEditar, conexaoComBanco);

            compromissoEditado.Id = id;

            ConfigurarParametrosCompromisso(compromissoEditado, comandoEdicao);

            conexaoComBanco.Open();

            int numeroRegistrosAfetados = comandoEdicao.ExecuteNonQuery();

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

        public Compromisso SelecionarPorId(int idSelecionado)
        {
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoSelecao =
                new SqlCommand(sqlSelecionarPorId, conexaoComBanco);

            comandoSelecao.Parameters.AddWithValue("ID", idSelecionado);

            conexaoComBanco.Open();

            SqlDataReader leitor = comandoSelecao.ExecuteReader();

            Compromisso compromisso = null;

            if (leitor.Read())
                compromisso = ConverterParaCompromisso(leitor);

            conexaoComBanco.Close();

            return compromisso;
        }

        public List<Compromisso> SelecionarTodos()
        {
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoSelecao =
                new SqlCommand(sqlSelecionarTodos, conexaoComBanco);

            conexaoComBanco.Open();

            SqlDataReader leitorCompromisso = comandoSelecao.ExecuteReader();

            List<Compromisso> compromissos = new List<Compromisso>();

            while (leitorCompromisso.Read())
            {
                Compromisso compromisso = ConverterParaCompromisso(leitorCompromisso);

                compromissos.Add(compromisso);
            }

            conexaoComBanco.Close();

            return compromissos;
        }

        #region métodos extras
        public List<Compromisso> SelecionarCompromissosFuturos()
        {
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoSelecao =
                new SqlCommand(sqlSelecionarFuturos, conexaoComBanco);

            comandoSelecao.Parameters.AddWithValue("DATA", DateTime.Now);

            conexaoComBanco.Open();

            SqlDataReader leitorCompromisso = comandoSelecao.ExecuteReader();

            List<Compromisso> compromissos = new List<Compromisso>();

            while (leitorCompromisso.Read())
            {
                Compromisso compromisso = ConverterParaCompromisso(leitorCompromisso);

                compromissos.Add(compromisso);
            }

            conexaoComBanco.Close();

            return compromissos;
        }

        public List<Compromisso> SelecionarCompromissosPassados()
        {
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoSelecao =
                new SqlCommand(sqlSelecionarPassados, conexaoComBanco);

            DateTime data = DateTime.Now;

            comandoSelecao.Parameters.AddWithValue("DATA", data);

            conexaoComBanco.Open();

            SqlDataReader leitorCompromisso = comandoSelecao.ExecuteReader();

            List<Compromisso> compromissos = new List<Compromisso>();

            while (leitorCompromisso.Read())
            {
                Compromisso compromisso = ConverterParaCompromisso(leitorCompromisso);

                compromissos.Add(compromisso);
            }

            conexaoComBanco.Close();

            return compromissos;
        }

        public List<Compromisso> SelecionarCompromissosPorPeriodo(DateTime dataInicio, DateTime dataTermino)
        {
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoSelecao =
                new SqlCommand(sqlSelecionarPeriodo, conexaoComBanco);

            comandoSelecao.Parameters.AddWithValue("DATAINICIO", dataInicio);
            comandoSelecao.Parameters.AddWithValue("DATATERMINO", dataTermino);

            conexaoComBanco.Open();

            SqlDataReader leitorCompromisso = comandoSelecao.ExecuteReader();

            List<Compromisso> compromissos = new List<Compromisso>();

            while (leitorCompromisso.Read())
            {
                Compromisso compromisso = ConverterParaCompromisso(leitorCompromisso);

                compromissos.Add(compromisso);
            }

            conexaoComBanco.Close();

            return compromissos;
        }
        #endregion

        private Compromisso ConverterParaCompromisso(SqlDataReader leitorCompromisso)
        {
            TimeSpan horaInicio =
                TimeSpan.FromTicks(Convert.ToInt64(leitorCompromisso["HORAINICIO"]));

            TimeSpan horaTermino =
                TimeSpan.FromTicks(Convert.ToInt64(leitorCompromisso["HORATERMINO"]));

            Compromisso compromisso = new Compromisso()
            {
                Id = Convert.ToInt32(leitorCompromisso["ID"]),
                Assunto = Convert.ToString(leitorCompromisso["ASSUNTO"]),
                Link = Convert.ToString(leitorCompromisso["LINK"]),
                Local = Convert.ToString(leitorCompromisso["LOCAL"]),
                Data = Convert.ToDateTime(leitorCompromisso["DATA"]),
                HoraInicio = horaInicio,
                HoraTermino = horaTermino,
            };

            if (leitorCompromisso["CONTATO_ID"] != DBNull.Value)
                compromisso.Contato = ConverterParaContato(leitorCompromisso);

            return compromisso;
        }

        private Contato ConverterParaContato(SqlDataReader leitor)
        {
            Contato contato = new Contato()
            {
                Id = Convert.ToInt32(leitor["CONTATO_ID"]),
                Nome = Convert.ToString(leitor["NOME"]),
                Email = Convert.ToString(leitor["EMAIL"]),
                Telefone = Convert.ToString(leitor["TELEFONE"]),
                Empresa = Convert.ToString(leitor["EMPRESA"]),
                Cargo = Convert.ToString(leitor["CARGO"]),
            };

            return contato;
        }

        private static void ConfigurarParametrosCompromisso(Compromisso novoCompromisso, SqlCommand comandoInsercao)
        {
            comandoInsercao.Parameters.AddWithValue("ID", novoCompromisso.Id);
            comandoInsercao.Parameters.AddWithValue("ASSUNTO", novoCompromisso.Assunto);
            comandoInsercao.Parameters.AddWithValue("LOCAL", novoCompromisso.Local);
            comandoInsercao.Parameters.AddWithValue("LINK", novoCompromisso.Link);
            comandoInsercao.Parameters.AddWithValue("DATA", novoCompromisso.Data);

            comandoInsercao.Parameters.AddWithValue("HORAINICIO", novoCompromisso.HoraInicio.Ticks);
            comandoInsercao.Parameters.AddWithValue("HORATERMINO", novoCompromisso.HoraTermino.Ticks);

            object valorDoContato =
                novoCompromisso.Contato == null ? DBNull.Value : novoCompromisso.Contato.Id;

            comandoInsercao.Parameters.AddWithValue("CONTATO_ID", valorDoContato);
        }
    }
}
