using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ControleDeTarefas.Telas.Base;
using ControleDeTarefas.Controladores;
using ControleDeTarefas.Telas.Contatos;
using ControleDeTarefas.Telas.Compromissos.Visualizar;
using ControleDeTarefas.Dominios;

namespace ControleDeTarefas.Telas.Compromissos
{
    class TelaCompromissos : TelaBase
    {
        protected ControladorCompromisso controladorCompromisso;
        protected TelaContatos telaContatos;

        public TelaCompromissos(ControladorCompromisso controladorCompromisso, TelaContatos telaContatos) 
            : base("Compromissos")
        {
            this.controladorCompromisso = controladorCompromisso;
            this.telaContatos = telaContatos;

            AdicionarOpcao(new TelaCompromissosCriar(controladorCompromisso, telaContatos));
            AdicionarOpcao(new TelaCompromissosEditar(controladorCompromisso, telaContatos));
            AdicionarOpcao(new TelaCompromissosExcluir(controladorCompromisso, telaContatos));
            AdicionarOpcao(new TelaCompromissosVisualizar(controladorCompromisso, telaContatos));
        }

        protected TelaCompromissos(string descricao, 
            ControladorCompromisso controladorCompromisso, TelaContatos telaContatos)
            : base(descricao)
        {
            this.controladorCompromisso = controladorCompromisso;
            this.telaContatos = telaContatos;
        }

        protected Compromisso ObterCompromisso()
        {
            string assunto, local;
            DateTime data;
            TimeSpan horaInicial, horaFinal;
            int contatoId;

            ImprimirMensagem("Digite o assunto: ", TipoMensagem.INPUT);
            assunto = LerString();

            ImprimirMensagem("Digite o local ou o link: ", TipoMensagem.INPUT);
            local = LerString();

            ImprimirMensagem("Digite a data do compromisso: ", TipoMensagem.INPUT);
            data = LerDataEmDiaComercial();

            ImprimirMensagem("Digite a hora de inicio: ", TipoMensagem.INPUT);
            horaInicial = LerHoraSemConflito(data);

            ImprimirMensagem("Digite a hora de termino: ", TipoMensagem.INPUT);
            horaFinal = LerHoraSemConflito(data, horaInicial);

            contatoId = ObterContatoId();

            Contato contatoTemp = null;

            if (contatoId != -1)
                contatoTemp = new Contato(contatoId);

            return new Compromisso(assunto, local, data, horaInicial, horaFinal, contatoTemp);
        }

        public void VisualizarCompromissos(Compromisso[] compromissos)
        {
            string[] nomesColunas =
            {
                "Id", 
                "Assunto", 
                "Local", 
                "Data", 
                "Hora de inicio", 
                "Hora de termino", 
                "Nome contato", 
                "Telefone contato"
            };

            Func<Compromisso, object[]> obterValoresLinha = (compromisso) =>
            {
                return new object[]
                {
                    compromisso.Id,
                    compromisso.Assunto,
                    compromisso.Local,
                    compromisso.Data.ToShortDateString(),
                    compromisso.HoraInicial,
                    compromisso.HoraFinal,
                    (compromisso.Contato != null) ? compromisso.Contato.Nome:"Sem contato",
                    (compromisso.Contato != null) ? compromisso.Contato.Telefone:"Sem contato"
                };
            };

            ImprimirRegistros(nomesColunas, compromissos, obterValoresLinha);
        }

        public void VisualizarTodosCompromissos()
        {
            Compromisso[] compromissos = controladorCompromisso
                .BuscarRegistros()
                .ToArray();

            VisualizarCompromissos(compromissos);
        }

        public int ObterIdCompromisso(Compromisso[] compromissos)
        {
            VisualizarCompromissos(compromissos);
            Console.WriteLine();

            ImprimirMensagem("Digite o id do compromisso que deseja selecionar: ", TipoMensagem.INPUT);
            int id = LerInt();

            if (!ExisteCompromissoComId(compromissos, id))
                return -1;
            else
                return id;
        }

        public int ObterIdCompromisso()
        {
            Compromisso[] compromissos = controladorCompromisso
                .BuscarRegistros()
                .ToArray();

            return ObterIdCompromisso(compromissos);
        }

        private TimeSpan LerHoraSemConflito(DateTime data, TimeSpan? horarioMinimo = null)
        {
            while (true)
            {
                TimeSpan hora = LerHora();

                if (horarioMinimo != null && hora <= horarioMinimo)
                {
                    ImprimirMensagem("Você não pode definir a hora de termimo para antes do horario de inicio", 
                        TipoMensagem.ERRO);
                    continue;
                }

                Compromisso conflitante = CompromissoConflitante(data, hora);

                if (conflitante == null)
                    return hora;

                else
                {
                    ImprimirMensagem($"A hora entra em conflito com o compromisso: " +
                        $"{conflitante.Assunto} : {conflitante.Data} " +
                        $"{conflitante.HoraInicial} - {conflitante.HoraFinal}\n" +
                        "Por favor, tente novamente", TipoMensagem.ERRO);
                    continue;
                }
            }
        }

        private bool ExisteCompromissoComId(Compromisso[] compromissos, int id)
        {
            return compromissos.FirstOrDefault(compromisso => compromisso.Id == id) != null;
        }

        private int ObterContatoId()
        {
            ImprimirMensagem("Deseja incluir algum contato? (S/N): ", TipoMensagem.INPUT);
            string escolha = Console.ReadLine();

            if (!escolha.Equals("S", StringComparison.OrdinalIgnoreCase))
                return -1;

            while (true)
            {
                int contatoId = telaContatos.ObterIdContato();

                if (contatoId == -1)
                {
                    ImprimirMensagem("Você digitou um id invalido, tente novamente", TipoMensagem.ERRO);
                    Pausar();
                    continue;
                }

                return contatoId;
            }
        }

        private DateTime LerDataEmDiaComercial()
        {
            while (true)
            {
                DateTime data = LerData();

                if (data.DayOfWeek == DayOfWeek.Saturday)
                {
                    ImprimirMensagem("Você não pode definir um compromisso no sabado!", TipoMensagem.ERRO);
                    continue;
                }

                if (data.DayOfWeek == DayOfWeek.Sunday)
                {
                    ImprimirMensagem("Você não pode definir um compromisso no domingo!", TipoMensagem.ERRO);
                    continue;
                }

                return data;
            }
        }

        private Compromisso CompromissoConflitante(DateTime data, 
            TimeSpan hora)
        {
            Compromisso[] compromissos = controladorCompromisso.BuscarRegistros();

            Compromisso conflitante = compromissos.FirstOrDefault(compromisso =>
            {
                if (compromisso.Data != data)
                    return false;

                if (hora >= compromisso.HoraInicial && hora <= compromisso.HoraFinal)
                    return true;

                return false;
            });

            return conflitante;
        }
    }
}
