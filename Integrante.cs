using System;

namespace Interfaxe
{
    public class Integrante
    {
        public string Matricula { get; set; }
        public string Nome { get; set; }

        public Integrante(string matricula, string nome)
        {
            Matricula = matricula;
            Nome = nome;
        }

        public void Exibir()
        {
            Console.WriteLine("----------------------------");
            Console.WriteLine("Matrícula: " + Matricula);
            Console.WriteLine("Nome: " + Nome);
            Console.WriteLine("----------------------------");
        }
    }
}
