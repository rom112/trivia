using System.Collections.Generic;

namespace UglyTrivia
{
    internal class Player
    {
        public Player(string playerName, string purse, string place)
        {
            Name = playerName;
            this.Purse = purse;
            Place = place;
        }

        public string Name { get; private set; }
        public string Purse { get; private set; }
        public string Place { get; private set; }

        public class Players
        {
            List<Player> players = new List<Player>();

            public List<Player> add(Player player)
            {
                players.Add(player);
                return players;
            }

            public Player Player(int numPlayer)
            {
                return players[numPlayer];
            }

            public int Count()
            {
                return players.Count;
            }
        }
    }
}