using System.Collections.Generic;

namespace UglyTrivia
{
    internal class Player
    {
        public Player(string playerName)
        {
            this.Name = playerName;
            this.Purse = 0;
            this.Place = 0;
        }

        public string Name { get; private set; }
        public int Purse { get; private set; }
        public int Place { get; private set; }

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