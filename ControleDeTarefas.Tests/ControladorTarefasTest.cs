using ControleDeTarefas.Controladores;
using ControleDeTarefas.Dominios;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ControleDeTarefas.Tests
{
    [TestClass]
    public class ControladorTarefasTest
    {
        private ControladorTarefa controladorTarefa;

        public ControladorTarefasTest()
        {
            controladorTarefa = new ControladorTarefa();
        }

        [TestMethod]
        public void DeveInserirNovaTarefa()
        {
            Tarefa novaTarefa =
                new Tarefa("TESTAR", PrioridadeTarefa.BAIXA);

            bool conseguiuInserir = controladorTarefa.Inserir(novaTarefa);

            Assert.IsTrue(conseguiuInserir);
            Assert.IsTrue(novaTarefa.Id > 0);
        }

        [TestMethod]
        public void DeveEditarTarefa()
        {
            Tarefa tarefa =
                new Tarefa("TESTAR", PrioridadeTarefa.BAIXA);
            controladorTarefa.Inserir(tarefa);

            Tarefa novaTarefa =
                new Tarefa("EDITADO", PrioridadeTarefa.MEDIA);
            novaTarefa.Id = tarefa.Id;

            bool conseguiuEditar = controladorTarefa.Editar(novaTarefa);
            Tarefa tarefaRecuperada = controladorTarefa.BuscarRegistroPorId(tarefa.Id);

            Assert.IsTrue(conseguiuEditar);

            Assert.AreEqual(novaTarefa.Id, tarefaRecuperada.Id);
            Assert.AreEqual(novaTarefa.Titulo, tarefaRecuperada.Titulo);
            Assert.AreEqual(novaTarefa.DataCriacao.ToString(), tarefaRecuperada.DataCriacao.ToString());
            Assert.AreEqual(novaTarefa.DataConclusao.ToString(), tarefaRecuperada.DataConclusao.ToString());
            Assert.AreEqual(novaTarefa.PercentualConcluido, tarefaRecuperada.PercentualConcluido);
            Assert.AreEqual(novaTarefa.Prioridade, tarefaRecuperada.Prioridade);
        }

        [TestMethod]
        public void DeveMudarPercentualConcluidoTarefa()
        {
            Tarefa tarefa =
                new Tarefa("TESTAR", PrioridadeTarefa.BAIXA);
            controladorTarefa.Inserir(tarefa);

            bool conseguiuMudar = controladorTarefa.AtualizarPercentualConcluido(tarefa.Id, 80);

            Tarefa tarefaRecuperada = controladorTarefa.BuscarRegistroPorId(tarefa.Id);

            Assert.IsTrue(conseguiuMudar);
            Assert.AreEqual(tarefaRecuperada.PercentualConcluido, 80);
        }

        [TestMethod]
        public void DeveCompletarTarefa()
        {
            Tarefa tarefa =
                new Tarefa("TESTAR", PrioridadeTarefa.BAIXA);
            controladorTarefa.Inserir(tarefa);

            bool conseguiuMudar = controladorTarefa.AtualizarPercentualConcluido(tarefa.Id, 100);

            Tarefa tarefaRecuperada = controladorTarefa.BuscarRegistroPorId(tarefa.Id);

            Assert.IsTrue(conseguiuMudar);
            Assert.IsNotNull(tarefaRecuperada.DataConclusao);
        }

        [TestMethod]
        public void DeveExcluirTarefa()
        {
            Tarefa tarefa =
                new Tarefa("TESTAR", PrioridadeTarefa.BAIXA);
            controladorTarefa.Inserir(tarefa);

            bool conseguiuExcluir = controladorTarefa.Excluir(tarefa.Id);

            Tarefa tarefaRecuperda = controladorTarefa.BuscarRegistroPorId(tarefa.Id);

            Assert.IsTrue(conseguiuExcluir);
            Assert.IsNull(tarefaRecuperda);
        }

        [TestMethod]
        public void DeveBuscarTarefaPorId()
        {
            Tarefa tarefa =
                new Tarefa("TESTAR", PrioridadeTarefa.BAIXA);

            controladorTarefa.Inserir(tarefa);

            int id = tarefa.Id;

            Tarefa tarefaRecuperada = controladorTarefa.BuscarRegistroPorId(id);

            Assert.AreEqual(tarefa.Id, tarefaRecuperada.Id);
            Assert.AreEqual(tarefa.Titulo, tarefaRecuperada.Titulo);
            Assert.AreEqual(tarefa.DataCriacao.ToString(), tarefaRecuperada.DataCriacao.ToString());
            Assert.AreEqual(tarefa.DataConclusao.ToString(), tarefaRecuperada.DataConclusao.ToString());
            Assert.AreEqual(tarefa.PercentualConcluido, tarefaRecuperada.PercentualConcluido);
            Assert.AreEqual(tarefa.Prioridade, tarefaRecuperada.Prioridade);
        }

        [TestMethod]
        public void DeveBuscarTodasTarefas()
        {
            Tarefa tarefa =
                new Tarefa("TESTAR", PrioridadeTarefa.BAIXA);

            controladorTarefa.Inserir(tarefa);

            Tarefa[] tarefasRecuperadas = controladorTarefa.BuscarRegistros();

            Assert.IsTrue(tarefasRecuperadas.Length >= 1);
        }
    }
}
