using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleDeTarefas.Query.Campos;
using ControleDeTarefas.Query.Geradores.Shared.Apelidos;
using ControleDeTarefas.Query.Geradores.Shared.ElementosGeraveis;
using ControleDeTarefas.Query.Geradores.Shared.GeradoresElementos;

namespace ControleDeTarefas.Query.Geradores.Selecionar
{
    public class GeradorSqlSelecionar : GeradorBase
    {
        private CampoBase[] camposParaSelecionar;

        private GeradorOnde<GeradorSqlSelecionar> geradorOnde;
        private JuncaoGeravel<GeradorSqlSelecionar> juncaoGeravel = null;

        private GeradorApelidoTabela geradorApelidoTabela;
        private GeradorApelidoCampo geradorApelidoCampo;

        public GeradorSqlSelecionar(Modelo modelo, params CampoBase[] camposParaSelecionar)
        {
            this.camposParaSelecionar = camposParaSelecionar;
            this.modelo = modelo;

            this.geradorOnde = new GeradorOnde<GeradorSqlSelecionar>(this);

            this.geradorApelidoTabela = new GeradorApelidoTabela() { modelo };
            this.geradorApelidoCampo = new GeradorApelidoCampo();
        }

        public GeradorSqlSelecionar NoMesmoId()
        {
            geradorOnde.AdicionarOnde(modelo.campoId.Nome).EhIgualA(modelo.Id);
            return this;
        }
        public ComparasaoGeravel<GeradorSqlSelecionar> Onde(string campo)
        {
            return geradorOnde.AdicionarOnde(campo);
        }

        public ComparasaoGeravel<GeradorSqlSelecionar> Onde(CampoBase campo)
        {
            string nomeCampo = $"[{geradorApelidoTabela[campo.modeloRef]}].[{campo.nome}]";
            return Onde(nomeCampo);
        }

        public ComparasaoGeravel<GeradorSqlSelecionar> NaoOnde(string campo)
        {
            return geradorOnde.AdicionarNaoOnde(campo);
        }

        public ComparasaoGeravel<GeradorSqlSelecionar> NaoOnde(CampoBase campo)
        {
            string nomeCampo = $"[{geradorApelidoTabela[campo.modeloRef]}].[{campo.nome}]";
            return NaoOnde(nomeCampo);
        }

        public GeradorSqlSelecionar E()
        {
            geradorOnde.AdicionarE();
            return this;
        }

        public GeradorSqlSelecionar Ou()
        {
            geradorOnde.AdicionarOu();
            return this;
        }

        public JuncaoGeravel<GeradorSqlSelecionar> JunteCom(CampoRelacionavelBase campoRelacionavel)
        {
            JuncaoGeravel<GeradorSqlSelecionar> juncaoGeravel = 
                new JuncaoGeravel<GeradorSqlSelecionar>(this, geradorApelidoTabela, campoRelacionavel);

            this.juncaoGeravel = juncaoGeravel;

            return juncaoGeravel;
        }

        private string GerarSELECT()
        {
            StringBuilder sqlSELECT = new StringBuilder();

            sqlSELECT.AppendLine("SELECT");

            for (int i = 0; i < camposParaSelecionar.Length; i++)
            {
                CampoBase campo = camposParaSelecionar[i];

                string apelidoTabela = geradorApelidoTabela[campo.modeloRef];

                sqlSELECT.Append($"[{apelidoTabela}].[{campo.nome}]");

                if (campo.modeloRef != this.modelo)
                    sqlSELECT.Append($" AS {geradorApelidoCampo.PegarApelido(campo)}");

                if (i != camposParaSelecionar.Length - 1)
                    sqlSELECT.Append(",");

                sqlSELECT.AppendLine();
            }

            return sqlSELECT.ToString();
        }

        private string GerarFROM()
        {
          
            StringBuilder sqlFROM = new StringBuilder();

            if (juncaoGeravel == null)
            {
                sqlFROM.AppendLine("FROM");
                sqlFROM.AppendLine($"[{modelo.NomeTabela}] [{geradorApelidoTabela[modelo]}]");
            } else
            {
                sqlFROM.Append(juncaoGeravel.Gerar());
            }

            return sqlFROM.ToString();
        }

        private string Gerar()
        {
            StringBuilder sql = new StringBuilder();

            sql.Append(GerarSELECT());
            sql.Append(GerarFROM());
            sql.Append(geradorOnde.Gerar());

            sql.Append(";");

            return sql.ToString();
        }

        public override string ToSQL()
        {
            return Gerar();
        }
    }
}
