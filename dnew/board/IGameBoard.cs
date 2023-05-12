namespace dnew.board {
    public interface IGameBoard {
        void AddFood(int x, int y);
        void RemoveFood(int x, int y);
        bool HasFood(int x, int y);
        bool DoesBoardHaveFood();
    }
}