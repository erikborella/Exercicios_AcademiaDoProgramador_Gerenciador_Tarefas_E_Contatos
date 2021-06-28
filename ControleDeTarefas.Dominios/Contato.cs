using ControleDeTarefas.Dominios.Base;

namespace ControleDeTarefas.Dominios
{
    public class Contato : DominioBase
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Empresa { get; set; }
        public string Cargo { get; set; }

        public Contato(string nome, string email, string telefone, string empresa, string cargo)
        {
            Nome = nome;
            Email = email;
            Telefone = telefone;
            Empresa = empresa;
            Cargo = cargo;
        }

        public Contato(int id, string nome, string email, string telefone, string empresa, string cargo)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Telefone = telefone;
            Empresa = empresa;
            Cargo = cargo;
        }

        public Contato()
        {

        }

        public Contato(int id)
        {
            Id = id;
        }
    }
}
