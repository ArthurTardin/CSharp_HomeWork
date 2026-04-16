using System;
using System.Collections.Generic;
using System.Threading;

namespace SistemCampeonato_Rugby
{
    internal class Program
    {
        static List<Player> players = new List<Player>();

        static void Main()
        {
            ProgramExecute();
        }

        static void ProgramExecute()
        {
            while (true)
            {
                Console.WriteLine("Bem-vindo ao Sistema de Campeonato de Rugby!");
                Console.WriteLine("Selecione uma opção:");
                Console.WriteLine("1 - Cadastrar Jogador");
                Console.WriteLine("2 - Registrar Partida");
                Console.WriteLine("3 - Consultar Jogador");
                Console.WriteLine("4 - Listar Jogadores");
                Console.WriteLine("5 - Mostrar ranking");
                Console.WriteLine("0 - Sair");

                int option;

                while (!int.TryParse(Console.ReadLine(), out option))
                {
                    Console.WriteLine("Entrada inválida.");
                }

                Console.Clear();

                switch (option)
                {
                    case 0:
                        Console.WriteLine("Saindo do programa...");
                        return;
                    case 1:
                        RegisterPlayer();
                        Displayclear();
                        break;
                    case 2:
                        RegisterMatch();
                        Displayclear();
                        break;
                    case 3:
                        ForeachPlayer();
                        Displayclear();
                        break;
                    case 4:
                        ListPlayers();
                        Displayclear();
                        break;
                    case 5:
                        ShowRanking();
                        Displayclear();
                        break;
                    default:
                        Console.WriteLine("Opção inválida.");
                        Displayclear();
                        break;

                }
            }
        }

        static void RegisterPlayer()
        {
            Console.WriteLine("Cadastro de Jogador");

            Console.WriteLine("Digite o nome:");
            string name = Console.ReadLine()!;

            int age;
            while (true)
            {
                Console.WriteLine("Digite a idade:");
                if (int.TryParse(Console.ReadLine(), out age) && age >= 13)
                    break;

                Console.WriteLine("Idade inválida.");
            }

            Console.WriteLine("Digite a posição:");
            string position = Console.ReadLine()!;

            Player newPlayer = new Player
            {
                name = name,
                Age = age,
                position = position
            };

            players.Add(newPlayer);

            Console.WriteLine("Jogador cadastrado!");
        }

        static void RegisterMatch()
        {
            Console.WriteLine("Digite o nome do jogador:");
            string name = Console.ReadLine()!;

            Player? player = players.Find(p =>
                p.name.Equals(name, StringComparison.OrdinalIgnoreCase));

            if (player == null)
            {
                Console.WriteLine("Jogador não encontrado!");
                return;
            }

            int pontos;
            while (true)
            {
                Console.WriteLine("Quantos pontos ele fez?");
                if (int.TryParse(Console.ReadLine(), out pontos))
                    break;

                Console.WriteLine("Valor inválido.");
            }

            player.AdicionarPartida(pontos);

            Console.WriteLine("Partida registrada!");
        }

         static void ForeachPlayer()
        {
            Console.WriteLine("Digite o nome do jogador:");
            string name = Console.ReadLine()!;
            Player? player = players.Find(p => p.name.Equals(name, StringComparison.OrdinalIgnoreCase)); 
            if (player == null)
            {
                Console.WriteLine("Jogador não encontrado!");
            }
            else
            {
                Console.WriteLine("Jogador encontrado!");
                Console.WriteLine("Nome: " + player.name);
                Console.WriteLine("Idade: " + player.Age);
                Console.WriteLine("Posição: " + player.position);
                Console.WriteLine("Partidas jogadas: " + player.matchesPlayed);
            }
        }

        static void ListPlayers()
        {
            if (players.Count == 0)
            {
                Console.WriteLine("Nenhum jogador cadastrado.");
                return;
            }
            var OrdersByName = players.OrderBy(p => p.name);
            foreach (var player in OrdersByName)
            {
                Console.WriteLine(player.name);
            }
        }

        static void Displayclear()
        {
            Console.WriteLine("Pressione Enter para continuar...");
            Console.ReadLine();
            Console.Clear();
        }

        static void ShowRanking()
        {
            if (players.Count == 0)
            {
                Console.WriteLine("Nenhum jogador cadastrado.");
                return;
            }

            Console.WriteLine("Ranking dos Jogadores:");

            var ranking = players.OrderByDescending(p => p.points).ToList();

            int position = 1;

            foreach(var player in ranking)
            {
                Console.WriteLine($"{position}. {player.name} - Pontos: {player.points}");
                position++;
            }

        }
    }

    //===================================
    // Classe Player
    //===================================
    internal class Player
    {
        public required string name { get; set; }

        private int _age;

        public int Age
        {
            get { return _age; }
            set
            {
                if (value < 13)
                {
                    Console.WriteLine("Idade mínima é 13.");
                }
                else
                {
                    _age = value;
                }
            }
        }

        public required string position { get; set; }

        public int matchesPlayed { get; private set; }

        public int points { get; private set; }

        public void AdicionarPartida(int pontos)
        {
            matchesPlayed++;
            points += pontos;
        }
    }
}