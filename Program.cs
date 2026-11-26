using System;
using System.Collections.Generic;
using System.Linq;

namespace Interfaxe
{
    public class Program
    {
        static List<Livro> livros = new List<Livro>();
        static List<Devolucao> devolucoes = new List<Devolucao>();
        static List<Integrante> integrantes = new List<Integrante>();

        static void Main(string[] args)
        {
            bool mostrarMenu = true;

            do
            {
                Console.Clear();
                Console.WriteLine("      TED / Biblioteca      ");
                Console.WriteLine("1. Livros em estoque");
                Console.WriteLine("2. Devoluções");
                Console.WriteLine("3. Integrantes");
                Console.WriteLine("0. Sair");
                Console.Write("\nEscolha uma opção -> ");

                string opcao = Console.ReadLine() ?? "";

                switch (opcao)
                {
                    case "1": MenuLivros(); break;
                    case "2": MenuDevolucoes(); break;
                    case "3": MenuIntegrantes(); break;

                    case "0":
                        Console.Clear();
                        Console.WriteLine("Você optou por sair.");
                        mostrarMenu = false;
                        break;

                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Opção inválida!");
                        Console.ResetColor();
                        Pausar();
                        break;
                }

            } while (mostrarMenu);
        }

        // os métodos auxiliares 

        static void Pausar()
        {
            Console.WriteLine("\nPressione qualquer tecla para continuar.");
            Console.ReadKey();
        }

        static string LerTexto(string mensagem)
        {
            string texto;

            do
            {
                Console.Write(mensagem);
                texto = Console.ReadLine() ?? "";

                if (string.IsNullOrWhiteSpace(texto))
                    Console.WriteLine("O campo não pode ficar vazio.");

            } while (string.IsNullOrWhiteSpace(texto));

            return texto.Trim();
        }

        static string LerISBN(string mensagem)
        {
            while (true)
            {
                string texto = LerTexto(mensagem);

                bool soNumerosEHifen = texto.All(c => char.IsDigit(c) || c == '-');
                bool temNumero = texto.Any(char.IsDigit);

                if (soNumerosEHifen && temNumero)
                    return texto.Replace("-", "");   // guarda sempre sem hífen

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Código inválido. Use apenas números (hífens são opcionais). Ex.: 978-85-359-0277-5");
                Console.ResetColor();
            }
        }

        static string LerMatricula(string mensagem)
        {
            while (true)
            {
                string texto = LerTexto(mensagem);

                if (texto.All(char.IsDigit))
                    return texto;

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Matrícula inválida. Use apenas números.");
                Console.ResetColor();
            }
        }

        static int LerInteiro(string mensagem)
        {
            int numero;

            while (true)
            {
                Console.Write(mensagem);

                if (int.TryParse(Console.ReadLine(), out numero) && numero >= 0)
                    return numero;

                Console.WriteLine("Digite um número inteiro válido.");
            }
        }

        static DateTime LerData(string mensagem)
        {
            DateTime data;

            while (true)
            {
                Console.Write(mensagem);

                if (DateTime.TryParse(Console.ReadLine(), out data))
                    return data;

                Console.WriteLine("Data inválida. Exemplo: 25/12/2026.");
            }
        }

 

        static void MenuLivros()
        {
            bool voltar = false;

            while (!voltar)
            {
                Console.Clear();
                Console.WriteLine("LIVROS NO NOSSO ESTOQUE! ");
                Console.WriteLine("1. Cadastrar livro");
                Console.WriteLine("2. Remover livro");
                Console.WriteLine("3. Listar livros");
                Console.WriteLine("4. Buscar livro");
                Console.WriteLine("5. Ordenar livros");
                Console.WriteLine("6. Selecionar livro com maior estoque");
                Console.WriteLine("7. Selecionar livro com menor estoque");
                Console.WriteLine("0. Voltar");
                Console.Write("\nOpção: ");

                switch (Console.ReadLine())
                {
                    case "1": AdicionarLivro(); break;
                    case "2": RemoverLivro(); break;
                    case "3": ListarLivros(); break;
                    case "4": BuscarLivro(); break;
                    case "5": OrdenarLivros(); break;
                    case "6": SelecionarMaiorEstoque(); break;
                    case "7": SelecionarMenorEstoque(); break;
                    case "0": voltar = true; break;

                    default:
                        Console.WriteLine("Opção inválida.");
                        Pausar();
                        break;
                }
            }
        }

        static void AdicionarLivro()
        {
            Console.Clear();
            Console.WriteLine("CADASTRE 1 LIVRO ✎ᝰ.");

            string  isbn = LerISBN("Código: ");

            if (livros.Exists(l => l. ISBN ==  isbn))
            {
                Console.WriteLine("Já existe um livro com esse ISBN.");
                Pausar();
                return;
            }

            string titulo = LerTexto("Título: ");
            string autor = LerTexto("Autor: ");
            int quantidade = LerInteiro("Quantidade em estoque: ");

            livros.Add(new Livro( isbn, titulo, autor, quantidade));

            Console.WriteLine("\nLivro cadastrado com sucesso!");
            Pausar();
        }

        static void RemoverLivro()
        {
            Console.Clear();

            string  isbn = LerISBN("Digite o Código do livro que deseja remover: ");

            int indice = livros.FindIndex(l => l. ISBN ==  isbn);

            if (indice >= 0)
            {
                livros.RemoveAt(indice);
                Console.WriteLine("Livro removido com sucesso!");
            }
            else
            {
                Console.WriteLine("Livro não encontrado.");
            }

            Pausar();
        }

        static void ListarLivros()
        {
            Console.Clear();
            Console.WriteLine("LIVROS QUE FORAM CADASTRADOS ");

            if (livros.Count == 0)
            {
                Console.WriteLine("Nenhum livro cadastrado.");
            }
            else
            {
                foreach (Livro livro in livros)
                    livro.Exibir();
            }

            Pausar();
        }

      
        static void BuscarLivro()
        {
            Console.Clear();
            Console.WriteLine(" BUSQUE 1 LIVRO ");
            Console.WriteLine("1. Busca Linear");
            Console.WriteLine("2. Busca Binária");
            Console.Write("\nEscolha: ");

            string opcao = Console.ReadLine() ?? "";

            if (opcao != "1" && opcao != "2")
            {
                Console.WriteLine("Opção inválida.");
                Pausar();
                return;
            }

            string  isbn = LerISBN("\nDigite o Código do livro: ");

            Livro? resultado;

            if (opcao == "1")
            {
                resultado = Algoritmos.BuscaLinear(livros,  isbn);
            }
            else
            {
                
                Algoritmos.InsertionSort(livros, (a, b) =>
                    string.Compare(a.ISBN, b.ISBN, StringComparison.Ordinal));

                resultado = Algoritmos.BuscaBinaria(livros,  isbn);
            }

            if (resultado != null)
            {
                Console.WriteLine("\nLivro encontrado:");
                resultado.Exibir();
            }
            else
            {
                Console.WriteLine("\nLivro não encontrado.");
            }

            Pausar();
        }

        static void OrdenarLivros()
        {
            Console.Clear();
            Console.WriteLine(" ORDENAR LIVROS✍︎");
            Console.WriteLine("1. Bubble Sort");
            Console.WriteLine("2. Insertion Sort");
            Console.Write("\nEscolha: ");

            string opcao = Console.ReadLine() ?? "";

            if (opcao == "1")
            {
                Algoritmos.BubbleSort(livros, (a, b) =>
                    string.Compare(a.Titulo, b.Titulo, StringComparison.OrdinalIgnoreCase));
                Console.WriteLine("Livros ordenados com Bubble Sort!\n");
                foreach (Livro livro in livros)
                    livro.Exibir();
            }
            else if (opcao == "2")
            {
                Algoritmos.InsertionSort(livros, (a, b) =>
                    string.Compare(a.Titulo, b.Titulo, StringComparison.OrdinalIgnoreCase));
                Console.WriteLine("Livros ordenados com Insertion Sort!\n");
                foreach (Livro livro in livros)
                    livro.Exibir();
            }
            else
            {
                Console.WriteLine("Opção inválida.");
            }
            Pausar();
        }

        static void SelecionarMaiorEstoque()
        {
            Console.Clear();

            if (livros.Count == 0)
            {
                Console.WriteLine("Não existem livros cadastrados.");
                Pausar();
                return;
            }

            Livro maior = livros[0];

            for (int i = 1; i < livros.Count; i++)
            {
                if (livros[i].Quantidade > maior.Quantidade)
                    maior = livros[i];
            }

            Console.WriteLine(" LIVRO COM MAIOR ESTOQUE ");
            maior.Exibir();
            Pausar();
        }

        static void SelecionarMenorEstoque()
        {
            Console.Clear();

            if (livros.Count == 0)
            {
                Console.WriteLine("Não existem livros cadastrados.");
                Pausar();
                return;
            }

            Livro menor = livros[0];

            for (int i = 1; i < livros.Count; i++)
            {
                if (livros[i].Quantidade < menor.Quantidade)
                    menor = livros[i];
            }

            Console.WriteLine("LIVRO COM MENOR ESTOQUE ");
            menor.Exibir();
            Pausar();
        }

        // DEVOLUÇÕES DE LIVROS
        static void MenuDevolucoes()
        {
            bool voltar = false;

            while (!voltar)
            {
                Console.Clear();
                Console.WriteLine("DEVOLUÇÕES⌯⌲");
                Console.WriteLine("1. Registrar devolução");
                Console.WriteLine("2. Remover devolução");
                Console.WriteLine("3. Listar devoluções");
                Console.WriteLine("4. Buscar devolução");
                Console.WriteLine("5. Ordenar por prazo");
                Console.WriteLine("6. Selecionar devolução mais próxima");
                Console.WriteLine("0. Voltar");
                Console.Write("\nOpção: ");

                switch (Console.ReadLine())
                {
                    case "1": AdicionarDevolucao(); break;
                    case "2": RemoverDevolucao(); break;
                    case "3": ListarDevolucoes(); break;
                    case "4": BuscarDevolucao(); break;
                    case "5": OrdenarDevolucoes(); break;
                    case "6": SelecionarDevolucaoProxima(); break;
                    case "0": voltar = true; break;

                    default:
                        Console.WriteLine("Opção inválida.");
                        Pausar();
                        break;
                }
            }
        }

        static void AdicionarDevolucao()
        {
            Console.Clear();
            Console.WriteLine("REGISTRAR a DEVOLUÇÃO ");

            string  isbn = LerISBN("Código do livro: ");

            if (!livros.Exists(l => l. ISBN ==  isbn))
            {
                Console.WriteLine("Livro não cadastrado.");
                Pausar();
                return;
            }

            string matricula = LerMatricula("Matrícula do integrante: ");

            if (!integrantes.Exists(i => i.Matricula == matricula))
            {
                Console.WriteLine("Integrante não cadastrado.");
                Pausar();
                return;
            }

            DateTime prazo = LerData("Data prevista para devolução: ");

            devolucoes.Add(new Devolucao( isbn, matricula, prazo));

            Console.WriteLine("\nDevolução registrada com sucesso!");
            Pausar(); 
        }

        static void RemoverDevolucao()
        {
            Console.Clear();

            string  isbn = LerISBN("Código da devolução que deseja remover: ");

            int indice = devolucoes.FindIndex(d => d. ISBN ==  isbn);

            if (indice >= 0)
            {
                devolucoes.RemoveAt(indice);
                Console.WriteLine("Devolução removida com sucesso!");
            }
            else
            {
                Console.WriteLine("Devolução não encontrada.");
            }

            Pausar();
        }

        static void ListarDevolucoes()
        {
            Console.Clear();
            Console.WriteLine("DEVOLUÇÕES QUE FORAM REGISTRADAS ");

            if (devolucoes.Count == 0)
            {
                Console.WriteLine("Nenhuma devolução registrada.");
            }
            else
            {
                foreach (Devolucao devolucao in devolucoes)
                    devolucao.Exibir();
            }

            Pausar();
        }

        static void BuscarDevolucao()
        {
            Console.Clear();

            string  isbn = LerISBN("Digite o isbn da devolução: ");

            Devolucao? resultado = null;

            foreach (Devolucao devolucao in devolucoes)
            {
                if (devolucao. ISBN ==  isbn)
                {
                    resultado = devolucao;
                    break;
                }
            }

            if (resultado != null)
                resultado.Exibir();
            else
                Console.WriteLine("Devolução não encontrada.");

            Pausar();
        }

        static void OrdenarDevolucoes()
        {
            Console.Clear();
            Console.WriteLine("ORDENAR DEVOLUÇÕES ");
            Console.WriteLine("1. Bubble Sort");
            Console.WriteLine("2. Insertion Sort");
            Console.Write("\nEscolha: ");

            string opcao = Console.ReadLine() ?? "";
            if (opcao == "1")
            {
                Algoritmos.BubbleSort(devolucoes, (a, b) => a.Prazo.CompareTo(b.Prazo));
                Console.WriteLine("Devoluções ordenadas com Bubble Sort!\n");
                foreach (Devolucao devolucao in devolucoes)
                    devolucao.Exibir();
            }
            else if (opcao == "2")
            {
                Algoritmos.InsertionSort(devolucoes, (a, b) => a.Prazo.CompareTo(b.Prazo));
                Console.WriteLine("Devoluções ordenadas com Insertion Sort!\n");
                foreach (Devolucao devolucao in devolucoes)
                    devolucao.Exibir();
            }
            else
            {
                Console.WriteLine("Opção inválida.");
            }

            Pausar();
        }

        static void SelecionarDevolucaoProxima()
        {
            Console.Clear();

            if (devolucoes.Count == 0)
            {
                Console.WriteLine("Não existem devoluções registradas.");
                Pausar();
                return;
            }

            Devolucao proxima = devolucoes[0];

            for (int i = 1; i < devolucoes.Count; i++)
            {
                if (devolucoes[i].Prazo < proxima.Prazo)
                    proxima = devolucoes[i];
            }

            Console.WriteLine("devolução com prazo mais próximo");
            proxima.Exibir();
            Pausar();
        }

        // cadastro de INTEGRANTES 

        static void MenuIntegrantes()
        {
            bool voltar = false;

            while (!voltar)
            {
                Console.Clear();
                Console.WriteLine("INTEGRANTES DA BIBLIOTECA");
                Console.WriteLine("1. Cadastrar integrante");
                Console.WriteLine("2. Remover integrante");
                Console.WriteLine("3. Listar integrantes");
                Console.WriteLine("4. Buscar integrante");
                Console.WriteLine("5. Ordenar integrantes");
                Console.WriteLine("0. Voltar");
                Console.Write("\nOpção: ");

                switch (Console.ReadLine())
                {
                    case "1": AdicionarIntegrante(); break;
                    case "2": RemoverIntegrante(); break;
                    case "3": ListarIntegrantes(); break;
                    case "4": BuscarIntegrante(); break;
                    case "5": OrdenarIntegrantes(); break;
                    case "0": voltar = true; break;

                    default:
                        Console.WriteLine("Opção inválida.");
                        Pausar();
                        break;
                }
            }
        }

        static void AdicionarIntegrante()
        {
            Console.Clear();
            Console.WriteLine("CADASTRAR INTEGRANTE");

            string matricula = LerMatricula("Matrícula: ");

            if (integrantes.Exists(i => i.Matricula == matricula))
            {
                Console.WriteLine("Matrícula já cadastrada.");
                Pausar();
                return;
            }

            string nome = LerTexto("Nome: ");

            integrantes.Add(new Integrante(matricula, nome));

            Console.WriteLine("\nIntegrante cadastrado com sucesso!");
            Pausar();
        }

        static void RemoverIntegrante()
        {
            Console.Clear();

            string matricula = LerMatricula("Matrícula do integrante: ");

            if (devolucoes.Exists(d => d.Matricula == matricula))
            {
                Console.WriteLine("Não é possível remover: existem devoluções vinculadas.");
                Pausar();
                return;
            }

            int indice = integrantes.FindIndex(i => i.Matricula == matricula);

            if (indice >= 0)
            {
                integrantes.RemoveAt(indice);
                Console.WriteLine("Integrante removido com sucesso!");
            }
            else
            {
                Console.WriteLine("Integrante não encontrado.");
            }

            Pausar();
        }

        static void ListarIntegrantes()
        {
            Console.Clear();
            Console.WriteLine("INTEGRANTES JÁ CADASTRADOS");

            if (integrantes.Count == 0)
            {
                Console.WriteLine("Nenhum integrante cadastrado.");
            }
            else
            {
                foreach (Integrante integrante in integrantes)
                    integrante.Exibir();
            }

            Pausar();
        }

        static void BuscarIntegrante()
        {
            Console.Clear();

            string matricula = LerMatricula("Digite a matrícula: ");

            Integrante? resultado = null;

            foreach (Integrante integrante in integrantes)
            {
                if (integrante.Matricula == matricula)
                {
                    resultado = integrante;
                    break;
                }
            }

            if (resultado != null)
                resultado.Exibir();
            else
                Console.WriteLine("Integrante não encontrado.");

            Pausar();
        }

        static void OrdenarIntegrantes()
        {
            Console.Clear();
            Console.WriteLine("ORDENAR OS INTEGRANTES");
            Console.WriteLine("1. Bubble Sort");
            Console.WriteLine("2. Insertion Sort");
            Console.Write("\nEscolha: ");

            string opcao = Console.ReadLine() ?? "";

            if (opcao == "1")
            {
                Algoritmos.BubbleSort(integrantes, (a, b) =>
                    string.Compare(a.Nome, b.Nome, StringComparison.OrdinalIgnoreCase));
                Console.WriteLine("Integrantes ordenados com Bubble Sort!\n");
                foreach (Integrante integrante in integrantes)
                    integrante.Exibir();
            }
            else if (opcao == "2")
            {
                Algoritmos.InsertionSort(integrantes, (a, b) =>
                    string.Compare(a.Nome, b.Nome, StringComparison.OrdinalIgnoreCase));
                Console.WriteLine("Integrantes ordenados com Insertion Sort!\n");
                foreach (Integrante integrante in integrantes)
                    integrante.Exibir();
            }
            else
            {
                Console.WriteLine("Opção inválida.");
            }

            Pausar();
        }
    }
}
