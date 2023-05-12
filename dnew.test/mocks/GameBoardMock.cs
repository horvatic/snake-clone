using dnew.board;
using Moq;

namespace dnew.test.mocks {
    public class GameBoardMock : IGameBoard
    {
        private Mock<IGameBoard> _board = new Mock<IGameBoard>();

        public void AddFood(int x, int y)
        {
            throw new NotImplementedException();
        }

        public bool DoesBoardHaveFood()
        {
            throw new NotImplementedException();
        }

        public bool HasFood(int x, int y)
        {
            return _board.Object.HasFood(It.IsAny<int>(), It.IsAny<int>());
        }

        public void RemoveFood(int x, int y)
        {
            throw new NotImplementedException();
        }

        public GameBoardMock StubHasFoodWith(bool stub) {
            _board.Setup(x => x.HasFood(It.IsAny<int>(), It.IsAny<int>())).Returns(stub);
            return this;
        }
    }
}