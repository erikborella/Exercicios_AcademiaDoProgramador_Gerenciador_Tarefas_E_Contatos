using ControleDeTarefas.Controladores.Legado;
using ControleDeTarefas.Telas.Base;
using System;

namespace ControleDeTarefas.Telas.Contatos
{
    class TelaContatosExcluir : TelaContatos
    {
        public TelaContatosExcluir(ControladorContato controladorContato)
            : base("Excluir contato", controladorContato)
        {
        }

        public override TelaBase Executar()
        {
            Console.Clear();

            int id = ObterIdContato();

            if (IdNaoEncontrado(id))
            {
                ImprimirMensagem("Id Digitado não corresponde a nenhum contato", TipoMensagem.ERRO);
                Pausar();
                return null;
            }

            bool conseguiuExcluir = controladorContato.Excluir(id);

            if (conseguiuExcluir)
                ImprimirMensagem("Contato excluido com sucesso", TipoMensagem.SUCESSO);
            else
                ImprimirMensagem("Erro ao excluir contato", TipoMensagem.ERRO);

            Pausar();

            return null;
        }

        private static bool IdNaoEncontrado(int id)
        {
            return id == -1;
        }
    }
}
