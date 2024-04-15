namespace CowsBullsModelLib
{
    public class Player
    {
        public string Name { get; set; }
        public int MyScore { get; set; } = 0;

        public Player(string name)
        {
            Name = name;
        }
    }
}
