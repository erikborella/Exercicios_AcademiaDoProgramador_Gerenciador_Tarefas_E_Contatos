using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;

using System.Data;
using ControleDeTarefas.Dominios.Base;

namespace ControleDeTarefas.Controladores.Base
{
    public abstract class ControladorRelacionavelBase<T, F>
        : IControlavel<T>
        where T : DominioBaseRelacionado<F>
        where F : DominioBase
    {
        private DBConexao dbConexao;

        public abstract string NomeTabela { get; }

        public abstract string NomeCampoEstrangeiro { get; }

        private IControlavel<F> controladorEstrangeiro;

        public ControladorRelacionavelBase(IControlavel<F> controladorEstrangeiro)
        {
            this.controladorEstrangeiro = controladorEstrangeiro;
            dbConexao = new DBConexao();
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

                    registro = ObterRegistroCompleto(leitor);
                }
            });

            return registro;
        }

        public T[] BuscarRegistros()
        {
            List<T> registros = new List<T>();

            dbConexao.ComConexaoAberta(conexao =>
            {
                string sql = GerarSqlBuscar();

                IDbCommand comando = dbConexao.CriarSqlCommand(sql, conexao);

                using (var leitor = comando.ExecuteReader())
                {
                    while (leitor.Read())
                        registros.Add(ObterRegistroCompleto(leitor));
                }
            });

            return registros.ToArray();
        }

        public bool Editar(T registro, string[] campos = null)
        {
            bool sucessoNaOperacao = false;

            dbConexao.ComConexaoAberta(conexao =>
            {
                Dictionary<string, object> propriedades = PegarPropriedades(registro);

                bool incluirDominioEstrangeiro;

                campos = PegarCamposEditar(out incluirDominioEstrangeiro);

                string sql = GerarSqlEditar(campos, incluirDominioEstrangeiro);

                IDbCommand comando = dbConexao.CriarSqlCommand(sql, conexao);

                foreach (string campo in campos)
                    comando.Parameters.Add(CriarParametro(campo, propriedades[campo], comando));

                if (incluirDominioEstrangeiro)
                {
                    object dominioEstrangeiroId = PegarDominioEstrangeiroId(registro);

                    comando.Parameters.Add(CriarParametro(NomeCampoEstrangeiro, dominioEstrangeiroId, comando));
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

                comando.Parameters.Add(CriarParametro( "id", id, comando));

                int n = comando.ExecuteNonQuery();

                sucessoNaOperacao = n != 0;
            });

            return sucessoNaOperacao;
        }

        public bool Inserir(T registro)
        {
            bool sucessoNaOperacao = false;

            dbConexao.ComConexaoAberta(conexao =>
            {
                Dictionary<string, object> propriedades = PegarPropriedades(registro);

                string[] campos = PegarCamposInserir();

                if (campos.Length == 0)
                    throw new ArgumentOutOfRangeException(
                        "Não é possivel pegar os campos automaticamente para dominios com relações",
                        nameof(PegarCamposInserir)
                        );

                string sql = GerarSqlInserir(campos);

                IDbCommand comando = dbConexao.CriarSqlCommand(sql, conexao);

                foreach (string campo in campos)
                    comando.Parameters.Add(CriarParametro(campo, propriedades[campo], comando));


                object dominioEstrangeiroId = PegarDominioEstrangeiroId(registro);

                comando.Parameters.Add(CriarParametro(NomeCampoEstrangeiro, dominioEstrangeiroId, comando));

                int id = Convert.ToInt32(comando.ExecuteScalar());

                registro.Id = id;

                sucessoNaOperacao = id != 0;

            });

            return sucessoNaOperacao;
        }


        private string GerarSqlInserir(string[] campos)
        {
            StringBuilder sql = new StringBuilder();

            sql.AppendLine($"INSERT INTO [{NomeTabela}]");
            sql.AppendLine("(");

            for (int i = 0; i < campos.Length; i++)
            {
                sql.AppendLine($"[{campos[i]}],");
            }

            sql.AppendLine($"[{NomeCampoEstrangeiro}]");

            sql.AppendLine(")");
            sql.AppendLine("VALUES");
            sql.AppendLine("(");

            for (int i = 0; i < campos.Length; i++)
            {
                sql.AppendLine($"@{campos[i]},");
            }

            sql.AppendLine($"@{NomeCampoEstrangeiro}");

            sql.AppendLine(");");

            sql.AppendLine(dbConexao.PegarComandoSelecionarUltimoId());

            return sql.ToString();
        }

        private string GerarSqlEditar(string[] campos, bool incluirDominioEstrangeiro)
        {
            StringBuilder sql = new StringBuilder();

            sql.AppendLine($"UPDATE [{NomeTabela}]");
            sql.AppendLine("SET");

            for (int i = 0; i < campos.Length; i++)
            {
                sql.Append($"[{campos[i]}] = @{campos[i]}");

                if (i != campos.Length - 1)
                {
                    sql.Append(",");
                    sql.AppendLine();
                }
            }

            if (incluirDominioEstrangeiro)
            {
                sql.AppendLine(",");
                sql.Append($"[{NomeCampoEstrangeiro}] = @{NomeCampoEstrangeiro}");
            }

            sql.AppendLine("");

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
            sql.AppendLine("T1.*");
            sql.AppendLine("FROM");
            sql.AppendLine($"[{NomeTabela}] T1 LEFT JOIN");
            sql.AppendLine($"[{controladorEstrangeiro.NomeTabela}] T2");
            sql.AppendLine("ON");
            sql.AppendLine($"T1.{NomeCampoEstrangeiro} = T2.Id");
            sql.AppendLine("WHERE");
            sql.AppendLine("T1.Id = @id;");

            return sql.ToString();
        }

        private string GerarSqlBuscar()
        {
            StringBuilder sql = new StringBuilder();

            sql.AppendLine("SELECT");
            sql.AppendLine("T1.*");
            sql.AppendLine("FROM");
            sql.AppendLine($"[{NomeTabela}] T1 LEFT JOIN");
            sql.AppendLine($"[{controladorEstrangeiro.NomeTabela}] T2");
            sql.AppendLine("ON");
            sql.AppendLine($"T1.{NomeCampoEstrangeiro} = T2.Id;");

            return sql.ToString();
        }

        private T ObterRegistroCompleto(IDataReader leitor)
        {
            T registro = LerRegistro(leitor);

            if (registro.DominioEstrangeiro != null)
            {
                F estrangeiro = controladorEstrangeiro.BuscarRegistroPorId(
                    registro.DominioEstrangeiro.Id);
                registro.DominioEstrangeiro = estrangeiro;
            }

            return registro;
        }

        private static object PegarDominioEstrangeiroId(T registro)
        {
            object dominioEstrangeiroId;

            if (registro.DominioEstrangeiro == null)
                dominioEstrangeiroId = DBNull.Value;
            else
                dominioEstrangeiroId = registro.DominioEstrangeiro.Id;
            return dominioEstrangeiroId;
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

        protected abstract string[] PegarCamposEditar(out bool incluirDominioEstrangeiro);

        protected abstract T LerRegistro(IDataReader leitor);
    }
}
