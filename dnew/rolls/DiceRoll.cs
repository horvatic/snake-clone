namespace dnew.rolls {

    public class DiceRoll : IDiceRoll
    {
        private readonly Random _dice;

        public DiceRoll() {
            _dice = new Random(DateTime.UtcNow.Microsecond);
        }

        public int Roll(int maxRoll)
        {
            return _dice.Next(0, maxRoll);
        }
    }

}