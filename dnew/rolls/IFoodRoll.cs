using dnew.snake;

namespace dnew.rolls
{
    public interface IFoodRoll
    {
        (int x, int y) Roll(ISnake snake);
    }
}