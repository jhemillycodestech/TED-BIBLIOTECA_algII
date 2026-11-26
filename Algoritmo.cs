using System;
using System.Collections.Generic;

namespace Interfaxe
{
    public static class Algoritmos
    {
        public static void BubbleSort<T>(List<T> lista, Comparison<T> comparar)
        {
            for (int i = 0; i < lista.Count - 1; i++)
            {
                for (int j = 0; j < lista.Count - i - 1; j++)
                {
                    if (comparar(lista[j], lista[j + 1]) > 0)
                    {
                        T temporario = lista[j];
                        lista[j] = lista[j + 1];
                        lista[j + 1] = temporario;
                    }
                }
            }
        }

        public static void InsertionSort<T>(List<T> lista, Comparison<T> comparar)
        {
            for (int i = 1; i < lista.Count; i++)
            {
                T atual = lista[i];
                int j = i - 1;

                while (j >= 0 && comparar(lista[j], atual) > 0)
                {
                    lista[j + 1] = lista[j];
                    j--;
                }

                lista[j + 1] = atual;
            }
        }

        public static Livro? BuscaLinear(List<Livro> livros, string isbn)
        {
            foreach (Livro livro in livros)
            {
                if (livro.ISBN == isbn)
                    return livro;
            }
            return null;
        }

        public static Livro? BuscaBinaria(List<Livro> livros, string isbn)
        {
            int inicio = 0;
            int fim = livros.Count - 1;

            while (inicio <= fim)
            {
                int meio = inicio + (fim - inicio) / 2;
                int comparacao = string.Compare(livros[meio].ISBN, isbn, StringComparison.Ordinal);

                if (comparacao == 0) return livros[meio];
                if (comparacao < 0) inicio = meio + 1;
                else fim = meio - 1;
            }
            return null;
        }
    }
}
