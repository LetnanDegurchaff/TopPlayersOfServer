using System;
using System.Collections.Generic;
using System.Linq;

namespace TopPlayersOfServer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Server server = new Server();
            server.Work();
        }
    }

    class Server
    {
        private List<Player> _players;

        public Server()
        {
            PlayerListCreator playerListCreator = new PlayerListCreator();
            _players = new List<Player>();

            _players = playerListCreator.CreatePlayers();
        }

        public void Work()
        {
            List<Player> topThreeStrengthPlayers = GetTopThreeStrengthPlayers();
            List<Player> topThreeLevelPlayers = GetTopThreeLevelPlayers();

            ConsoleOutputMethods.WriteRedText("Все игроки на сервере");
            ShowPlayers(_players);

            ConsoleOutputMethods.WriteRedText("Топ 3 игроков по уровню");
            ShowPlayers(topThreeLevelPlayers);

            ConsoleOutputMethods.WriteRedText("Топ 3 игроков по силе");
            ShowPlayers(topThreeStrengthPlayers);
        }

        private void ShowPlayers(List<Player> players)
        {
            foreach (Player player in players)
            {
                Console.WriteLine($"{player.Name}\n" +
                    $"LVL - {player.Level}\n" +
                    $"Сила - {player.Strength}\n");
            }
        }

        private List<Player> GetTopThreeStrengthPlayers()
        {
            return _players
                .OrderByDescending(player => player.Strength)
                .Take(3)
                .ToList();
        }

        private List<Player> GetTopThreeLevelPlayers()
        {
            return _players
                .OrderByDescending(player => player.Level)
                .Take(3)
                .ToList();
        }
    }

    class Player
    {
        public Player(string name, int level, int strength)
        {
            Name = name;
            Level = level;
            Strength = strength;
        }

        public string Name { get; private set; }
        public int Level { get; private set; }
        public int Strength { get; private set; }
    }

    class PlayerListCreator
    {
        private Random _random = new Random();
        private List<string> _names;

        public PlayerListCreator()
        {
            _names = new List<string>
            {
                "Letnan_Degurchaff",
                "NOOB_007_2000",
                "Nagibator_666",
                "!_Verzila_!",
                "Biba",
                "Boba",
                "Suzuya_Juzo",
                "ABOBUS",
                "WyvernsImpermanence",
                "Laiz"
            };
        }

        public List<Player> CreatePlayers()
        {
            List<Player> playersList = new List<Player>();

            int minimumLevel = 1;
            int maximumLevel = 100;
            int minimumStrength = 0;
            int maximumStrength = 100;

            for (int i = 0; i < _names.Count; i++)
            {
                playersList.Add(new Player(_names[i],
                    _random.Next(minimumLevel, maximumLevel + 1),
                    _random.Next(minimumStrength, maximumStrength + 1)));
            }

            return playersList;
        }
    }

    static class ConsoleOutputMethods
    {
        public static void WriteRedText(string text)
        {
            ConsoleColor tempColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(text);
            Console.ForegroundColor = tempColor;
        }
    }
}
