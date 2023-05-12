using dnew.board;

namespace dnew.snake {
    public interface ISnake {
        (int x, int y) GetHeadPos();
        bool IsBodyPos(int x, int y);
        void AddSegment(int x, int y);
        bool MoveUp(IGameBoard gameBoard);
        bool MoveDown(IGameBoard gameBoard);
        bool MoveLeft(IGameBoard gameBoard);
        bool MoveRight(IGameBoard gameBoard);
    }
}