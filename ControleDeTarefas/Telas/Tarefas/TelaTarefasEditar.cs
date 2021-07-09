using ControleDeTarefas.Controladores;
using ControleDeTarefas.Dominios;
using ControleDeTarefas.Telas.Base;
using System;

namespace ControleDeTarefas.Telas.Tarefas
{
    class TelaTarefasEditar : TelaTarefas
    {
        public TelaTarefasEditar(ControladorTarefa controladorTarefa) : base("Editar tarefa", controladorTarefa)
        {
        }

        public override TelaBase Executar()
        {
            Console.Clear();

            int id = ObterIdTarefa();

            if (IdNaoEncontrado(id))
            {
                ImprimirMensagem("Id digitado não corresponde a nenhuma tarefa", TipoMensagem.ERRO);
                Pausar();
                return null;
            }

            TarefaModelo novaTarefa = ObterTarefa();
            novaTarefa.Id = id;

            bool conseguiuEditar = controladorTarefa.Editar(novaTarefa);

            if (conseguiuEditar)
                ImprimirMensagem("Tarefa editada com sucesso", TipoMensagem.SUCESSO);
            else
                ImprimirMensagem("Erro ao editar tarefa", TipoMensagem.ERRO);

            Pausar();

            return null;
        }

        public bool IdNaoEncontrado(int id)
        {
            return id == -1;
        }
    }
}
