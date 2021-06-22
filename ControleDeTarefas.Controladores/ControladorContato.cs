using ControleDeTarefas.Dominios;
using System;
using System.Data.SqlClient;

namespace ControleDeTarefas.Controladores
{
    public class ControladorContato : ControladorBase<Contato>
    {
        public ControladorContato() : base("TBContato")
        {
        }

        protected override string[] PegarCamposEditar()
        {
            return new string[0];
        }

        protected override string[] PegarCamposInserir()
        {
            return new string[0];
        }

        protected override Contato LerRegistro(SqlDataReader leitor)
        {
            int id = Convert.ToInt32(leitor["Id"]);
            string nome = Convert.ToString(leitor["nome"]);
            string email = Convert.ToString(leitor["email"]);
            string telefone = Convert.ToString(leitor["telefone"]);
            string empresa = Convert.ToString(leitor["empresa"]);
            string cargo = Convert.ToString(leitor["cargo"]);

            return new Contato(id, nome, email, telefone, empresa, cargo);
        }
    }
}
