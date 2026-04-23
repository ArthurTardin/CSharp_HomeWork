//============
using System;
using System.Collections.Generic;

namespace Sistema_de_competição_multi_esportes
{
    internal class Program
    {
        static void Main()
        {
            ProgramExecute.MenuAndChoice();
        }
    }

    //============================
    //Classe principal do sistema
    //============================
    public class ProgramExecute
    {
        public static void MenuAndChoice()
        {
            int choice;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Bem-vindo ao sistema multi-esportes!");
                Console.WriteLine("1. Futebol");
                Console.WriteLine("2. Rugby");
                Console.WriteLine("3. Luta");
                Console.WriteLine("0. Sair");

                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Entrada inválida.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        new FootballCompetition().FootballMenu();
                        break;

                    case 2:
                        new RugbyCompetition().RugbyMenu();
                        break;

                    case 3:
                        new FightCompetition().FightMenu();
                        break;

                    case 0:
                        return;
                }
            }
        }
    }

    //============================
    // FUTEBOL
    //============================
    public class FootballCompetition
    {
        List<FootballCompetitor> players = new List<FootballCompetitor>();

        public void FootballMenu()
        {
            int choice;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Futebol ===");
                Console.WriteLine("1. Adicionar jogador");
                Console.WriteLine("2. Listar jogadores");
                Console.WriteLine("3. Voltar");

                int.TryParse(Console.ReadLine(), out choice);

                switch (choice)
                {
                    case 1:
                        AddPlayer();
                        break;

                    case 2:
                        ListPlayers();
                        break;

                    case 3:
                        return;
                }
            }
        }

        void AddPlayer()
        {
            FootballCompetitor p = new FootballCompetitor() { name = ""};

            Console.Write("Nome: ");
            p.name = Console.ReadLine()!;

            Console.Write("Idade: ");
            p.Age = int.Parse(Console.ReadLine()!);

            Console.Write("Gols: ");
            p.GoalsScored = int.Parse(Console.ReadLine()!);

            Console.Write("Assistências: ");
            p.Assists = int.Parse(Console.ReadLine()!);

            players.Add(p);
        }

        void ListPlayers()
        {
            Console.Clear();

            foreach (var p in players)
            {
                p.ShowStats();
                Console.WriteLine("Score: " + p.GetScore());
                Console.WriteLine("----------------");
            }

            Console.ReadLine();
        }
    }

    //============================
    // RUGBY
    //============================
    public class RugbyCompetition
    {
        List<RugbyCompetitor> players = new List<RugbyCompetitor>();

        public void RugbyMenu()
        {
            int choice;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Rugby ===");
                Console.WriteLine("1. Adicionar jogador");
                Console.WriteLine("2. Listar jogadores");
                Console.WriteLine("3. Voltar");

                int.TryParse(Console.ReadLine(), out choice);

                switch (choice)
                {
                    case 1:
                        AddPlayer();
                        break;

                    case 2:
                        ListPlayers();
                        break;

                    case 3:
                        return;
                }
            }
        }

        void AddPlayer()
        {
            RugbyCompetitor p = new RugbyCompetitor() { name = ""};

            Console.Write("Nome: ");
            p.name = Console.ReadLine()!;

            Console.Write("Idade: ");
            p.Age = int.Parse(Console.ReadLine()!);

            Console.Write("Tries: ");
            p.Tries = int.Parse(Console.ReadLine()!);

            Console.Write("Tackles: ");
            p.Tackles = int.Parse(Console.ReadLine()!);

            players.Add(p);
        }

        void ListPlayers()
        {
            Console.Clear();

            foreach (var p in players)
            {
                p.ShowStats();
                Console.WriteLine("Score: " + p.GetScore());
                Console.WriteLine("----------------");
            }

            Console.ReadLine();
        }
    }

    //============================
    // LUTA
    //============================
    public class FightCompetition
    {
        List<FighterCompetitor> players = new List<FighterCompetitor>();

        public void FightMenu()
        {
            int choice;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Luta ===");
                Console.WriteLine("1. Adicionar lutador");
                Console.WriteLine("2. Listar lutadores");
                Console.WriteLine("3. Voltar");

                int.TryParse(Console.ReadLine(), out choice);

                switch (choice)
                {
                    case 1:
                        AddPlayer();
                        break;

                    case 2:
                        ListPlayers();
                        break;

                    case 3:
                        return;
                }
            }
        }

        void AddPlayer()
        {
            FighterCompetitor p = new FighterCompetitor() { name = ""};

            Console.Write("Nome: ");
            p.name = Console.ReadLine()!;

            Console.Write("Idade: ");
            p.Age = int.Parse(Console.ReadLine()!);

            Console.Write("Vitórias: ");
            p.Wins = int.Parse(Console.ReadLine()!);

            Console.Write("Knockouts: ");
            p.Knockouts = int.Parse(Console.ReadLine()!);

            players.Add(p);
        }

        void ListPlayers()
        {
            Console.Clear();

            foreach (var p in players)
            {
                p.ShowStats();
                Console.WriteLine("Score: " + p.GetScore());
                Console.WriteLine("----------------");
            }

            Console.ReadLine();
        }
    }

    //============================
    // BASE ABSTRATA
    //============================
    abstract class Competitor
    {
        public required string name { get; set; }

        private int age;

        public int Age
        {
            get { return age; }
            set
            {
                if (value < 16)
                {
                    Console.WriteLine("Idade mínima é 16.");
                    age = 16;
                }
                else
                {
                    age = value;
                }
            }
        }

        public abstract void ShowStats();
        public abstract int GetScore();
    }

    //============================
    // FUTEBOL
    //============================
    class FootballCompetitor : Competitor
    {
        public int GoalsScored { get; set; }
        public int Assists { get; set; }

        public override void ShowStats()
        {
            Console.WriteLine($"Nome: {name} | Gols: {GoalsScored} | Assistências: {Assists}");
        }

        public override int GetScore()
        {
            return GoalsScored * 4 + Assists * 2;
        }
    }

    //============================
    // RUGBY
    //============================
    class RugbyCompetitor : Competitor
    {
        public int Tries { get; set; }
        public int Tackles { get; set; }

        public override void ShowStats()
        {
            Console.WriteLine($"Nome: {name} | Tries: {Tries} | Tackles: {Tackles}");
        }

        public override int GetScore()
        {
            return Tries * 5 + Tackles;
        }
    }

    //============================
    // LUTA
    //============================
    class FighterCompetitor : Competitor
    {
        public int Wins { get; set; }
        public int Knockouts { get; set; }

        public override void ShowStats()
        {
            Console.WriteLine($"Nome: {name} | Vitórias: {Wins} | Nocaute: {Knockouts}");
        }

        public override int GetScore()
        {
            return Wins * 3 + Knockouts * 5;
        }
    }
}