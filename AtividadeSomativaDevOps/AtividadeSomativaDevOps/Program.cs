using System;
using System.Collections.Generic;
using System.Linq;

namespace AtividadeSomativaDevOps
{
    public class Estudante
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
    }

    public class Program
    {
        private static List<Estudante> estudantes = new List<Estudante>();
        private static int contadorId = 1;

        static void Main(string[] args)
        {
            int opcao = 0;
            do
            {
                Console.WriteLine("\n===== MENU CRUD ESTUDANTE =====");
                Console.WriteLine("1 - Criar Estudante");
                Console.WriteLine("2 - Listar Estudantes");
                Console.WriteLine("3 - Atualizar Estudante");
                Console.WriteLine("4 - Deletar Estudante");
                Console.WriteLine("5 - Sair");
                Console.Write("Escolha uma opção: ");

                if (!int.TryParse(Console.ReadLine(), out opcao))
                {
                    Console.WriteLine("Opção inválida!");
                    continue;
                }

                switch (opcao)
                {
                    case 1: MenuCriar(); break;
                    case 2: MenuListar(); break;
                    case 3: MenuAtualizar(); break;
                    case 4: MenuDeletar(); break;
                    case 5: Console.WriteLine("Saindo..."); break;
                    default: Console.WriteLine("Opção inválida!"); break;
                }

            } while (opcao != 5);
        }

        private static void MenuCriar()
        {
            Console.Write("Digite o nome do estudante: ");
            string nome = Console.ReadLine();

            Console.Write("Digite a idade do estudante: ");
            int idade = int.Parse(Console.ReadLine());

            var estudante = CriarEstudante(nome, idade);
            Console.WriteLine($"Estudante criado com ID {estudante.Id}");
        }

        private static void MenuListar()
        {
            var lista = ListarEstudantes();

            Console.WriteLine("\n--- Lista de Estudantes ---");
            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhum estudante cadastrado.");
                return;
            }

            foreach (var est in lista)
            {
                Console.WriteLine($"ID: {est.Id} | Nome: {est.Nome} | Idade: {est.Idade}");
            }
        }

        private static void MenuAtualizar()
        {
            Console.Write("Digite o ID do estudante a atualizar: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Novo nome: ");
            string nome = Console.ReadLine();

            Console.Write("Nova idade: ");
            int idade = int.Parse(Console.ReadLine());

            bool atualizado = AtualizarEstudante(id, nome, idade);
            Console.WriteLine(atualizado ? "Estudante atualizado com sucesso!" : "❌ Estudante não encontrado!");
        }

        private static void MenuDeletar()
        {
            Console.Write("Digite o ID do estudante a deletar: ");
            int id = int.Parse(Console.ReadLine());

            bool deletado = DeletarEstudante(id);
            Console.WriteLine(deletado ? "Estudante deletado com sucesso!" : "❌ Estudante não encontrado!");
        }

        public static Estudante CriarEstudante(string nome, int idade)
        {
            var estudante = new Estudante { Id = contadorId++, Nome = nome, Idade = idade };
            estudantes.Add(estudante);
            return estudante;
        }

        public static List<Estudante> ListarEstudantes()
        {
            return estudantes.ToList();
        }

        public static bool AtualizarEstudante(int id, string novoNome, int novaIdade)
        {
            var estudante = estudantes.FirstOrDefault(e => e.Id == id);
            if (estudante == null) return false;

            estudante.Nome = novoNome;
            estudante.Idade = novaIdade;
            return true;
        }

        public static bool DeletarEstudante(int id)
        {
            var estudante = estudantes.FirstOrDefault(e => e.Id == id);
            if (estudante == null) return false;

            estudantes.Remove(estudante);
            return true;
        }

        
        public static void Resetar()
        {
            estudantes.Clear();
            contadorId = 1;
        }
    }
}
