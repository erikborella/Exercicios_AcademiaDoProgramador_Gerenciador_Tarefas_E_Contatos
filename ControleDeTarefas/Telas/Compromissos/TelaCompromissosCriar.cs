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
    class TelaCompromissosCriar : TelaCompromissos
    {
        public TelaCompromissosCriar(ControladorCompromisso controladorCompromisso, TelaContatos telaContatos)
            : base("Criar novo compromisso", controladorCompromisso, telaContatos)
        {

        }

        public override TelaBase Executar()
        {
            Console.Clear();

            Compromisso novoCompromisso = ObterCompromisso();

            bool conseguiuCriar = controladorCompromisso.Inserir(novoCompromisso);

            if (conseguiuCriar)
                ImprimirMensagem("Novo compromisso criado com sucesso", TipoMensagem.SUCESSO);
            else
                ImprimirMensagem("Erro ao criar compromisso", TipoMensagem.ERRO);

            Pausar();
            return null;
        }
    }
}
