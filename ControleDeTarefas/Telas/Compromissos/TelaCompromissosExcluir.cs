using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleDeTarefas.Telas.Base;
using ControleDeTarefas.Telas.Contatos;
using ControleDeTarefas.Dominios;
using ControleDeTarefas.Controladores;

namespace ControleDeTarefas.Telas.Compromissos
{
    class TelaCompromissosExcluir : TelaCompromissos
    {
        public TelaCompromissosExcluir(ControladorCompromisso controladorCompromisso, TelaContatos telaContato)
            : base("Excluir compromisso", controladorCompromisso, telaContato)
        {
        }

        public override TelaBase Executar()
        {
            Console.Clear();

            int id = ObterIdCompromisso();

            if (IdNaoEncontrado(id))
            {
                ImprimirMensagem("Id Digitado não corresponde a nenhum compromisso", TipoMensagem.ERRO);
                Pausar();
                return null;
            }

            bool conseguiuExcluir = controladorCompromisso.Excluir(id);

            if (conseguiuExcluir)
                ImprimirMensagem("Compromisso excluido com sucesso", TipoMensagem.SUCESSO);
            else
                ImprimirMensagem("Erro ao excluir compromisso", TipoMensagem.ERRO);

            Pausar();

            return null;
        }

        private bool IdNaoEncontrado(int id)
        {
            return id == -1;
        }
    }
}
