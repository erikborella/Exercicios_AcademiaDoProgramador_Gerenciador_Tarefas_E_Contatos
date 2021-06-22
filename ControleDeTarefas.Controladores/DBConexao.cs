using System;


using System.Data.SqlClient;

namespace ControleDeTarefas.Controladores
{
    class DBConexao
    {
        private readonly string enderecoDBControleTarefas =
            @"Data Source=(LocalDb)\MSSqlLocalDB;Initial Catalog=DBControleTarefas;Integrated Security=True;Pooling=False";

        private SqlConnection sqlConnection;

        public DBConexao()
        {
            sqlConnection = new SqlConnection(enderecoDBControleTarefas);
        }

        public void ComConexaoAberta(Action<SqlConnection> action)
        {
            sqlConnection.Open();

            action(sqlConnection);

            sqlConnection.Close();
        }

    }
}
