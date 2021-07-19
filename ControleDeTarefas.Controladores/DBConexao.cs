using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

using System.Data.SQLite;

namespace ControleDeTarefas.Controladores
{
    public class DBConexao
    {
        private string bancoEmUso;
        private string connectionString;

        private IDbConnection sqlConnection;
        public DBConexao()
        {
            bancoEmUso = ConfigurationManager.AppSettings["bancoParaUsar"].ToLower().Trim();
            connectionString = ConfigurationManager.ConnectionStrings[bancoEmUso].ConnectionString;

            if (bancoEmUso == "sqlite")
                sqlConnection = new SQLiteConnection(connectionString);
            else
                sqlConnection = new SqlConnection(connectionString);

        }

        public IDbCommand CriarSqlCommand(string sql)
        {
            return CriarSqlCommand(sql, this.sqlConnection);
        }

        public IDbCommand CriarSqlCommand(string sql, IDbConnection sqlConnection)
        {
            IDbCommand comando;

            if (bancoEmUso == "sqlite")
                comando = new SQLiteCommand(sql, (SQLiteConnection)sqlConnection);
            else
                comando = new SqlCommand(sql, (SqlConnection)sqlConnection);

            return comando;
        }

        public void ComConexaoAberta(Action<IDbConnection> action)
        {
            sqlConnection.Open();

            try
            {
                action(sqlConnection);
            } 
            finally {
                sqlConnection.Close();
            }
        }

        public string PegarComandoSelecionarUltimoId()
        {
            if (bancoEmUso == "sqlite")
                return "SELECT LAST_INSERT_ROWID();";
            else
                return "SELECT SCOPE_IDENTITY();";
        }

    }
}
