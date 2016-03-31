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
            InPenaltyBox = false;
        }

        public string Name { get; private set; }
        public int Purse { get; private set; }
        public int Place { get; private set; }
        public bool InPenaltyBox { get; private set; }

        public void MovePlace(int roll)
        {
            Place += roll;
            if (Place > 11) Place = Place - 12;
        }

        public void AddOnePurse()
        {
            Purse++;
        }

        public void GoToPrison()
        {
            InPenaltyBox = true;
        }

        public class Players
        {
            List<Player> players = new List<Player>();

            public List<Player> AddPlayer(Player player)
            {
                players.Add(player);
                return players;
            }

            public Player Player(int numPlayer)
            {
                return players[numPlayer];
            }
        }
    }
}