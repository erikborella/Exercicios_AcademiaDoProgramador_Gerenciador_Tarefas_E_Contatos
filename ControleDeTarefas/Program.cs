using ControleDeTarefas.Telas.Base;
using ControleDeTarefas.Telas;
using System.Collections.Generic;
using System;
using ControleDeTarefas.Controladores;
using ControleDeTarefas.Query;

using System.Configuration;
using ControleDeTarefas.Dominios;

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
