using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ControleDeTarefas.Dominios;
using ControleDeTarefas.Controladores;

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
            this.controladorCompromisso = new ControladorCompromisso();
            this.dataPraTestar = DateTime.Parse("28/06/2021");
        }

        [TestMethod]
        public void DeveInserirNovoCompromissoSemContato()
        {
            CompromissoModelo novoCompromisso =
                new CompromissoModelo("TESTE", "TESTES", dataPraTestar, 
                TimeSpan.Parse("9:00"), TimeSpan.Parse("10:00"), null);

            bool conseguiuInserir = controladorCompromisso.Inserir(novoCompromisso);

            Assert.IsTrue(conseguiuInserir);
            Assert.IsTrue(novoCompromisso.Id > 0);
        }

        [TestMethod]
        public void DeveInserirNovoCompromissoComContato()
        {
            ContatoModelo contato = InserirContato();

            CompromissoModelo novoCompromisso =
                new CompromissoModelo("TESTE", "TESTES", dataPraTestar, 
                TimeSpan.Parse("9:00"), TimeSpan.Parse("10:00"), contato);

            bool conseguiuInserir = controladorCompromisso.Inserir(novoCompromisso);

            Assert.IsTrue(conseguiuInserir);
            Assert.IsTrue(novoCompromisso.Id > 0);
        }

        [TestMethod]
        public void DeveEditarCompromissoTirandoContato()
        {
            ContatoModelo contato = InserirContato();

            CompromissoModelo compromisso =
                new CompromissoModelo("TESTE", "TESTES", dataPraTestar,
                TimeSpan.Parse("9:00"), TimeSpan.Parse("10:00"), contato);
            controladorCompromisso.Inserir(compromisso);

            CompromissoModelo novoCompromisso =
                new CompromissoModelo("EDITADO", "EDITAÇÃO", dataPraTestar,
                TimeSpan.Parse("9:00"), TimeSpan.Parse("10:00"), null);
            novoCompromisso.Id = compromisso.Id;

            bool conseguiuEditar = controladorCompromisso.Editar(novoCompromisso);

            CompromissoModelo compromissoRecuperado = controladorCompromisso.BuscarRegistroPorId(compromisso.Id);

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
            ContatoModelo contato = InserirContato();

            ContatoModelo contato2 = InserirContato();

            CompromissoModelo compromisso =
                new CompromissoModelo("TESTE", "TESTES", dataPraTestar,
                TimeSpan.Parse("9:00"), TimeSpan.Parse("10:00"), contato);
            controladorCompromisso.Inserir(compromisso);

            CompromissoModelo novoCompromisso =
                new CompromissoModelo("EDITADO", "EDITAÇÃO", dataPraTestar,
                TimeSpan.Parse("9:00"), TimeSpan.Parse("10:00"), contato2);
            novoCompromisso.Id = compromisso.Id;

            bool conseguiuEditar = controladorCompromisso.Editar(novoCompromisso);
            CompromissoModelo compromissoRecuperado = controladorCompromisso.BuscarRegistroPorId(compromisso.Id);

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
            CompromissoModelo compromisso =
                new CompromissoModelo("TESTE", "TESTES", dataPraTestar,
                TimeSpan.Parse("9:00"), TimeSpan.Parse("10:00"), null);
            controladorCompromisso.Inserir(compromisso);

            bool conseguiuExcluir = controladorCompromisso.Excluir(compromisso.Id);

            CompromissoModelo compromissoRecuperado = controladorCompromisso.BuscarRegistroPorId(compromisso.Id);

            Assert.IsTrue(conseguiuExcluir);
            Assert.IsNull(compromissoRecuperado);
        }

        [TestMethod]
        public void DeveBuscarCompromissoPorId()
        {
            ContatoModelo contato = InserirContato();

            CompromissoModelo compromisso =
                new CompromissoModelo("TESTE", "TESTES", dataPraTestar,
                TimeSpan.Parse("9:00"), TimeSpan.Parse("10:00"), contato);

            controladorCompromisso.Inserir(compromisso);

            int id = compromisso.Id;

            CompromissoModelo compromissoRecuperado = controladorCompromisso.BuscarRegistroPorId(id);

            ContatoModelo contatoRecuperado = compromissoRecuperado.Contato;

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
            CompromissoModelo compromisso =
                new CompromissoModelo("TESTE", "TESTES", dataPraTestar, 
                TimeSpan.Parse("9:00"), TimeSpan.Parse("10:00"), null);

            controladorCompromisso.Inserir(compromisso);

            CompromissoModelo[] compromissosRecuperados = controladorCompromisso.BuscarRegistros();

            Assert.IsTrue(compromissosRecuperados.Length >= 1);
        }


        private ContatoModelo InserirContato()
        {
            ContatoModelo novoContato =
                new ContatoModelo("TESTE", "teste@test.com", "(11) 9 1111-1111", "testEmp", "testesr");

            controladorContato.Inserir(novoContato);

            return novoContato;
        }
    }
}
