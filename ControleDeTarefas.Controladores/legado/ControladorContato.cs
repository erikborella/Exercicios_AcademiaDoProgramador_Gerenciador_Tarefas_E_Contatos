using ControleDeTarefas.Controladores.Base;
using ControleDeTarefas.Dominios;
using System;
using System.Collections.Generic;
using System.Data;

namespace ControleDeTarefas.Controladores.Legado
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

        protected override Contato LerRegistro(IDataReader leitor)
        {
            int id = Convert.ToInt32(leitor["Id"]);
            string nome = Convert.ToString(leitor["nome"]);
            string email = Convert.ToString(leitor["email"]);
            string telefone = Convert.ToString(leitor["telefone"]);
            string empresa = Convert.ToString(leitor["empresa"]);
            string cargo = Convert.ToString(leitor["cargo"]);

            return new Contato(id, nome, email, telefone, empresa, cargo);
        }

        protected override Dictionary<string, object> PegarPropriedades(Contato registro)
        {
            Dictionary<string, object> propriedades = new Dictionary<string, object>();

            propriedades.Add("id", registro.Id);
            propriedades.Add("nome", registro.Nome);
            propriedades.Add("email", registro.Email);
            propriedades.Add("telefone", registro.Telefone);
            propriedades.Add("empresa", registro.Empresa);
            propriedades.Add("cargo", registro.Cargo);

            return propriedades;
        }
    }
}
