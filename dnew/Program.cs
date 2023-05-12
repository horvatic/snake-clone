using dnew.board;
using dnew.display;
using dnew.engine;
using dnew.rolls;
using dnew.snake;

Console.Clear();

var boardSize = 32;

var boardMem = new List<List<bool>>();
for(var i = 0; i < boardSize; i++) {
    boardMem.Add(new List<bool>());
    for(var j = 0; j < boardSize; j++) {
        boardMem[i].Add(false);
    }
}
var board = new GameBoard(boardMem);

var snake = new SnakeManager(new List<(int x, int y)>(), boardSize, boardSize);
snake.AddSegment(12, 12);

var dice = new DiceRoll();
var foodRool = new FoodRoll(dice, boardSize);

var display = new BoardDisplay();

var game = new GameEngine(snake, board, foodRool, display, boardSize, boardSize);

game.Run();