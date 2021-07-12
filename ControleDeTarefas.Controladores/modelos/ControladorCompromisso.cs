using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleDeTarefas.Dominios.Modelos;
using ControleDeTarefas.Query;

namespace ControleDeTarefas.Controladores.modelos
{
    public class ControladorCompromisso
    {
        public bool Inserir(CompromissoModelo compromisso)
        {
            int id = compromisso
                .SQL()
                .Inserir()
                .TodosOsCampos()
                .Executar();

            compromisso.Id = id;

            return id != 0;
        }

        public bool Editar(CompromissoModelo compromisso)
        {
            bool sucesso = compromisso
                .SQL()
                .Atualizar()
                .TodosOsCampos()
                .NoMesmoId()
                .Executar();

            return sucesso;
        }

        public bool Excluir(int id)
        {
            CompromissoModelo modelo = new CompromissoModelo();

            bool sucesso = modelo
                .SQL()
                .Deletar()
                .Onde(modelo.campoId).EhIgualA(id)
                .Executar();


            return sucesso;
        }

        public CompromissoModelo BuscarRegistroPorId(int id)
        {
            CompromissoModelo modelo = new CompromissoModelo()
            {
                Contato = new ContatoModelo()
            };

            CompromissoModelo[] modelos = modelo
                .SQL()
                .Selecionar()
                .TodosOsCampos()
                .JunteCom(modelo.campoContato).JuncaoEsquerda()
                .Onde(modelo.campoId).EhIgualA(id)
                .ConverterRecursivamente<CompromissoModelo, ContatoModelo>();

            if (modelos.Length == 0)
                return null;
            else
                return modelos[0];
        }

        public CompromissoModelo[] BuscarRegistros()
        {
            CompromissoModelo modelo = new CompromissoModelo()
            {
                Contato = new ContatoModelo()
            };

            CompromissoModelo[] modelos = modelo
                .SQL()
                .Selecionar()
                .TodosOsCampos()
                .JunteCom(modelo.campoContato).JuncaoEsquerda()
                .ConverterRecursivamente<CompromissoModelo, ContatoModelo>();

            return modelos;
        }
    }
}
