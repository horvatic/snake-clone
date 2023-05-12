using dnew.board;
using dnew.display;
using dnew.rolls;
using dnew.snake;

namespace dnew.engine {
    public class GameEngine {

        private readonly ISnake _snake;
        private readonly IGameBoard _gameBoard;
        private readonly IFoodRoll _foodRoll;
        private readonly IBoardDisplay _boardDisplay;
        private readonly (int x, int y) _boardSize;

        private int score;

        public GameEngine(ISnake snake, IGameBoard gameBoard, IFoodRoll foodRoll, IBoardDisplay boardDisplay, int boardXSize, int boardYSize) {
            _snake = snake;
            _gameBoard = gameBoard;
            _foodRoll = foodRoll;
            _boardDisplay = boardDisplay;
            _boardSize = (boardXSize, boardYSize);
            score = 0;
        }

        public void Run() {
            var gameRunning = true;
            var currentKey = ConsoleKey.W;
            var couldMove = true;
            
            Task.Run(() => {
                while(gameRunning) {
                    var key = Console.ReadKey(true);
                    if(key.Key == ConsoleKey.W) {
                    currentKey = ConsoleKey.W;
                    } else if(key.Key == ConsoleKey.A) {
                        currentKey = ConsoleKey.A;
                    } else if(key.Key == ConsoleKey.D) {
                        currentKey = ConsoleKey.D;
                    } else if(key.Key == ConsoleKey.S) {
                        currentKey = ConsoleKey.S;
                    }
                }
            });

            while(gameRunning) {
                if(!_gameBoard.DoesBoardHaveFood()) {
                    var food = _foodRoll.Roll(_snake);
                    _gameBoard.AddFood(food.x, food.y);
                }
                _boardDisplay.Draw(_snake, _gameBoard, score, _boardSize.x, _boardSize.y);
                if(currentKey == ConsoleKey.W) {
                    couldMove = _snake.MoveUp(_gameBoard);
                } else if(currentKey == ConsoleKey.A) {
                    couldMove = _snake.MoveLeft(_gameBoard);
                } else if(currentKey == ConsoleKey.D) {
                    couldMove = _snake.MoveRight(_gameBoard);
                } else if(currentKey == ConsoleKey.S) {
                    couldMove = _snake.MoveDown(_gameBoard);
                }
                
                if(!couldMove) {
                    gameRunning = false;
                    _boardDisplay.GameOver();
                    return;
                } else {   
                    var head = _snake.GetHeadPos();
                    if(_gameBoard.HasFood(head.x, head.y)) {
                        _gameBoard.RemoveFood(head.x, head.y);
                        score++;
                    }
                    Thread.Sleep(100);
                }
            }
        }
    }
}