using System;

namespace Interfaxe
{
    public class Devolucao
    {
        public string ISBN { get; set; }
        public string Matricula { get; set; }
        public DateTime Prazo { get; set; }

        public Devolucao(string isbn, string matricula, DateTime prazo)
        {
            ISBN = isbn;
            Matricula = matricula;
            Prazo = prazo;
        }

        public void Exibir()
        {
            Console.WriteLine("----------------------------");
            Console.WriteLine("ISBN do livro: " + ISBN);
            Console.WriteLine("Matrícula: " + Matricula);
            Console.WriteLine("Prazo de devolução: " + Prazo.ToString("dd/MM/yyyy"));
            Console.WriteLine("----------------------------");
        }
    }
}
