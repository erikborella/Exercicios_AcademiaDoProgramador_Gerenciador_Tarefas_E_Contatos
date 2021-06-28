using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ControleDeTarefas.Controladores;
using ControleDeTarefas.Telas.Base;
using ControleDeTarefas.Telas.Contatos;

using ControleDeTarefas.Dominios;

namespace ControleDeTarefas.Telas.Compromissos.Visualizar
{
    class TelaCompromissosVisualizarFuturos : TelaCompromissos
    {
        public TelaCompromissosVisualizarFuturos(ControladorCompromisso controladorCompromisso, 
            TelaContatos telaContatos)
            : base("Visualizar fututos", controladorCompromisso, telaContatos)
        {
        }

        public override TelaBase Executar()
        {
            Console.Clear();

            DateTime diaAVisualizar = LerDiaAVisualizar();

            Compromisso[] compromissos = ObterCompromissosDoDia(diaAVisualizar);

            Console.Clear();

            VisualizarCompromissos(compromissos);

            Pausar();

            return null;
        }

        private DateTime LerDiaAVisualizar()
        {
            DateTime diaAVisualizar;
            ImprimirMensagem("Deseja ver os compromissos de hoje: (S/N)", TipoMensagem.INPUT);

            string escolha = Console.ReadLine();

            if (escolha.Equals("s", StringComparison.OrdinalIgnoreCase))
            {
                diaAVisualizar = DateTime.Now.Date;
            }
            else
            {
                ImprimirMensagem("Digite a data em que deseja visualizar: ", TipoMensagem.INPUT);
                diaAVisualizar = LerDataFutura();
            }

            return diaAVisualizar;
        }

        private Compromisso[] ObterCompromissosDoDia(DateTime diaAVisualizar)
        {
            return controladorCompromisso.BuscarRegistros()
                            .Where(compromisso => compromisso.Data == diaAVisualizar)
                            .ToArray();
        }

        private DateTime LerDataFutura()
        {
            while (true)
            {
                DateTime data = LerData();

                if (data < DateTime.Now)
                {
                    ImprimirMensagem("Voce digitou uma data no passado\n" +
                        "Por favor, digite uma data no futuro", TipoMensagem.ERRO);
                    continue;
                }

                return data;
            }
        }
    }
}
