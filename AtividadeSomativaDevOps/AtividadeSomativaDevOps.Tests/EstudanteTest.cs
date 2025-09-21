using NUnit.Framework;
using AtividadeSomativaDevOps;
using System.Linq;

namespace AtividadeSomativaDevOps.Tests
{
    public class ProgramTests
    {
        [SetUp]
        public void Setup()
        {
            //Program.Resetar();
        }

        [Test]
        public void Criar_DeveAdicionarEstudante()
        {
            var estudante = Program.CriarEstudante("Maria", 20);

            Assert.AreEqual("Maria", estudante.Nome);
            Assert.AreEqual(20, estudante.Idade);
            Assert.AreEqual(1, estudante.Id);
        }

        [Test]
        public void Listar_DeveRetornarTodosEstudantes()
        {
            Program.CriarEstudante("João", 22);
            Program.CriarEstudante("Ana", 25);

            var lista = Program.ListarEstudantes();

            Assert.AreEqual(2, lista.Count);
            Assert.IsTrue(lista.Any(e => e.Nome == "João"));
            Assert.IsTrue(lista.Any(e => e.Nome == "Ana"));
        }

        [Test]
        public void Atualizar_DeveAlterarDadosDoEstudante()
        {
            var estudante = Program.CriarEstudante("Carlos", 30);
            bool atualizado = Program.AtualizarEstudante(estudante.Id, "Carlos Silva", 31);

            Assert.IsTrue(atualizado);
            var atualizadoEstudante = Program.ListarEstudantes().First();
            Assert.AreEqual("Carlos Silva", atualizadoEstudante.Nome);
            Assert.AreEqual(31, atualizadoEstudante.Idade);
        }

        [Test]
        public void Atualizar_ComIdInvalido_DeveRetornarFalse()
        {
            bool resultado = Program.AtualizarEstudante(999, "Teste", 40);

            Assert.IsFalse(resultado);
        }

        [Test]
        public void Deletar_DeveRemoverEstudante()
        {
            var estudante = Program.CriarEstudante("Fernanda", 28);
            bool deletado = Program.DeletarEstudante(estudante.Id);

            Assert.IsTrue(deletado);
            Assert.AreEqual(0, Program.ListarEstudantes().Count);
        }
    }
}
