using ControleDeTarefas.Controladores.Legado;
using ControleDeTarefas.Dominios;
using ControleDeTarefas.Telas.Base;
using System;

namespace ControleDeTarefas.Telas.Tarefas
{
    class TelaTarefasCriar : TelaTarefas
    {
        public TelaTarefasCriar(ControladorTarefa controladorTarefa) : base("Criar Nova Tarefa", controladorTarefa)
        {
        }

        public override TelaBase Executar()
        {
            Console.Clear();

            Tarefa novaTarefa = ObterTarefa();

            bool conseguiuCriar = controladorTarefa.Inserir(novaTarefa);

            if (conseguiuCriar)
                ImprimirMensagem("Nova tarefa criada com sucesso", TipoMensagem.SUCESSO);
            else
                ImprimirMensagem("Erro ao criar tarefa", TipoMensagem.ERRO);

            Pausar();

            return null;
        }
    }
}
