
using ControleDeTarefas.Controladores;
using ControleDeTarefas.Telas;
using ControleDeTarefas.Telas.Base;
using System;

using ControleDeTarefas.Dominios;
using System.Reflection;

namespace ControleDeTarefas
{
    class Program
    {
        static void Main(string[] args)
        {
            TelaPrincipal telaPrincipal = new TelaPrincipal();
            ExecutarMenu(telaPrincipal);
        }

        private static void ExecutarMenu(TelaBase tela)
        {
            while (true)
            {
                TelaBase proximaTela = tela.Executar();

                if (proximaTela is OpcaoVoltar || proximaTela == null)
                    break;

                ExecutarMenu(proximaTela);
            }
        }

    }
}
