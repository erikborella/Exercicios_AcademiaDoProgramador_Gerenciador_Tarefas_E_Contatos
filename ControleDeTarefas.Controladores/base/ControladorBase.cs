using ControleDeTarefas.Dominios.Base;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;

using System.Data.Common;

using System.Data;

namespace ControleDeTarefas.Controladores.Base
{
    public abstract class ControladorBase<T> : IControlavel<T> where T : DominioBase
    {
        private DBConexao dbConexao;

        public string NomeTabela { get; private set; }

        public ControladorBase(string nomeTabela)
        {
            dbConexao = new DBConexao();
            NomeTabela = nomeTabela;
        }

        public bool Inserir(T registro)
        {
            bool sucessoNaOperacao = false;

            dbConexao.ComConexaoAberta(conexao =>
            {
                Dictionary<string, object> propriedades = PegarPropriedades(registro);

                string[] campos = PegarCamposInserir();

                if (campos.Length == 0)
                    campos = PegarTodosOsCampos(propriedades, false);

                string sql = GerarSqlInserir(campos);

                IDbCommand comando = dbConexao.CriarSqlCommand(sql, conexao);

                //SqlCommand comando = new SqlCommand(sql, conexao);

                foreach (string campo in campos)
                {
                    var parameter = comando.CreateParameter();
                    parameter.ParameterName = campo;
                    parameter.Value = propriedades[campo];

                    comando.Parameters.Add(parameter);
                }

                int id = Convert.ToInt32(comando.ExecuteScalar());

                registro.Id = Convert.ToInt32(id);

                sucessoNaOperacao = id != 0;
            });

            return sucessoNaOperacao;
        }

        public bool Editar(T registro, string[] campos = null)
        {
            bool sucessoNaOperacao = false;

            dbConexao.ComConexaoAberta(conexao =>
            {
                Dictionary<string, object> propriedades = PegarPropriedades(registro);

                if (campos == null)
                    campos = PegarCamposEditar();

                if (campos.Length == 0)
                    campos = PegarTodosOsCampos(propriedades, false);

                string sql = GerarSqlEditar(campos);

                //SqlCommand comando = new SqlCommand(sql, conexao);

                IDbCommand comando = dbConexao.CriarSqlCommand(sql, conexao);


                foreach (string campo in campos)
                {
                    comando.Parameters.Add(CriarParametro(campo, propriedades[campo], comando));
                }

                comando.Parameters.Add(CriarParametro("id", propriedades["id"], comando));

                int n = comando.ExecuteNonQuery();

                sucessoNaOperacao = n != 0;

            });

            return sucessoNaOperacao;
        }

        public bool Excluir(int id)
        {
            bool sucessoNaOperacao = false;
           
            dbConexao.ComConexaoAberta(conexao =>
            {
                string sql = GerarSqlExcluir();

                IDbCommand comando = dbConexao.CriarSqlCommand(sql, conexao);

                comando.Parameters.Add(CriarParametro("id", id, comando));

                int n = comando.ExecuteNonQuery();

                sucessoNaOperacao = n != 0;
            });

            return sucessoNaOperacao;
        }

        public T BuscarRegistroPorId(int id)
        {
            T registro = null;

            dbConexao.ComConexaoAberta(conexao =>
            {
                string sql = GerarSqlBuscarPorId();

                IDbCommand comando = dbConexao.CriarSqlCommand(sql, conexao);


                comando.Parameters.Add(CriarParametro("id", id, comando));

                using (var leitor = comando.ExecuteReader())
                {
                    if (leitor.Read() == false)
                        return;

                    registro = LerRegistro(leitor);
                }
            });

            return registro;
        }

        public T[] BuscarRegistros()
        {
            List<T> registro = new List<T>();

            dbConexao.ComConexaoAberta(conexao =>
            {
                string sql = GerarSqlBuscar();

                IDbCommand comando = dbConexao.CriarSqlCommand(sql, conexao);

                using (var leitor = comando.ExecuteReader()) { 
                    while (leitor.Read())
                        registro.Add(LerRegistro(leitor));
                }
            });

            return registro.ToArray();
        }

       
        private string[] PegarTodosOsCampos(Dictionary<string, object> propriedades, bool incluirId = true)
        {
            string[] campos;

            if (!incluirId)
                campos = propriedades.Keys.Where(campo => campo != "id").ToArray();
            else
                campos = propriedades.Keys.ToArray();

            return campos;
        }

        private string GerarSqlInserir(string[] campos)
        {
            StringBuilder sql = new StringBuilder();

            sql.AppendLine($"INSERT INTO [{NomeTabela}]");
            sql.AppendLine("(");

            for (int i = 0; i < campos.Length; i++)
            {
                sql.Append($"[{campos[i]}]");

                if (i != campos.Length - 1)
                    sql.Append(",");

                sql.AppendLine();
            }

            sql.AppendLine(")");
            sql.AppendLine("VALUES");
            sql.AppendLine("(");

            for (int i = 0; i < campos.Length; i++)
            {
                sql.Append($"@{campos[i]}");

                if (i != campos.Length - 1)
                    sql.Append(",");

                sql.AppendLine();
            }

            sql.AppendLine(");");

            sql.AppendLine(dbConexao.PegarComandoSelecionarUltimoId());

            return sql.ToString();
        }

        private string GerarSqlEditar(string[] campos)
        {
            StringBuilder sql = new StringBuilder();

            sql.AppendLine($"UPDATE [{NomeTabela}]");
            sql.AppendLine("SET");

            for (int i = 0; i < campos.Length; i++)
            {
                sql.Append($"[{campos[i]}] = @{campos[i]}");

                if (i != campos.Length - 1)
                    sql.Append(",");

                sql.AppendLine();
            }

            sql.AppendLine("WHERE");
            sql.AppendLine($"[Id] = @Id");

            return sql.ToString();
        }

        private string GerarSqlExcluir()
        {
            StringBuilder sql = new StringBuilder();

            sql.AppendLine($"DELETE FROM [{NomeTabela}]");
            sql.AppendLine("WHERE");
            sql.AppendLine("[Id] = @Id");

            return sql.ToString();
        }

        private string GerarSqlBuscarPorId()
        {
            StringBuilder sql = new StringBuilder();

            sql.AppendLine("SELECT");
            sql.AppendLine("*");
            sql.AppendLine($"FROM [{NomeTabela}]");
            sql.AppendLine("WHERE");
            sql.AppendLine("[Id] = @Id");

            return sql.ToString();
        }

        private string GerarSqlBuscar()
        {
            StringBuilder sql = new StringBuilder();

            sql.AppendLine("SELECT");
            sql.AppendLine("*");
            sql.AppendLine($"FROM [{NomeTabela}]");

            return sql.ToString();
        }

        private IDbDataParameter CriarParametro(string nome, object valor, IDbCommand comando)
        {
            var parameter = comando.CreateParameter();

            parameter.ParameterName = nome;
            parameter.Value = valor;

            return parameter;
        }


        protected abstract Dictionary<string, object> PegarPropriedades(T registro);

        protected abstract string[] PegarCamposInserir();

        protected abstract string[] PegarCamposEditar();

        protected abstract T LerRegistro(IDataReader leitor);
    }
}
