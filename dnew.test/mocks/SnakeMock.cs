using dnew.board;
using dnew.snake;
using Moq;

namespace dnew.test.mocks {
    public class SnakeMock : ISnake
    {
        private Mock<ISnake> _snake = new Mock<ISnake>();

        public bool IsBodyPos(int x, int y)
        {
            return _snake.Object.IsBodyPos(x, y);
        }

        public SnakeMock StubIsBodyPos(List<bool> stubs) {
            var setup = _snake.SetupSequence(x => x.IsBodyPos(It.IsAny<int>(), It.IsAny<int>()));
            foreach(var stub in stubs) {
                setup.Returns(stub);
            }
            return this;
        }

        public void AssertSnakeIsBodyPosWasCalledWith(int x, int y) {
            _snake.Verify(g => g.IsBodyPos(x, y), Times.Once);
        }

        public void AddSegment(int x, int y)
        {
            throw new NotImplementedException();
        }

        public bool MoveUp(IGameBoard gameBoard)
        {
            throw new NotImplementedException();
        }

        public bool MoveDown(IGameBoard gameBoard)
        {
            throw new NotImplementedException();
        }

        public bool MoveLeft(IGameBoard gameBoard)
        {
            throw new NotImplementedException();
        }

        public bool MoveRight(IGameBoard gameBoard)
        {
            throw new NotImplementedException();
        }

        public (int x, int y) GetHeadPos()
        {
            throw new NotImplementedException();
        }
    }
}