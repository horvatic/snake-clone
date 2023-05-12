using dnew.snake;
using dnew.test.mocks;

namespace dnew.test {
    public class SnakeManagerTest {

        [Fact]
        public void IsBodyPos_IsSet_Sucessfully()
        {
            var body = new List<(int x, int y)> {
                (1, 1)
            };
            var snake = new SnakeManager(body, 100, 100);

            var result = snake.IsBodyPos(1, 1);

            Assert.True(result);

        }


        [Fact]
        public void IsBodyPos_IsNotSet_Sucessfully()
        {
            var body = new List<(int x, int y)> {
                (1, 1)
            };
            var snake = new SnakeManager(body, 100, 100);

            var result = snake.IsBodyPos(0, 1);

            Assert.False(result);

        }

        [Fact]
        public void AddSegment_Sucessfully()
        {
            var body = new List<(int x, int y)> {
                (1, 1)
            };
            var snake = new SnakeManager(body, 100, 100);

            snake.AddSegment(1, 2);

            var result = body[0];
            Assert.Equal(1, result.x);
            Assert.Equal(2, result.y);

        }

        [Fact]
        public void MoveUp_Sucessfully()
        {
            var body = new List<(int x, int y)> {
                (1, 1),
                (0, 1),
                (0, 0)
            };
            var gameBoard = new GameBoardMock().StubHasFoodWith(false);
            var snake = new SnakeManager(body, 100, 100);

            var result = snake.MoveUp(gameBoard);

            Assert.True(result);
            Assert.Equal(3, body.Count);

            Assert.Equal(1, body[0].x);
            Assert.Equal(0, body[0].y);

            Assert.Equal(1, body[1].x);
            Assert.Equal(1, body[1].y);

            Assert.Equal(0, body[2].x);
            Assert.Equal(1, body[2].y);

        }

        [Fact]
        public void MoveUp_WithFood_Sucessfully()
        {
            var body = new List<(int x, int y)> {
                (1, 1),
                (0, 1),
                (0, 0)
            };
            var gameBoard = new GameBoardMock().StubHasFoodWith(true);
            var snake = new SnakeManager(body, 100, 100);

            var result = snake.MoveUp(gameBoard);

            Assert.True(result);
            Assert.Equal(4, body.Count);

            Assert.Equal(1, body[0].x);
            Assert.Equal(0, body[0].y);

            Assert.Equal(1, body[1].x);
            Assert.Equal(1, body[1].y);

            Assert.Equal(0, body[2].x);
            Assert.Equal(1, body[2].y);

            Assert.Equal(0, body[3].x);
            Assert.Equal(0, body[3].y);

        }

        [Fact]
        public void MoveUp_OutOfBounds_Sucessfully()
        {
            var body = new List<(int x, int y)> {
                (199999, 199999),
                (999, 999),
                (999, 99999)
            };
            var gameBoard = new GameBoardMock().StubHasFoodWith(true);
            var snake = new SnakeManager(body, 1, 1);

            var result = snake.MoveUp(gameBoard);

            Assert.False(result);
            Assert.Equal(3, body.Count);

            Assert.Equal(199999, body[0].x);
            Assert.Equal(199999, body[0].y);

            Assert.Equal(999, body[1].x);
            Assert.Equal(999, body[1].y);

            Assert.Equal(999, body[2].x);
            Assert.Equal(99999, body[2].y);

        }

        [Fact]
        public void MoveUp_OnBody_Sucessfully()
        {
            var body = new List<(int x, int y)> {
                (0, 3),
                (0, 2),
                (0, 1)
            };
            var gameBoard = new GameBoardMock().StubHasFoodWith(true);
            var snake = new SnakeManager(body, 100, 1000);

            var result = snake.MoveUp(gameBoard);

            Assert.False(result);

        }

        [Fact]
        public void MoveDown_Sucessfully()
        {
            var body = new List<(int x, int y)> {
                (1, 1),
                (0, 1),
                (0, 0)
            };
            var gameBoard = new GameBoardMock().StubHasFoodWith(false);
            var snake = new SnakeManager(body, 100, 100);

            var result = snake.MoveDown(gameBoard);

            Assert.True(result);
            Assert.Equal(3, body.Count);
            
            Assert.Equal(1, body[0].x);
            Assert.Equal(2, body[0].y);

            Assert.Equal(1, body[1].x);
            Assert.Equal(1, body[1].y);

            Assert.Equal(0, body[2].x);
            Assert.Equal(1, body[2].y);

        }

        [Fact]
        public void MoveDown_WithFood_Sucessfully()
        {
            var body = new List<(int x, int y)> {
                (1, 1),
                (0, 1),
                (0, 0)
            };
            var gameBoard = new GameBoardMock().StubHasFoodWith(true);
            var snake = new SnakeManager(body, 100, 100);

            var result = snake.MoveDown(gameBoard);

            Assert.True(result);
            Assert.Equal(4, body.Count);
            
            Assert.Equal(1, body[0].x);
            Assert.Equal(2, body[0].y);

            Assert.Equal(1, body[1].x);
            Assert.Equal(1, body[1].y);

            Assert.Equal(0, body[2].x);
            Assert.Equal(1, body[2].y);

            Assert.Equal(0, body[3].x);
            Assert.Equal(0, body[3].y);

        }

        [Fact]
        public void MoveDown_OutOfBounds_Sucessfully()
        {
            var body = new List<(int x, int y)> {
                (19999, 19999),
                (9999, 9999),
                (999, 88888)
            };
            var gameBoard = new GameBoardMock().StubHasFoodWith(true);
            var snake = new SnakeManager(body, 1, 1);

            var result = snake.MoveDown(gameBoard);

            Assert.False(result);
            Assert.Equal(3, body.Count);
            
            Assert.Equal(19999, body[0].x);
            Assert.Equal(19999, body[0].y);

            Assert.Equal(9999, body[1].x);
            Assert.Equal(9999, body[1].y);

            Assert.Equal(999, body[2].x);
            Assert.Equal(88888, body[2].y);
        }

        [Fact]
        public void MoveDown_OnBody_Sucessfully()
        {
            var body = new List<(int x, int y)> {
                (0, 1),
                (0, 2),
                (0, 3)
            };
            var gameBoard = new GameBoardMock().StubHasFoodWith(true);
            var snake = new SnakeManager(body, 100, 100);

            var result = snake.MoveDown(gameBoard);

            Assert.False(result);
        }

        [Fact]
        public void MoveLeft_Sucessfully()
        {
            var body = new List<(int x, int y)> {
                (1, 1),
                (2, 1),
                (3, 0)
            };
            var gameBoard = new GameBoardMock().StubHasFoodWith(false);
            var snake = new SnakeManager(body, 100, 100);

            var result = snake.MoveLeft(gameBoard);

            Assert.True(result);
            Assert.Equal(3, body.Count);
            
            Assert.Equal(0, body[0].x);
            Assert.Equal(1, body[0].y);

            Assert.Equal(1, body[1].x);
            Assert.Equal(1, body[1].y);

            Assert.Equal(2, body[2].x);
            Assert.Equal(1, body[2].y);

        }

        [Fact]
        public void MoveLeft_WithFood_Sucessfully()
        {
            var body = new List<(int x, int y)> {
                (1, 1),
                (2, 1),
                (3, 0)
            };
            var gameBoard = new GameBoardMock().StubHasFoodWith(true);
            var snake = new SnakeManager(body, 100, 100);

            var result = snake.MoveLeft(gameBoard);
            
            Assert.True(result);
            Assert.Equal(4, body.Count);
            
            Assert.Equal(0, body[0].x);
            Assert.Equal(1, body[0].y);

            Assert.Equal(1, body[1].x);
            Assert.Equal(1, body[1].y);

            Assert.Equal(2, body[2].x);
            Assert.Equal(1, body[2].y);

            Assert.Equal(3, body[3].x);
            Assert.Equal(0, body[3].y);

        }

        [Fact]
        public void MoveLeft_OutOfBounds_Sucessfully()
        {
            var body = new List<(int x, int y)> {
                (19999, 19999),
                (999, 19999),
                (9999, 9999)
            };
            var gameBoard = new GameBoardMock().StubHasFoodWith(true);
            var snake = new SnakeManager(body, 1, 1);

            var result = snake.MoveLeft(gameBoard);
            
            Assert.False(result);
            Assert.Equal(3, body.Count);
            
            Assert.Equal(19999, body[0].x);
            Assert.Equal(19999, body[0].y);

            Assert.Equal(999, body[1].x);
            Assert.Equal(19999, body[1].y);

            Assert.Equal(9999, body[2].x);
            Assert.Equal(9999, body[2].y);

        }

        [Fact] 
        public void MoveLeft_OnBody_Sucessfully()
        {
            var body = new List<(int x, int y)> {
                (3, 1),
                (2, 1),
                (1, 1)
            };
            var gameBoard = new GameBoardMock().StubHasFoodWith(true);
            var snake = new SnakeManager(body, 100, 100);

            var result = snake.MoveLeft(gameBoard);
            
            Assert.False(result);
        }

        [Fact]
        public void MoveRight_Sucessfully()
        {
            var body = new List<(int x, int y)> {
                (1, 1),
                (0, 1),
                (0, 0)
            };
            var gameBoard = new GameBoardMock().StubHasFoodWith(false);
            var snake = new SnakeManager(body, 100, 100);

            var result = snake.MoveRight(gameBoard);

            Assert.True(result);
            Assert.Equal(3, body.Count);
            
            Assert.Equal(2, body[0].x);
            Assert.Equal(1, body[0].y);

            Assert.Equal(1, body[1].x);
            Assert.Equal(1, body[1].y);

            Assert.Equal(0, body[2].x);
            Assert.Equal(1, body[2].y);

        }

        [Fact] 
        public void MoveRight_WithFood_Sucessfully()
        {
            var body = new List<(int x, int y)> {
                (1, 1),
                (0, 1),
                (0, 0)
            };
            var gameBoard = new GameBoardMock().StubHasFoodWith(true);
            var snake = new SnakeManager(body, 100, 100);

            var result = snake.MoveRight(gameBoard);
            
            Assert.True(result);
            Assert.Equal(4, body.Count);
            
            Assert.Equal(2, body[0].x);
            Assert.Equal(1, body[0].y);

            Assert.Equal(1, body[1].x);
            Assert.Equal(1, body[1].y);

            Assert.Equal(0, body[2].x);
            Assert.Equal(1, body[2].y);

            Assert.Equal(0, body[3].x);
            Assert.Equal(0, body[3].y);

        }

        [Fact] 
        public void MoveRight_OutOfBounds_Sucessfully()
        {
            var body = new List<(int x, int y)> {
                (100, 100),
                (999, 1999),
                (1000, 1000)
            };
            var gameBoard = new GameBoardMock().StubHasFoodWith(true);
            var snake = new SnakeManager(body, 1, 1);

            var result = snake.MoveRight(gameBoard);
            
            Assert.False(result);
            Assert.Equal(3, body.Count);
            
            Assert.Equal(100, body[0].x);
            Assert.Equal(100, body[0].y);

            Assert.Equal(999, body[1].x);
            Assert.Equal(1999, body[1].y);

            Assert.Equal(1000, body[2].x);
            Assert.Equal(1000, body[2].y);

        }

        [Fact] 
        public void MoveRight_OnBody_Sucessfully()
        {
            var body = new List<(int x, int y)> {
                (1, 1),
                (2, 1),
                (3, 1)
            };
            var gameBoard = new GameBoardMock().StubHasFoodWith(true);
            var snake = new SnakeManager(body, 100, 100);

            var result = snake.MoveRight(gameBoard);
            
            Assert.False(result);
        }

        [Fact]
        public void GetHeadPos_Sucessfully()
        {
            var body = new List<(int x, int y)> {
                (1, 9),
                (0, 1),
                (0, 0)
            };
            var snake = new SnakeManager(body, 100, 100);

            var result = snake.GetHeadPos();
            
            Assert.Equal(1, result.x);
            Assert.Equal(9, result.y);

        }
    }
}