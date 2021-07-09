using ControleDeTarefas.Controladores;
using ControleDeTarefas.Dominios;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ControleDeTarefas.Tests
{
    [TestClass]
    public class ControladorContatosTest
    {
        private ControladorContato controladorContato;

        public ControladorContatosTest()
        {
            controladorContato = new ControladorContato();
        }

        [TestMethod]
        public void DeveInserirNovoContato()
        {
            ContatoModelo novoContato =
                new ContatoModelo("TESTE", "teste@test.com", "(11) 9 1111-1111", "testEmp", "testesr");

            bool conseguiuInserir = controladorContato.Inserir(novoContato);

            Assert.IsTrue(conseguiuInserir);
            Assert.IsTrue(novoContato.Id > 0);
        }

        [TestMethod]
        public void DeveEditarContato()
        {
            ContatoModelo contato =
                new ContatoModelo("TESTE", "teste@test.com", "(11) 9 1111-1111", "testEmp", "testesr");
            controladorContato.Inserir(contato);

            ContatoModelo novoContato =
                new ContatoModelo("editado", "editado@edit.com", "(12) 9 1234-1234", "editEmp", "editer");
            novoContato.Id = contato.Id;

            bool conseguiuEditar = controladorContato.Editar(novoContato);
            ContatoModelo contatoRecuperado = controladorContato.BuscarRegistroPorId(contato.Id);

            Assert.IsTrue(conseguiuEditar);

            Assert.AreEqual(novoContato.Id, contatoRecuperado.Id);
            Assert.AreEqual(novoContato.Nome, contatoRecuperado.Nome);
            Assert.AreEqual(novoContato.Email, contatoRecuperado.Email);
            Assert.AreEqual(novoContato.Telefone, contatoRecuperado.Telefone);
            Assert.AreEqual(novoContato.Empresa, contatoRecuperado.Empresa);
            Assert.AreEqual(novoContato.Cargo, contatoRecuperado.Cargo);
        }

        [TestMethod]
        public void DeveExcluirContato()
        {
            ContatoModelo contato =
                new ContatoModelo("TESTE", "teste@test.com", "(11) 9 1111-1111", "testEmp", "testesr");
            controladorContato.Inserir(contato);

            bool conseguiuExcluir = controladorContato.Excluir(contato.Id);

            ContatoModelo contatoRecuperado = controladorContato.BuscarRegistroPorId(contato.Id);

            Assert.IsTrue(conseguiuExcluir);
            Assert.IsNull(contatoRecuperado);
        }

        [TestMethod]
        public void DeveBuscarContatoPorId()
        {
            ContatoModelo contato =
                new ContatoModelo("TESTE", "teste@test.com", "(11) 9 1111-1111", "testEmp", "testesr");

            controladorContato.Inserir(contato);

            int id = contato.Id;

            ContatoModelo contatoRecuperado = controladorContato.BuscarRegistroPorId(id);

            Assert.AreEqual(contato.Id, contatoRecuperado.Id);
            Assert.AreEqual(contato.Nome, contatoRecuperado.Nome);
            Assert.AreEqual(contato.Email, contatoRecuperado.Email);
            Assert.AreEqual(contato.Telefone, contatoRecuperado.Telefone);
            Assert.AreEqual(contato.Empresa, contatoRecuperado.Empresa);
            Assert.AreEqual(contato.Cargo, contatoRecuperado.Cargo);
        }

        [TestMethod]
        public void DeveBuscarTodosContatos()
        {
            ContatoModelo contato =
                new ContatoModelo("TESTE", "teste@test.com", "(11) 9 1111-1111", "testEmp", "testesr");

            controladorContato.Inserir(contato);

            ContatoModelo[] contatosRecuperados = controladorContato.BuscarRegistros();

            Assert.IsTrue(contatosRecuperados.Length >= 1);
        }
    }
}
