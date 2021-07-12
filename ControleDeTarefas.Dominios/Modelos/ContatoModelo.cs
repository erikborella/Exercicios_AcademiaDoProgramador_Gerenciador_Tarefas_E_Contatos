using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ControleDeTarefas.Query;
using ControleDeTarefas.Query.Campos;
using ControleDeTarefas.Query.Interfaces;

namespace ControleDeTarefas.Dominios.Modelos
{
    public class ContatoModelo : Modelo, IModeloConvertivel<ContatoModelo>
    {
        public Campo<string> campoNome;
        public Campo<string> campoEmail;
        public Campo<string> campoTelefone;
        public Campo<string> campoEmpresa;
        public Campo<string> campoCargo;
        public override string NomeTabela => "TBContato";
        public override string NomeFormal => "Contato";


        public string Nome { get => campoNome.Valor; set => campoNome.Valor = value; }
        public string Email { get => campoEmail.Valor; set => campoEmail.Valor = value; }
        public string Telefone { get => campoTelefone.Valor; set => campoTelefone.Valor = value; }
        public string Empresa { get => campoEmpresa.Valor; set => campoEmpresa.Valor = value; }
        public string Cargo { get => campoCargo.Valor; set => campoCargo.Valor = value; }

        public ContatoModelo() : base("Id")
        {
            IniciarCampos();
        }

        public ContatoModelo(string nome, string email, string telefone, string empresa, string cargo)
        {
            IniciarCampos();

            Nome = nome;
            Email = email;
            Telefone = telefone;
            Empresa = empresa;
            Cargo = cargo;
        }

        public ContatoModelo(int id, string nome, string email, string telefone, string empresa, string cargo)
        {
            IniciarCampos();

            Id = id;
            Nome = nome;
            Email = email;
            Telefone = telefone;
            Empresa = empresa;
            Cargo = cargo;
        }

        public ContatoModelo(int id)
        {
            IniciarCampos();

            Id = id;
        }

        private void IniciarCampos()
        {
            campoNome = Campo<string>("nome");
            campoEmail = Campo<string>("email");
            campoTelefone = Campo<string>("telefone");
            campoEmpresa = Campo<string>("empresa");
            campoCargo = Campo<string>("cargo");
        }

        public ContatoModelo Converter(Dictionary<string, object> valores)
        {
            int id = 0;

            string nome = null,
                email = null,
                telefone = null,
                empresa = null,
                cargo = null;

            if (valores.ContainsKey("Id"))
                id = Convert.ToInt32(valores["Id"]);

            if (valores.ContainsKey("nome"))
                nome = Convert.ToString(valores["nome"]);

            if (valores.ContainsKey("email"))
                email = Convert.ToString(valores["email"]);

            if (valores.ContainsKey("telefone"))
                telefone = Convert.ToString(valores["telefone"]);

            if (valores.ContainsKey("empresa"))
                empresa = Convert.ToString(valores["empresa"]);

            if (valores.ContainsKey("cargo"))
                cargo = Convert.ToString(valores["cargo"]);

            ContatoModelo novoContato = new ContatoModelo(id, nome, email, telefone, empresa, cargo);
            return novoContato;
        }
    }
}
