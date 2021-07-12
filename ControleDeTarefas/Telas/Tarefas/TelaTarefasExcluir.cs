using ControleDeTarefas.Controladores.Legado;
using ControleDeTarefas.Telas.Base;
using System;

namespace ControleDeTarefas.Telas.Tarefas
{
    class TelaTarefasExcluir : TelaTarefas
    {
        public TelaTarefasExcluir(ControladorTarefa controladorTarefa)
            : base("Excluir Tarefas", controladorTarefa)
        {
        }

        public override TelaBase Executar()
        {
            Console.Clear();

            int id = ObterIdTarefa();

            if (id == -1)
            {
                ImprimirMensagem("O id digitado não corresponde a nenhuma tarefa", TipoMensagem.ERRO);
                Pausar();
                return null;
            }

            bool conseguiuExcluir = controladorTarefa.Excluir(id);

            if (conseguiuExcluir)
                ImprimirMensagem("Tarefa excluida com sucesso", TipoMensagem.SUCESSO);
            else
                ImprimirMensagem("Erro ao excluir tarefa", TipoMensagem.ERRO);

            Pausar();

            return null;
        }
    }
}
