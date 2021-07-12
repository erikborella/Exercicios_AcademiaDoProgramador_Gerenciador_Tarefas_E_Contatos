using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleDeTarefas.Dominios.Modelos;
using ControleDeTarefas.Query;

namespace ControleDeTarefas.Controladores.modelos
{
    public class ControladorTarefa
    {
        public bool Inserir(TarefaModelo tarefa)
        {
            int id = tarefa
                .SQL()
                .Inserir()
                .TodosOsCampos()
                .Executar();

            tarefa.Id = id;

            return id != 0;
        }

        public bool Editar(TarefaModelo tarefa)
        {
            bool sucesso = tarefa
                .SQL()
                .Atualizar()
                .Campos(tarefa.campoTitulo, tarefa.campoPrioridade)
                .NoMesmoId()
                .Executar();

            return sucesso;
        }

        public bool Excluir(int id)
        {
            TarefaModelo modelo = new TarefaModelo();

            bool sucesso = modelo
                .SQL()
                .Deletar()
                .Onde(modelo.campoId).EhIgualA(id)
                .Executar();

            return sucesso;
        }

        public TarefaModelo BuscarRegistroPorId(int id)
        {
            TarefaModelo modelo = new TarefaModelo();

            TarefaModelo[] modelos = modelo
                .SQL()
                .Selecionar()
                .TodosOsCampos()
                .Onde(modelo.campoId).EhIgualA(id)
                .Converter<TarefaModelo>();

            if (modelos.Length == 0)
                return null;
            else
                return modelos[0];
        }

        public TarefaModelo[] BuscarRegistros()
        {
            TarefaModelo modelo = new TarefaModelo();

            TarefaModelo[] modelos = modelo
                .SQL()
                .Selecionar()
                .TodosOsCampos()
                .Converter<TarefaModelo>();

            return modelos;
        }

        public bool AtualizarPercentualConcluido(int id, int percentual)
        {
            if (percentual == 100)
                ConcluirTarefa(id);

            TarefaModelo modelo = new TarefaModelo();

            modelo.PercentualConcluido = percentual;
            modelo.Id = id;

            bool sucesso = modelo
                .SQL()
                .Atualizar()
                .Campos(modelo.campoPercentualConcluido)
                .NoMesmoId()
                .Executar();

            return sucesso;
        }

        private void ConcluirTarefa(int id)
        {
            DateTime dataConclusao = DateTime.Now;

            TarefaModelo modelo = new TarefaModelo();

            modelo.Id = id;
            modelo.DataConclusao = dataConclusao;

            modelo
                .SQL()
                .Atualizar()
                .Campos(modelo.campoDataConclusao)
                .NoMesmoId()
                .Executar();
        }
    }
}
