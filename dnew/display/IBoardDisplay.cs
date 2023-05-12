using dnew.board;
using dnew.snake;

namespace dnew.display
{
    public interface IBoardDisplay
    {
       void Draw(ISnake snake, IGameBoard gameBoard, int score, int boardSizeX, int boardSizeY);
       void GameOver();
    }
}