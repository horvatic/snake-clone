using dnew.snake;

namespace dnew.rolls {
    public class FoodRoll : IFoodRoll {

        private readonly IDiceRoll _dice;
        private readonly int _maxRoll;

        public FoodRoll(IDiceRoll dice, int maxRoll) {
            _dice = dice;
            _maxRoll = maxRoll;
        }

        public (int x, int y) Roll(ISnake snake) {
            var search = true;
            var x = 0;
            var y = 0;
            while(search) {
                x = _dice.Roll(_maxRoll);
                y = _dice.Roll(_maxRoll);
                search = snake.IsBodyPos(x, y);
            }

            return(x, y);
        }

    }
}