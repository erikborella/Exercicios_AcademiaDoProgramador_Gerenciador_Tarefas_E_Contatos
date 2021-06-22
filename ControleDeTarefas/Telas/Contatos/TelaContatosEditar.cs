using ControleDeTarefas.Controladores;
using ControleDeTarefas.Dominios;
using ControleDeTarefas.Telas.Base;
using System;

namespace ControleDeTarefas.Telas.Contatos
{
    class TelaContatosEditar : TelaContatos
    {
        public TelaContatosEditar(ControladorContato controladorContato)
            : base("Editar contato", controladorContato)
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

            Contato novoContato = ObterContato();
            novoContato.Id = id;

            bool conseguiuEditar = controladorContato.Editar(novoContato);

            if (conseguiuEditar)
                ImprimirMensagem("Contato editado com sucesso", TipoMensagem.SUCESSO);
            else
                ImprimirMensagem("Erro ao editar contato", TipoMensagem.ERRO);

            Pausar();

            return null;
        }

        private bool IdNaoEncontrado(int id)
        {
            return id == -1;
        }
    }
}
