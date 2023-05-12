using dnew.board;
using dnew.snake;

namespace dnew.display {
    public class BoardDisplay : IBoardDisplay {
        public void Draw(ISnake snake, IGameBoard gameBoard, int score, int boardSizeX, int boardSizeY) {
            Console.SetCursorPosition(0,0);
            for(var i = 0; i < boardSizeY; i++) {
                for(var j = 0; j < boardSizeX; j++) {
                    if(snake.IsBodyPos(j, i)) {
                        Console.Write("*");
                    } else if (gameBoard.HasFood(j, i)) {
                        Console.Write("O");
                    } else {
                        Console.Write("-");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine($"++++++++Score: {score}++++++++");
        }

        public void GameOver()
        {   
            Console.WriteLine("++++++++Game Over!++++++++");
        }
    }
}