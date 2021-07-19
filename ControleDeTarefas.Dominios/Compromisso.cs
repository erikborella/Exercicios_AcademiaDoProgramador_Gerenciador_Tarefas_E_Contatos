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

        public override bool Equals(object obj)
        {
            return obj is Compromisso compromisso &&
                   Id == compromisso.Id &&
                   EqualityComparer<Contato>.Default.Equals(DominioEstrangeiro, compromisso.DominioEstrangeiro) &&
                   date == compromisso.date &&
                   Assunto == compromisso.Assunto &&
                   Local == compromisso.Local &&
                   Data == compromisso.Data &&
                   HoraInicial.Equals(compromisso.HoraInicial) &&
                   HoraFinal.Equals(compromisso.HoraFinal) &&
                   EqualityComparer<Contato>.Default.Equals(Contato, compromisso.Contato);
        }

        public override int GetHashCode()
        {
            int hashCode = -1768265791;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<Contato>.Default.GetHashCode(DominioEstrangeiro);
            hashCode = hashCode * -1521134295 + date.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Assunto);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Local);
            hashCode = hashCode * -1521134295 + Data.GetHashCode();
            hashCode = hashCode * -1521134295 + HoraInicial.GetHashCode();
            hashCode = hashCode * -1521134295 + HoraFinal.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<Contato>.Default.GetHashCode(Contato);
            return hashCode;
        }
    }
}
