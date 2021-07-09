using ControleDeTarefas.Controladores;
using ControleDeTarefas.Dominios;
using ControleDeTarefas.Telas.Base;
using System;

namespace ControleDeTarefas.Telas.Contatos
{
    class TelaContatosCriar : TelaContatos
    {
        public TelaContatosCriar(ControladorContato controladorContato)
            : base("Criar novo contato", controladorContato)
        {
        }

        public override TelaBase Executar()
        {
            Console.Clear();

            ContatoModelo novoContato = ObterContato();

            bool conseguiuCriar = controladorContato.Inserir(novoContato);

            if (conseguiuCriar)
                ImprimirMensagem("Novo contato criado com sucesso", TipoMensagem.SUCESSO);
            else
                ImprimirMensagem("Erro ao criar contato", TipoMensagem.ERRO);

            Pausar();

            return null;
        }
    }
}
