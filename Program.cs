using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtividadeAula08SistemaDeUsuarios
{
    internal class Program
    {
        public static List<string> usuarios = new List<string>();

        /**
         * Foram criados métodos com objetivo de evitar a repetição de código
         * **/

        public static void cabeçalho()

        {
            Console.Clear();
            Console.WriteLine("_____________________________________");
            Console.WriteLine("\n         SISTEMA DE USUARIOS\n");
            Console.WriteLine("_____________________________________\n");
        }

        public static void verificarListaVazia()
        {
            if (usuarios.Count == 0)
            {
                cabeçalho();
                Console.WriteLine("A lista está vazia! \nAdicione novos usuários");
                Console.WriteLine("Pressione ENTER para retornar ao MENU");
                Console.ReadKey();
                Main(null);
                return;
            }
        }

        public static void listaDeUsuarios()
        {
            int contador = 0;

            Console.WriteLine("\n         LISTA DE USUARIOS\n");
            while (contador < usuarios.Count)
            {
                Console.WriteLine($"{contador + 1} - {usuarios[contador]}");
                contador++;
            }
            Console.WriteLine("_____________________________________\n");
        }

        public static void verificarIndiceValido(int indice)
        {

            if (indice > usuarios.Count)
            {
                Console.WriteLine("Indice inválido!");
                Console.WriteLine("Pressione ENTER para retornar ao MENU");
                Console.ReadKey();
                Main(null);
                return;
            }
        }

        public static void retornarMenu()
        {
            Console.WriteLine("Pressione ENTER para retornar ao MENU");
            Console.ReadKey();
            Main(null);
            return;
        }

        static void Main(string[] args)
        {

            int opcao;
            int indice;

            cabeçalho();
            Console.WriteLine("1 - Cadastrar");
            Console.WriteLine("2 - Buscar");
            Console.WriteLine("3 - Deletar");
            Console.WriteLine("4 - Alterar");
            Console.WriteLine("5 - Listar");
            Console.WriteLine("_____________________________________\n");
            Console.Write("Selecione uma das opções: ");
            opcao = int.Parse(Console.ReadLine());

            if ((opcao > 5) || (opcao < 1))
            {
                cabeçalho();
                Console.WriteLine("Opção inválida!");
                retornarMenu();
            }

            if (opcao == 1)
            {
                cabeçalho();
                Console.Write("Insira o nome do novo usuário: ");
                usuarios.Add(Console.ReadLine());
                Console.WriteLine("_____________________________________");
                Console.WriteLine("\nUsuário adicionado com sucesso!");
                retornarMenu();
            }

            if (opcao == 2)
            {
                verificarListaVazia();

                cabeçalho();
                listaDeUsuarios();

                Console.Write("Insira o indice do usuario: ");
                indice = int.Parse(Console.ReadLine());

                verificarIndiceValido(indice);

                Console.WriteLine($"Usuário encontrado: ---| {usuarios[indice - 1]} |---");
                retornarMenu();
            }

            if (opcao == 3)
            {
                verificarListaVazia();

                cabeçalho();
                listaDeUsuarios();

                Console.Write("Insira o indice do usuário: ");
                indice = int.Parse(Console.ReadLine());

                verificarIndiceValido(indice);

                usuarios.RemoveAt(indice - 1);
                Console.WriteLine("Usuário removido com sucesso!");
                retornarMenu();
            }

            if(opcao == 4)
            {
                string nome;
                
                verificarListaVazia();

                cabeçalho();
                Console.Write("Insira o nome do usuário que você deseja alterar: ");
                nome = Console.ReadLine();

                int cont=0;
                while (cont < usuarios.Count)
                {
                    if (nome == usuarios[cont])
                    {
                        Console.Write("Insira o novo nome: ");
                        nome = Console.ReadLine();
                        usuarios[cont] = nome;

                        Console.WriteLine("O nome foi alterado com sucesso!");
                        retornarMenu();
                    }
                    cont++;
                }

                Console.WriteLine("\nEsse nome não existe na lista!");
                retornarMenu();
            }

            if(opcao == 5)
            {
                cabeçalho();
                verificarListaVazia();
                listaDeUsuarios();
                retornarMenu();
            }

            Console.ReadKey();
        }
    }
}
