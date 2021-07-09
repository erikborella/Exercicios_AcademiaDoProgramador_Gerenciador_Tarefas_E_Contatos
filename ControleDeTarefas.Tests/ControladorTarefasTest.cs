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
            TarefaModelo novaTarefa =
                new TarefaModelo("TESTAR", PrioridadeTarefa.BAIXA);

            bool conseguiuInserir = controladorTarefa.Inserir(novaTarefa);

            Assert.IsTrue(conseguiuInserir);
            Assert.IsTrue(novaTarefa.Id > 0);
        }

        [TestMethod]
        public void DeveEditarTarefa()
        {
            TarefaModelo tarefa =
                new TarefaModelo("TESTAR", PrioridadeTarefa.BAIXA);
            controladorTarefa.Inserir(tarefa);

            TarefaModelo novaTarefa =
                new TarefaModelo("EDITADO", PrioridadeTarefa.MEDIA);
            novaTarefa.Id = tarefa.Id;

            bool conseguiuEditar = controladorTarefa.Editar(novaTarefa);
            TarefaModelo tarefaRecuperada = controladorTarefa.BuscarRegistroPorId(tarefa.Id);

            Assert.IsTrue(conseguiuEditar);

            Assert.AreEqual(novaTarefa.Id, tarefaRecuperada.Id);
            Assert.AreEqual(novaTarefa.Titulo, tarefaRecuperada.Titulo);
            Assert.AreEqual(novaTarefa.DataCriacao.Date.ToString(), tarefaRecuperada.DataCriacao.Date.ToString());
            Assert.AreEqual(novaTarefa.DataConclusao.ToString(), tarefaRecuperada.DataConclusao.ToString());
            Assert.AreEqual(novaTarefa.PercentualConcluido, tarefaRecuperada.PercentualConcluido);
            Assert.AreEqual(novaTarefa.Prioridade, tarefaRecuperada.Prioridade);
        }

        [TestMethod]
        public void DeveMudarPercentualConcluidoTarefa()
        {
            TarefaModelo tarefa =
                new TarefaModelo("TESTAR", PrioridadeTarefa.BAIXA);
            controladorTarefa.Inserir(tarefa);

            bool conseguiuMudar = controladorTarefa.AtualizarPercentualConcluido(tarefa.Id, 80);

            TarefaModelo tarefaRecuperada = controladorTarefa.BuscarRegistroPorId(tarefa.Id);

            Assert.IsTrue(conseguiuMudar);
            Assert.AreEqual(tarefaRecuperada.PercentualConcluido, 80);
        }

        [TestMethod]
        public void DeveCompletarTarefa()
        {
            TarefaModelo tarefa =
                new TarefaModelo("TESTAR", PrioridadeTarefa.BAIXA);
            controladorTarefa.Inserir(tarefa);

            bool conseguiuMudar = controladorTarefa.AtualizarPercentualConcluido(tarefa.Id, 100);

            TarefaModelo tarefaRecuperada = controladorTarefa.BuscarRegistroPorId(tarefa.Id);

            Assert.IsTrue(conseguiuMudar);
            Assert.IsNotNull(tarefaRecuperada.DataConclusao);
        }

        [TestMethod]
        public void DeveExcluirTarefa()
        {
            TarefaModelo tarefa =
                new TarefaModelo("TESTAR", PrioridadeTarefa.BAIXA);
            controladorTarefa.Inserir(tarefa);

            bool conseguiuExcluir = controladorTarefa.Excluir(tarefa.Id);

            TarefaModelo tarefaRecuperda = controladorTarefa.BuscarRegistroPorId(tarefa.Id);

            Assert.IsTrue(conseguiuExcluir);
            Assert.IsNull(tarefaRecuperda);
        }

        [TestMethod]
        public void DeveBuscarTarefaPorId()
        {
            TarefaModelo tarefa =
                new TarefaModelo("TESTAR", PrioridadeTarefa.BAIXA);

            controladorTarefa.Inserir(tarefa);

            int id = tarefa.Id;

            TarefaModelo tarefaRecuperada = controladorTarefa.BuscarRegistroPorId(id);

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
            TarefaModelo tarefa =
                new TarefaModelo("TESTAR", PrioridadeTarefa.BAIXA);

            controladorTarefa.Inserir(tarefa);

            TarefaModelo[] tarefasRecuperadas = controladorTarefa.BuscarRegistros();

            Assert.IsTrue(tarefasRecuperadas.Length >= 1);
        }
    }
}
