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
            Program.Resetar();
        }

        [Test]
        public void Criar_Estudante()
        {
            var estudante = Program.CriarEstudante("Gesiele", 26);

            Assert.AreEqual("Gesiele", estudante.Nome);
            Assert.AreEqual(26, estudante.Idade);
            Assert.IsTrue(estudante.Id > 0);
        }

        [Test]
        public void Listar_TodosEstudantes()
        {
            Program.CriarEstudante("Gisele", 43);
            Program.CriarEstudante("Vitor", 10);

            var lista = Program.ListarEstudantes();

            Assert.IsTrue(lista.Any());
        }

        [Test]
        public void Atualizar_Estudante()
        {
            var estudante = Program.CriarEstudante("Will", 34);
            bool atualizado = Program.AtualizarEstudante(estudante.Id, "Will", 35);

            Assert.IsTrue(atualizado);
            var atualizadoEstudante = Program.ListarEstudantes().First();
            Assert.AreEqual("Will", atualizadoEstudante.Nome);
            Assert.AreEqual(35, atualizadoEstudante.Idade);
        }

        [Test]
        public void Atualizar_ComIdInvalido_RetornarFalse()
        {
            bool resultado = Program.AtualizarEstudante(999, "Teste", 40);

            Assert.IsFalse(resultado);
        }

        [Test]
        public void Deletar_DeveRemoverEstudante()
        {
            var estudante = Program.CriarEstudante("José", 28);
            bool deletado = Program.DeletarEstudante(estudante.Id);

            Assert.IsTrue(deletado);
            Assert.IsFalse(Program.ListarEstudantes().Any());
        }
    }
}
