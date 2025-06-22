using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Treino02Projeto02
{
    class Treinodois
    {
        [System.Serializable]
        struct Cliente
        {
            public string nome;
            public string email;
            public string cpf;
        }

        static List<Cliente> clientes = new List<Cliente>();

        enum Menu { Listagem = 1, Adicionar, Remover, Sair }

        static void Main(string[] args)
        {
            Carregar();
            bool escolheuSair = false;
            while (!escolheuSair)
            {
                Console.Clear();
                Console.WriteLine("Sistema de clientes - Bem-vindo!\n");
                Console.WriteLine("1 - Listagem\n2 - Adicionar\n3 - Remover\n4 - Sair\n");
                int opcao = int.Parse(Console.ReadLine());
                Menu opcaoSelecionada = (Menu)opcao;

                switch (opcaoSelecionada)
                {
                    case Menu.Listagem:
                        Listagem();
                        break;
                    case Menu.Adicionar:
                        Adicionar();
                        break;
                    case Menu.Remover:
                        Remover();
                        break;
                    case Menu.Sair:
                        escolheuSair = true;
                        break;
                }
            }
        }

        static void Listagem()
        {
            Console.Clear();
            Console.WriteLine("Lista de clientes:\n");
            int id = 0;
            
            if (clientes.Count >= 1)
            {
                foreach (Cliente cliente in clientes)
                {
                    Console.WriteLine($"ID do cliente: {id}");
                    Console.WriteLine($"Nome do cliente: {cliente.nome}");
                    Console.WriteLine($"Email do cliente: {cliente.email}");
                    Console.WriteLine($"CPF do cliente: {cliente.cpf}");
                    Console.WriteLine("==========================================");
                    id++;
                }
            }            
            else
            {
                Console.WriteLine("Nenhum cliente cadastrado ainda!");
            }

            Console.WriteLine("\nAperte ENTER para voltar ao menu!");
            Console.ReadLine();
        }

        static void Adicionar()
        {
            Console.Clear();
            Console.WriteLine("Cadastre um novo cliente abaixo:\n");
            Cliente novoCli = new Cliente();
            Console.Write("Digite o nome: ");
            novoCli.nome = Console.ReadLine();
            Console.Write("Digite o e-mail: ");
            novoCli.email = Console.ReadLine();
            Console.Write("Digite o CPF: ");
            novoCli.cpf = Console.ReadLine();

            clientes.Add(novoCli);
            Salvar();

            Console.WriteLine("\nCadastro completo, aperte ENTER para voltar ao menu!");
            Console.ReadLine();
        }

        static void Remover()
        {
            Console.Clear();
            Console.WriteLine("Remoção de cliente:\n");
            
            if (clientes.Count > 0)
            {
                try
                {
                    int id = 0;

                    foreach (Cliente cliente in clientes)
                    {
                        Console.WriteLine($"ID do cliente: {id}");
                        Console.WriteLine($"Nome do cliente: {cliente.nome}");
                        Console.WriteLine($"Email do cliente: {cliente.email}");
                        Console.WriteLine($"CPF do cliente: {cliente.cpf}");
                        Console.WriteLine("==========================================");
                        id++;
                    }

                    Console.Write("Digite o ID do cliente: ");
                    int idd = int.Parse(Console.ReadLine());
                    clientes.RemoveAt(idd);
                    Console.WriteLine("Remoção bem sucedida!");
                }
                catch
                {
                    Console.WriteLine("ID inválido");
                }
            }
            else
            {
                Console.WriteLine("Nenhum cliente cadastrado ainda!");
            }

            Salvar();
            Console.WriteLine("\nAperte ENTER para voltar ao menu.");
            Console.ReadLine();
        }

        static void Salvar()
        {
            FileStream dados = new FileStream("Clientes.bin", FileMode.OpenOrCreate);
            BinaryFormatter encoder = new BinaryFormatter();
            encoder.Serialize(dados, clientes);
            dados.Close();
        }

        static void Carregar()
        {
            FileStream dados = new FileStream("Clientes.bin", FileMode.OpenOrCreate);
            BinaryFormatter encoder = new BinaryFormatter();
            clientes = (List<Cliente>)encoder.Deserialize(dados);
            dados.Close();
        }
    }
}
