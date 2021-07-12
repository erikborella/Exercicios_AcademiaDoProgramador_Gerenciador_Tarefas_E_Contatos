using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleDeTarefas.Telas.Contatos;
using ControleDeTarefas.Telas.Base;
using ControleDeTarefas.Controladores.Legado;
using ControleDeTarefas.Dominios;

namespace ControleDeTarefas.Telas.Compromissos.Visualizar
{
    class TelaCompromissosVisualizarPassados : TelaCompromissos
    {
        public TelaCompromissosVisualizarPassados(ControladorCompromisso controladorCompromisso, 
            TelaContatos telaContatos) 
            : base("Visualizar passados", controladorCompromisso, telaContatos)
        {
        }

        public override TelaBase Executar()
        {
            Compromisso[] compromissosPassados = ObterCompromissosPassados();

            Console.Clear();

            VisualizarCompromissos(compromissosPassados);

            Pausar();
            return null;
        }

        private Compromisso[] ObterCompromissosPassados()
        {
            DateTime dataAgora = DateTime.Now;

            Compromisso[] compromissosPassados = controladorCompromisso.BuscarRegistros()
                .Where(compromisso => compromisso.Data < dataAgora)
                .ToArray();
            return compromissosPassados;
        }
    }
}
