using System;
using System.Threading;

namespace AtividadeSomativaDevOps
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Testando a Formativa de DevOps!");

            Console.WriteLine("Commmit 02");
            Console.WriteLine("Commmit 03");
            Console.WriteLine("Commmit 04");
            Console.WriteLine("Commmit 05");

        
            while (true)
            {
                Console.WriteLine("Container rodando... " + DateTime.Now);
                Thread.Sleep(5000); 
            }
        }
    }
}
