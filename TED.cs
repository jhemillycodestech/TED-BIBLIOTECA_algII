namespace Interfaxe;

public class Program
{
    static void Main(string[] args)
    {
        bool mostrarMenu = true;

        do
        {
            Console.Clear();
            Console.WriteLine("+----------------------------+");
            Console.WriteLine("|      TED / Biblioteca      |");
            Console.WriteLine("+----------------------------+");
            Console.WriteLine("1."); //lista de livros em estoque em ordem alfabetica, com capacidade de adicionar e subtrair?
            Console.WriteLine("2."); //lista de  devoluçoes de livros em ordem de prazo mais proximo,com capacidade de adicionar e subtrair?
            Console.WriteLine("3. "); //lista de integrantes em ordem alfabetica,com capacidade de adicionar e subtrair?
            Console.WriteLine("0. Sair");
            Console.Write("\nEscolha uma opção -> ");

            string opcao = Console.ReadKey(true).KeyChar.ToString();

            switch (opcao)
            {
                case "1":
                    Console.Clear();
                    Console.WriteLine("Opção 1. Pressione qualquer tecla para continuar.");
                    Console.ReadKey();
                    break;

                case "2":
                    Console.Clear();
                    Console.WriteLine("Opção 2. Pressione qualquer tecla para continuar.");
                    Console.ReadKey();
                    break;

                case "3":
                    Console.Clear();
                    Console.WriteLine("Opção 3. Pressione qualquer tecla para continuar.");
                    Console.ReadKey();
                    break;

                case "0":
                    Console.Clear();
                    Console.Write("Você optou por sair. Pressione qualquer tecla para continuar. ");
                    Console.ReadKey();
                    mostrarMenu = false;
                    break;

                default:
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Opção inválida!");
                    Console.ResetColor();
                    Console.ReadKey();
                    break;
            }

        } while (mostrarMenu);
    }
}
