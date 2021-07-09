using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ControleDeTarefas.Query;
using ControleDeTarefas.Dominios;

namespace ControleDeTarefas.Controladores
{
    public class ControladorContato
    {
        public bool Inserir(ContatoModelo contato)
        {
            int id = contato
                .SQL()
                .Inserir()
                .TodosOsCampos()
                .Executar();

            contato.Id = id;

            return id != 0;
        }

        public bool Editar(ContatoModelo contato)
        {
            bool sucesso = contato
                .SQL()
                .Atualizar()
                .TodosOsCampos()
                .NoMesmoId()
                .Executar();

            return sucesso;
        }

        public bool Excluir(int id)
        {
            ContatoModelo modelo = new ContatoModelo();

            bool sucesso = modelo
                .SQL()
                .Deletar()
                .Onde(modelo.campoId).EhIgualA(id)
                .Executar();

            return sucesso;
        }

        public ContatoModelo BuscarRegistroPorId(int id)
        {
            ContatoModelo modelo = new ContatoModelo();

            ContatoModelo[] modelos = modelo
                .SQL()
                .Selecionar()
                .TodosOsCampos()
                .Onde(modelo.campoId).EhIgualA(id)
                .Converter<ContatoModelo>();

            if (modelos.Length == 0)
                return null;
            else
                return modelos[0];
        }

        public ContatoModelo[] BuscarRegistros()
        {
            ContatoModelo modelo = new ContatoModelo();

            ContatoModelo[] modelos = modelo
                .SQL()
                .Selecionar()
                .TodosOsCampos()
                .Converter<ContatoModelo>();

            return modelos;
        }
    }
}
