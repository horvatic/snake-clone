using System.Linq;
using dnew.board;

namespace dnew.snake {
    public class SnakeManager : ISnake
    {
        private readonly List<(int x, int y)> _snake;
        private readonly (int x, int y) _boardSize;

        public SnakeManager(List<(int x, int y)> snake, int boardSizeX, int boardSizeY) {
            _snake = snake;
            _boardSize = (boardSizeX, boardSizeY);
        }

        public bool IsBodyPos(int x, int y)
        {
            return _snake.Count(s => s.x == x && s.y == y) > 0;
        }

        public void AddSegment(int x, int y) {
            _snake.Insert(0, (x, y));
        }

        public bool MoveUp(IGameBoard gameBoard)
        {
            var x = _snake[0].x;
            var y = _snake[0].y - 1;

            if(x < 0 || y < 0 || x > _boardSize.x - 1 || y > _boardSize.y - 1  || IsBodyPos(x, y)) {
                return false;
            }

            AddSegment(x, y);

            if (!gameBoard.HasFood(x, y)) {
                _snake.Remove(_snake.Last());
            }

            return true;
        }

        public bool MoveDown(IGameBoard gameBoard)
        {
            var x = _snake[0].x;
            var y = _snake[0].y + 1;

            if(x < 0 || y < 0 || x > _boardSize.x - 1 || y > _boardSize.y - 1 || IsBodyPos(x, y)) {
                return false;
            }

            AddSegment(x, y);

            if (!gameBoard.HasFood(x, y)) {
                _snake.Remove(_snake.Last());
            }

            return true;
        }

        public bool MoveLeft(IGameBoard gameBoard)
        {
            var x = _snake[0].x - 1;
            var y = _snake[0].y;

            if(x < 0 || y < 0 || x > _boardSize.x - 1 || y > _boardSize.y - 1  || IsBodyPos(x, y)) {
                return false;
            }

            AddSegment(x, y);

            if (!gameBoard.HasFood(x, y)) {
                _snake.Remove(_snake.Last());
            }

            return true;
        }

        public bool MoveRight(IGameBoard gameBoard)
        {
            var x = _snake[0].x + 1;
            var y = _snake[0].y;

            if(x < 0 || y < 0 || x > _boardSize.x - 1 || y > _boardSize.y - 1  || IsBodyPos(x, y)) {
                return false;
            }

            AddSegment(x, y);

            if (!gameBoard.HasFood(x, y)) {
                _snake.Remove(_snake.Last());
            }

            return true;
        }

        public (int x, int y) GetHeadPos()
        {
            return _snake[0];
        }
    }
}