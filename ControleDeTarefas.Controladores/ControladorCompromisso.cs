using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleDeTarefas.Controladores.Base;
using ControleDeTarefas.Dominios;

namespace ControleDeTarefas.Controladores
{
    public class ControladorCompromisso : ControladorRelacionavelBase<Compromisso, Contato>
    {
        public ControladorCompromisso(ControladorContato controladorContato): base(controladorContato)
        {
        }

        public override string NomeTabela => "TBCompromisso";

        public override string NomeCampoEstrangeiro => "contato_id";

        protected override Compromisso LerRegistro(SqlDataReader leitor)
        {
            int id = Convert.ToInt32(leitor["Id"]);
            string assunto = Convert.ToString(leitor["assunto"]);
            string local = Convert.ToString(leitor["local"]);
            DateTime data = Convert.ToDateTime(leitor["data"]);
            TimeSpan horaInicial = TimeSpan.Parse(leitor["horaInicial"].ToString());
            TimeSpan horaFinal = TimeSpan.Parse(leitor["horaFinal"].ToString());

            object idContatoTemp = leitor["contato_id"];
            Contato contato = null;

            if (idContatoTemp != DBNull.Value)
            {
                contato = new Contato(Convert.ToInt32(idContatoTemp));
            }

            return new Compromisso(id, assunto, local, data, horaInicial, horaFinal, contato);
        }

        protected override Dictionary<string, object> PegarPropriedades(Compromisso registro)
        {
            Dictionary<string, object> propriedades = new Dictionary<string, object>();

            propriedades.Add("id", registro.Id);
            propriedades.Add("assunto", registro.Assunto);
            propriedades.Add("local", registro.Local);
            propriedades.Add("data", registro.Data);
            propriedades.Add("horainicial", registro.HoraInicial);
            propriedades.Add("horafinal", registro.HoraFinal);

            return propriedades;
        }

        protected override string[] PegarCamposEditar(out bool incluirDominioEstrangeiro)
        {
            incluirDominioEstrangeiro = true;

            return new string[]
            {
                "assunto",
                "local",
                "data",
                "horainicial",
                "horafinal",
            };
        }

        protected override string[] PegarCamposInserir()
        {
            return new string[]
            {
                "assunto",
                "local",
                "data",
                "horainicial",
                "horafinal",
            };
        }
    }
}
