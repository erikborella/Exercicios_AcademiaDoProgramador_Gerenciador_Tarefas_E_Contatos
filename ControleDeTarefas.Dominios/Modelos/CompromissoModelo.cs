using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ControleDeTarefas.Query;
using ControleDeTarefas.Query.Campos;
using ControleDeTarefas.Query.Interfaces;

namespace ControleDeTarefas.Dominios
{
    public class CompromissoModelo : Modelo, IModeloConvertivel<CompromissoModelo>
    {

        public Campo<string> campoAssunto;
        public Campo<string> campoLocal;
        public Campo<DateTime> campoData;
        public Campo<TimeSpan> campoHoraInicial;
        public Campo<TimeSpan> campoHoraFinal;
        public CampoRelacionavel<ContatoModelo> campoContato;
        public override string NomeTabela => "TBCompromisso";
        public override string NomeFormal => "Compromisso";

        public DateTime Data { get => campoData.Valor.Date; set => campoData.Valor = value; }
        public string Assunto { get => campoAssunto.Valor; set => campoAssunto.Valor = value; }
        public string Local { get => campoLocal.Valor; set => campoLocal.Valor = value; }
        public TimeSpan HoraInicial { get => campoHoraInicial.Valor; set => campoHoraInicial.Valor = value; }
        public TimeSpan HoraFinal { get => campoHoraFinal.Valor; set => campoHoraFinal.Valor = value; }
        public ContatoModelo Contato { get => campoContato.Valor; set => campoContato.Valor = value; }

        public CompromissoModelo(string assunto, string local, DateTime data, TimeSpan inicial, TimeSpan final)
        {
            IniciarCampos();

            Assunto = assunto;
            Local = local;
            Data = data;
            HoraInicial = inicial;
            HoraFinal = final;
        }

        public CompromissoModelo(int id, string assunto, string local, DateTime data, TimeSpan inicial, TimeSpan final, ContatoModelo contato)
        {
            IniciarCampos();

            Id = id;
            Assunto = assunto;
            Local = local;
            Data = data;
            HoraInicial = inicial;
            HoraFinal = final;
            Contato = contato;
        }

        public CompromissoModelo()
        {
            IniciarCampos();
        }

        public CompromissoModelo(string assunto, string local, DateTime data, TimeSpan inicial, TimeSpan final, ContatoModelo contato)
        {
            IniciarCampos();

            Assunto = assunto;
            Local = local;
            Data = data;
            HoraInicial = inicial;
            HoraFinal = final;
            Contato = contato;
        }

        private void IniciarCampos()
        {
            campoAssunto = Campo<string>("assunto");
            campoLocal = Campo<string>("local");
            campoData = Campo<DateTime>("data");
            campoHoraInicial = Campo<TimeSpan>("horaInicial");
            campoHoraFinal = Campo<TimeSpan>("horaFinal");
            campoContato = CampoRelacionavel<ContatoModelo>("contato_id");
        }

        public CompromissoModelo Converter(Dictionary<string, object> valores)
        {
            int id = 0;
            string assunto = null, local = null;
            DateTime data = default;
            TimeSpan horaInicial = default, horaFinal = default;
            ContatoModelo contatoModelo = null;

            if (valores.ContainsKey("Id"))
                id = Convert.ToInt32(valores["Id"]);

            if (valores.ContainsKey("assunto"))
                assunto = Convert.ToString(valores["assunto"]);

            if (valores.ContainsKey("local"))
                local = Convert.ToString(valores["local"]);

            if (valores.ContainsKey("data"))
                data = Convert.ToDateTime(valores["data"]);

            if (valores.ContainsKey("horaInicial"))
                horaInicial = TimeSpan.Parse(valores["horaInicial"].ToString());

            if (valores.ContainsKey("horaFinal"))
                horaFinal = TimeSpan.Parse(valores["horaFinal"].ToString());

            if (valores.ContainsKey("contato_id") && valores["contato_id"] != DBNull.Value)
                contatoModelo = new ContatoModelo()
                {
                    Id = Convert.ToInt32(valores["contato_id"])
                };

            return new CompromissoModelo(id, assunto, local, data, horaInicial, horaFinal, contatoModelo);
        }
    }
}
