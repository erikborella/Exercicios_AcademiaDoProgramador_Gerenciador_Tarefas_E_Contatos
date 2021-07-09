
using ControleDeTarefas.Controladores;
using ControleDeTarefas.Telas.Base;
using ControleDeTarefas.Telas.Contatos;
using ControleDeTarefas.Telas.Tarefas;
using ControleDeTarefas.Telas.Compromissos;

namespace ControleDeTarefas.Telas
{
    class TelaPrincipal : TelaBase
    {
        public TelaPrincipal() : base("Gerenciador de tarefas e contatos")
        {
            ControladorTarefa controladorTarefa = new ControladorTarefa();
            ControladorContato controladorContato = new ControladorContato();
            ControladorCompromisso controladorCompromisso = new ControladorCompromisso();

            TelaTarefas telaTarefas = new TelaTarefas(controladorTarefa);
            TelaContatos telaContatos = new TelaContatos(controladorContato);
            TelaCompromissos telaCompromissos = new TelaCompromissos(controladorCompromisso, telaContatos);

            AdicionarOpcao(telaTarefas);
            AdicionarOpcao(telaContatos);
            AdicionarOpcao(telaCompromissos);
        }
    }
}
