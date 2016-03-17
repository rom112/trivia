namespace UglyTrivia
{
    internal class Player
    {
        public Player(string playerName)
        {
            Name = playerName;
        }

        public string Name { get; private set; }
    }
}