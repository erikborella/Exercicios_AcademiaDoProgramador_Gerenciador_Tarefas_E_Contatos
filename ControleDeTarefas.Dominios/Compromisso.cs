using ControleDeTarefas.Dominios.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeTarefas.Dominios
{
    public class Compromisso : DominioBaseRelacionado<Contato>
    {
        private DateTime date;

        public string Assunto { get; set; }
        public string Local { get; set; }
        public DateTime Data
        {
            get => date.Date;
            set => date = value;
        }
        public TimeSpan HoraInicial { get; set; }
        public TimeSpan HoraFinal { get; set; }

        public Contato Contato
        {
            get => DominioEstrangeiro;
            set => DominioEstrangeiro = value;
        }

        public Compromisso()
        {

        }

        public Compromisso(int id, string assunto, string local, DateTime data, TimeSpan horaInicial, TimeSpan horaFinal, Contato contato)
        {
            Id = id;
            Assunto = assunto;
            Local = local;
            Data = data;
            HoraInicial = horaInicial;
            HoraFinal = horaFinal;
            DominioEstrangeiro = contato;
        }

        public Compromisso(string assunto, string local, DateTime data, TimeSpan horaInicial, TimeSpan horaFinal, Contato contato)
        {
            Assunto = assunto;
            Local = local;
            Data = data;
            HoraInicial = horaInicial;
            HoraFinal = horaFinal;
            DominioEstrangeiro = contato;
        }
    }
}
