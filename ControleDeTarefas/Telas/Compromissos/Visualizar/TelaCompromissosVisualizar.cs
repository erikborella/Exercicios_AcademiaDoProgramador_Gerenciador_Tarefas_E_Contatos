using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ControleDeTarefas.Telas.Contatos;
using ControleDeTarefas.Controladores;

namespace ControleDeTarefas.Telas.Compromissos.Visualizar
{
    class TelaCompromissosVisualizar : TelaCompromissos
    {
        public TelaCompromissosVisualizar(ControladorCompromisso controladorCompromisso, TelaContatos telaContatos) 
            : base("Visualizar compromissos", controladorCompromisso, telaContatos)
        {
            AdicionarOpcao(new TelaCompromissosVisualizarFuturos(controladorCompromisso, telaContatos));
            AdicionarOpcao(new TelaCompromissosVisualizarPassados(controladorCompromisso, telaContatos));
            AdicionarOpcao(new TelaCompromissosVisualizarTodos(controladorCompromisso, telaContatos));
        }
    }
}
