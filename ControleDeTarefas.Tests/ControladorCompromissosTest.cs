using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleDeTarefas.Controladores.Legado;
using ControleDeTarefas.Dominios;

namespace ControleDeTarefas.Tests
{
    [TestClass]
    public class ControladorCompromissosTest
    {
        private DateTime dataPraTestar;
        private ControladorContato controladorContato;
        private ControladorCompromisso controladorCompromisso;

        public ControladorCompromissosTest()
        {
            this.controladorContato = new ControladorContato();
            this.controladorCompromisso = new ControladorCompromisso(controladorContato);
            this.dataPraTestar = DateTime.Parse("28/06/2021");
        }

        [TestMethod]
        public void DeveInserirNovoCompromissoSemContato()
        {
            Compromisso novoCompromisso =
                new Compromisso("TESTE", "TESTES", dataPraTestar, 
                TimeSpan.Parse("9:00"), TimeSpan.Parse("10:00"), null);

            bool conseguiuInserir = controladorCompromisso.Inserir(novoCompromisso);

            Assert.IsTrue(conseguiuInserir);
            Assert.IsTrue(novoCompromisso.Id > 0);
        }

        [TestMethod]
        public void DeveInserirNovoCompromissoComContato()
        {
            Contato contato = InserirContato();

            Compromisso novoCompromisso =
                new Compromisso("TESTE", "TESTES", dataPraTestar, 
                TimeSpan.Parse("9:00"), TimeSpan.Parse("10:00"), contato);

            bool conseguiuInserir = controladorCompromisso.Inserir(novoCompromisso);

            Assert.IsTrue(conseguiuInserir);
            Assert.IsTrue(novoCompromisso.Id > 0);
        }

        [TestMethod]
        public void DeveEditarCompromissoTirandoContato()
        {
            Contato contato = InserirContato();

            Compromisso compromisso =
                new Compromisso("TESTE", "TESTES", dataPraTestar,
                TimeSpan.Parse("9:00"), TimeSpan.Parse("10:00"), contato);
            controladorCompromisso.Inserir(compromisso);

            Compromisso novoCompromisso =
                new Compromisso("EDITADO", "EDITAÇÃO", dataPraTestar,
                TimeSpan.Parse("9:00"), TimeSpan.Parse("10:00"), null);
            novoCompromisso.Id = compromisso.Id;

            bool conseguiuEditar = controladorCompromisso.Editar(novoCompromisso);

            Compromisso compromissoRecuperado = controladorCompromisso.BuscarRegistroPorId(compromisso.Id);

            Assert.IsTrue(conseguiuEditar);

            Assert.AreEqual(novoCompromisso.Id, compromissoRecuperado.Id);
            Assert.AreEqual(novoCompromisso.Assunto, compromissoRecuperado.Assunto);
            Assert.AreEqual(novoCompromisso.Local, compromissoRecuperado.Local);
            Assert.AreEqual(novoCompromisso.Data.ToString(), compromissoRecuperado.Data.ToString());
            Assert.AreEqual(novoCompromisso.HoraInicial.ToString(), compromissoRecuperado.HoraInicial.ToString());
            Assert.AreEqual(novoCompromisso.HoraFinal.ToString(), compromissoRecuperado.HoraFinal.ToString());

        }

        [TestMethod]
        public void DeveEditarCompromissoMudandoContato()
        {
            Contato contato = InserirContato();

            Contato contato2 = InserirContato();

            Compromisso compromisso =
                new Compromisso("TESTE", "TESTES", dataPraTestar,
                TimeSpan.Parse("9:00"), TimeSpan.Parse("10:00"), contato);
            controladorCompromisso.Inserir(compromisso);

            Compromisso novoCompromisso =
                new Compromisso("EDITADO", "EDITAÇÃO", dataPraTestar,
                TimeSpan.Parse("9:00"), TimeSpan.Parse("10:00"), contato2);
            novoCompromisso.Id = compromisso.Id;

            bool conseguiuEditar = controladorCompromisso.Editar(novoCompromisso);
            Compromisso compromissoRecuperado = controladorCompromisso.BuscarRegistroPorId(compromisso.Id);

            Assert.IsTrue(conseguiuEditar);

            Assert.AreEqual(novoCompromisso.Id, compromissoRecuperado.Id);
            Assert.AreEqual(novoCompromisso.Assunto, compromissoRecuperado.Assunto);
            Assert.AreEqual(novoCompromisso.Local, compromissoRecuperado.Local);
            Assert.AreEqual(novoCompromisso.Data.ToString(), compromissoRecuperado.Data.ToString());
            Assert.AreEqual(novoCompromisso.HoraInicial.ToString(), compromissoRecuperado.HoraInicial.ToString());
            Assert.AreEqual(novoCompromisso.HoraFinal.ToString(), compromissoRecuperado.HoraFinal.ToString());
            Assert.AreEqual(novoCompromisso.Contato.Id, compromissoRecuperado.Contato.Id);
        }


        [TestMethod]
        public void DeveExcluirCompromisso()
        {
            Compromisso compromisso =
                new Compromisso("TESTE", "TESTES", dataPraTestar,
                TimeSpan.Parse("9:00"), TimeSpan.Parse("10:00"), null);
            controladorCompromisso.Inserir(compromisso);

            bool conseguiuExcluir = controladorCompromisso.Excluir(compromisso.Id);

            Compromisso compromissoRecuperado = controladorCompromisso.BuscarRegistroPorId(compromisso.Id);

            Assert.IsTrue(conseguiuExcluir);
            Assert.IsNull(compromissoRecuperado);
        }

        [TestMethod]
        public void DeveBuscarCompromissoPorId()
        {
            Contato contato = InserirContato();

            Compromisso compromisso =
                new Compromisso("TESTE", "TESTES", dataPraTestar,
                TimeSpan.Parse("9:00"), TimeSpan.Parse("10:00"), contato);

            controladorCompromisso.Inserir(compromisso);

            int id = compromisso.Id;

            Compromisso compromissoRecuperado = controladorCompromisso.BuscarRegistroPorId(id);

            Contato contatoRecuperado = compromissoRecuperado.Contato;

            Assert.AreEqual(compromisso.Id, compromissoRecuperado.Id);
            Assert.AreEqual(compromisso.Assunto, compromissoRecuperado.Assunto);
            Assert.AreEqual(compromisso.Local, compromissoRecuperado.Local);
            Assert.AreEqual(compromisso.Data.ToString(), compromissoRecuperado.Data.ToString());
            Assert.AreEqual(compromisso.HoraInicial.ToString(), compromissoRecuperado.HoraInicial.ToString());
            Assert.AreEqual(compromisso.HoraFinal.ToString(), compromissoRecuperado.HoraFinal.ToString());
            Assert.AreEqual(compromisso.Contato.Id, compromissoRecuperado.Contato.Id);

            Assert.AreEqual(contato.Id, contatoRecuperado.Id);
            Assert.AreEqual(contato.Nome, contatoRecuperado.Nome);
            Assert.AreEqual(contato.Email, contatoRecuperado.Email);
            Assert.AreEqual(contato.Telefone, contatoRecuperado.Telefone);
            Assert.AreEqual(contato.Empresa, contatoRecuperado.Empresa);
            Assert.AreEqual(contato.Cargo, contatoRecuperado.Cargo);
        }

        [TestMethod]
        public void DeveBuscarTodosCompromissos()
        {
            Compromisso compromisso =
                new Compromisso("TESTE", "TESTES", dataPraTestar, 
                TimeSpan.Parse("9:00"), TimeSpan.Parse("10:00"), null);

            controladorCompromisso.Inserir(compromisso);

            Compromisso[] compromissosRecuperados = controladorCompromisso.BuscarRegistros();

            Assert.IsTrue(compromissosRecuperados.Length >= 1);
        }


        private Contato InserirContato()
        {
            Contato novoContato =
                new Contato("TESTE", "teste@test.com", "(11) 9 1111-1111", "testEmp", "testesr");

            controladorContato.Inserir(novoContato);

            return novoContato;
        }
    }
}
