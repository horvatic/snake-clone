namespace dnew.board {
    public class GameBoard : IGameBoard
    {

        private readonly List<List<bool>> _board;

        public GameBoard(List<List<bool>> board) {
            _board = board;
        }

        public void AddFood(int x, int y)
        {
            _board[x][y] = true;
        }

        public void RemoveFood(int x, int y)
        {
            _board[x][y] = false;
        }

        public bool HasFood(int x, int y) {
            return _board[x][y];

        }

        public bool DoesBoardHaveFood() {
            foreach(var row in _board) {
                foreach(var val in row) {
                    if(val) {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}