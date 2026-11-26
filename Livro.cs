using System;

namespace Interfaxe
{
    public class Livro
    {
        public string ISBN { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public int Quantidade { get; set; }

        public Livro(string isbn, string titulo, string autor, int quantidade)
        {
            ISBN = isbn;
            Titulo = titulo;
            Autor = autor;
            Quantidade = quantidade;
        }

        public void Exibir()
        {
            Console.WriteLine("----------------------------");
            Console.WriteLine("ISBN: " + ISBN);
            Console.WriteLine("Título: " + Titulo);
            Console.WriteLine("Autor: " + Autor);
            Console.WriteLine("Quantidade: " + Quantidade);
            Console.WriteLine("----------------------------");
        }
    }
}
