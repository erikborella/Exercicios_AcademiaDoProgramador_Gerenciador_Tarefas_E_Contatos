using ControleDeTarefas.Controladores;
using ControleDeTarefas.Dominios;
using ControleDeTarefas.Telas.Base;
using System;
using System.Linq;

namespace ControleDeTarefas.Telas.Contatos
{
    class TelaContatos : TelaBase
    {
        protected ControladorContato controladorContato;

        public TelaContatos(ControladorContato controladorContato) : base("Contatos")
        {
            this.controladorContato = controladorContato;

            AdicionarOpcao(new TelaContatosCriar(controladorContato));
            AdicionarOpcao(new TelaContatosEditar(controladorContato));
            AdicionarOpcao(new TelaContatosExcluir(controladorContato));
            AdicionarOpcao(new TelaContatosVisualizar(controladorContato));
        }

        protected TelaContatos(string descricao, ControladorContato controladorContato)
            : base(descricao)
        {
            this.controladorContato = controladorContato;
        }

        protected Contato ObterContato()
        {
            string nome, email, telefone, empresa, cargo;

            ImprimirMensagem("Digite o nome: ", TipoMensagem.INPUT);
            nome = LerString();

            ImprimirMensagem("Digite o email: ", TipoMensagem.INPUT);
            email = LerEmail();

            telefone = LerTelefone();

            ImprimirMensagem("Digite a empresa: ", TipoMensagem.INPUT);
            empresa = LerString();

            ImprimirMensagem("Digite o cargo: ", TipoMensagem.INPUT);
            cargo = LerString();

            return new Contato(nome, email, telefone, empresa, cargo);

        }

        protected void VisualizarContatos(Contato[] contatos)
        {
            string template = "{0, -3} | {1, -15} | {2, -30} | {3, -20} | {4, -15} | {5, -15}";

            Console.WriteLine(template,
                "Id", "Nome", "Email", "Telefone", "Empresa", "Cargo");
            Console.WriteLine();

            if (contatos.Length == 0)
            {
                Console.WriteLine("Nenhum contato encontrado");
                return;
            }

            foreach (Contato contato in contatos)
            {
                Console.WriteLine(template,
                    contato.Id,
                    contato.Nome,
                    contato.Email,
                    contato.Telefone,
                    contato.Empresa,
                    contato.Cargo);
            }
        }

        protected void VisualizarTodosContatos()
        {
            Contato[] contatos = controladorContato
                .BuscarRegistros()
                .OrderBy(contato => contato.Cargo.ToLower())
                .ToArray();

            VisualizarContatos(contatos);
        }

        protected int ObterIdContato(Contato[] contatos)
        {
            VisualizarContatos(contatos);
            Console.WriteLine();

            ImprimirMensagem("Digite o id do contato que deseja selecionar: ", TipoMensagem.INPUT);
            int id = LerInt();

            if (!ExisteContatoComId(contatos, id))
                return -1;
            else
                return id;
        }

        protected int ObterIdContato()
        {
            Contato[] contatos = controladorContato
                .BuscarRegistros()
                .OrderBy(contato => contato.Cargo.ToLower())
                .ToArray();

            return ObterIdContato(contatos);
        }

        private bool ExisteContatoComId(Contato[] contatos, int id)
        {
            return contatos.FirstOrDefault(contato => contato.Id == id) != null;
        }

        private string LerEmail()
        {
            while (true)
            {
                string email = LerString();

                if (EmailTemCaracteresNecessarios(email)
                    && CaracteresEspeciaisEstaoNaOrdem(email)
                    && PontoNaoTaNoFinal(email))
                {
                    return email;
                }
                else
                    ImprimirMensagem("Email digitado não é valido!", TipoMensagem.ERRO);
            }
        }

        private string LerTelefone()
        {
            ImprimirMensagem("Digite o DDD do telefone: ", TipoMensagem.INPUT);
            int ddd = LerNoIntervalo(10, 99);

            ImprimirMensagem("Digite os numeros do telefone (sem o 9): ", TipoMensagem.INPUT);
            string numerosTelefone = LerStringComTamanho(8);

            string telefone = $"({ddd}) 9 {numerosTelefone.Substring(0, 4)}-{numerosTelefone.Substring(4, 4)}";

            return telefone;
        }

        private bool PontoNaoTaNoFinal(string email)
        {
            return email.IndexOf('.') != email.Length - 1;
        }

        private bool CaracteresEspeciaisEstaoNaOrdem(string email)
        {
            return email.IndexOf('@') < email.IndexOf('.');
        }

        private bool EmailTemCaracteresNecessarios(string email)
        {
            return email.Contains("@") && email.Contains(".");
        }
    }
}
