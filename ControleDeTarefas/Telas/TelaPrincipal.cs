
using ControleDeTarefas.Controladores;
using ControleDeTarefas.Telas.Base;
using ControleDeTarefas.Telas.Contatos;
using ControleDeTarefas.Telas.Tarefas;

namespace ControleDeTarefas.Telas
{
    class TelaPrincipal : TelaBase
    {
        public TelaPrincipal() : base("Gerenciador de tarefas e contatos")
        {
            ControladorTarefa controladorTarefa = new ControladorTarefa();
            ControladorContato controladorContato = new ControladorContato();

            AdicionarOpcao(new TelaTarefas(controladorTarefa));
            AdicionarOpcao(new TelaContatos(controladorContato));
        }
    }
}
