using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ControleDeTarefas.Controladores;
using ControleDeTarefas.Telas.Base;
using ControleDeTarefas.Telas.Contatos;
using ControleDeTarefas.Dominios;

namespace ControleDeTarefas.Telas.Compromissos
{
    class TelaCompromissosEditar : TelaCompromissos
    {
        public TelaCompromissosEditar(ControladorCompromisso controladorCompromisso, TelaContatos telaContatos)
            : base("Editar compromissos", controladorCompromisso, telaContatos)
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

            Compromisso novoCompromisso = ObterCompromisso();
            novoCompromisso.Id = id;

            bool conseguiuEditar = controladorCompromisso.Editar(novoCompromisso);

            if (conseguiuEditar)
                ImprimirMensagem("Compromisso editado com sucesso", TipoMensagem.SUCESSO);
            else
                ImprimirMensagem("Erro ao editar compromisso", TipoMensagem.ERRO);

            Pausar();

            return null;
        }

        private bool IdNaoEncontrado(int id)
        {
            return id == -1;
        }
    }
}
