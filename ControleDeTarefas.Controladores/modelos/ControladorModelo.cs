using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;

using ControleDeTarefas.Query.Interfaces;
using ControleDeTarefas.Query;

using ControleDeTarefas.Query.Campos;

using ControleDeTarefas.Query.Geradores.Inserir;
using ControleDeTarefas.Query.Geradores.Atualizar;
using ControleDeTarefas.Query.Geradores.Deletar;
using ControleDeTarefas.Query.Geradores.Selecionar;

namespace ControleDeTarefas.Controladores.modelos
{
    public static class ControladorModelo
    {
        private static DBConexao dBConexao;
        static ControladorModelo()
        {
            dBConexao = new DBConexao();
        }

        public static int Executar(this GeradorSqlInserir geradorSqlInserir)
        {
            string sql = geradorSqlInserir.ToSQL();

            sql += dBConexao.PegarComandoSelecionarUltimoId();

            int id = 0;

            dBConexao.ComConexaoAberta(conexao =>
            {
                IDbCommand comando = dBConexao.CriarSqlCommand(sql);

                id = Convert.ToInt32(comando.ExecuteScalar());
            });

            return id;
        }

        public static bool Executar(this GeradorSqlAtualizar geradorSqlAtualizar)
        {
            string sql = geradorSqlAtualizar.ToSQL();

            bool status = false;

            dBConexao.ComConexaoAberta(conexao =>
            {
                IDbCommand comando = dBConexao.CriarSqlCommand(sql);

                int n = comando.ExecuteNonQuery();

                status = n != 0;
            });

            return status;
        }

        public static bool Executar(this GeradorSqlDeletar geradorSqlDeletar)
        {
            string sql = geradorSqlDeletar.ToSQL();

            bool status = false;

            dBConexao.ComConexaoAberta(conexao =>
            {
                IDbCommand comando = dBConexao.CriarSqlCommand(sql);

                int n = comando.ExecuteNonQuery();

                status = n != 0;
            });

            return status;
        }

        public static List<Dictionary<string, object>> Executar(this GeradorSqlSelecionar geradorSqlSelecionar)
        {
            string sql = geradorSqlSelecionar.ToSQL();

            List<Dictionary<string, object>> valores = new List<Dictionary<string, object>>();

            dBConexao.ComConexaoAberta(conexao =>
            {
                IDbCommand comando = dBConexao.CriarSqlCommand(sql);

                using (var leitor = comando.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        valores.Add(ExtrairValores(leitor));
                    }
                }
            });

            return valores;
        }

        public static T[] Converter<T>(this GeradorSqlSelecionar geradorSqlSelecionar)
            where T : Modelo, IModeloConvertivel<T>
        {
            T modeloBase = (T)geradorSqlSelecionar.modelo;
            List<T> modelos = new List<T>();

            List<Dictionary<string, object>> valores = geradorSqlSelecionar.Executar();

            foreach (var valoresModelo in valores)
            {
                modelos.Add(modeloBase.Converter(valoresModelo));
            }

            return modelos.ToArray();
        }

        public static T[] ConverterRecursivamente<T, F>(this GeradorSqlSelecionar geradorSqlSelecionar)
            where T : Modelo, IModeloConvertivel<T>
            where F : Modelo, IModeloConvertivel<F>
        {
            T modeloBase = (T)geradorSqlSelecionar.modelo;

            if (EncontrarIndexCampoEstrangeiro<F>(modeloBase) == -1)
                return geradorSqlSelecionar.Converter<T>();

            List<T> modelos = new List<T>();

            List<Dictionary<string, object>> valores = geradorSqlSelecionar.Executar();

            foreach (var valoresModelo in valores)
            {
                T modelo = modeloBase.Converter(valoresModelo);
                int indexCampoEstrangeiro = EncontrarIndexCampoEstrangeiro<F>(modelo);

                CampoRelacionavel<F> campoRelacionavel =
                    modelo.campos[indexCampoEstrangeiro] as CampoRelacionavel<F>;

                if (campoRelacionavel.Valor != null && campoRelacionavel.Valor.Id != 0)
                {
                    F[] modelosEstrangerios = campoRelacionavel.Valor
                        .SQL()
                        .Selecionar()
                        .TodosOsCampos()
                        .NoMesmoId()
                        .Converter<F>();

                    if (modelosEstrangerios.Length != 0)
                        campoRelacionavel.Valor =
                            modelosEstrangerios[0];
                    else
                        campoRelacionavel.Valor = null;
                }

                modelos.Add(modelo);
            }

            return modelos.ToArray();
        }

        private static Dictionary<string, object> ExtrairValores(IDataReader leitor)
        {
            Dictionary<string, object> valores = new Dictionary<string, object>();

            for (int i = 0; i < leitor.FieldCount; i++)
            {
                string nome = leitor.GetName(i);
                object valor = leitor.GetValue(i);

                valores.Add(nome, valor);
            }

            return valores;
        }

        private static int EncontrarIndexCampoEstrangeiro<F>(Modelo modelo)
            where F : Modelo
        {
            for (int i = 0; i < modelo.campos.Count(); i++)
            {
                if (modelo.campos[i] is CampoRelacionavel<F>)
                    return i;
            }

            return -1;
        }
    }
}
