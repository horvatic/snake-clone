using dnew.board;

namespace dnew.test.board {
    public class GameBoardTest {
        [Fact]
        public void Add_Food_Sucessfully()
        {
            var boardMem = new List<List<bool>>() {
                new List<bool> { false, false, false },
                new List<bool> { false, false, false },
                new List<bool> { false, false, false }
            };
            var board = new GameBoard(boardMem);
            
            board.AddFood(1,1);

            Assert.True(boardMem[1][1]);
        }

        [Fact]
        public void Remove_Food_Sucessfully()
        {
            var boardMem = new List<List<bool>>() {
                new List<bool> { false, false, false },
                new List<bool> { false, true, false },
                new List<bool> { false, false, false }
            };
            var board = new GameBoard(boardMem);
            
            board.RemoveFood(1,1);

            Assert.False(boardMem[1][1]);
        }

        [Fact]
        public void Has_Food_Sucessfully()
        {
            var boardMem = new List<List<bool>>() {
                new List<bool> { false, false, false },
                new List<bool> { false, true, false },
                new List<bool> { false, false, false }
            };
            var board = new GameBoard(boardMem);

            Assert.True(board.HasFood(1,1));
            Assert.False(board.HasFood(0,1));
        }

        [Fact]
        public void Have_Board_Food_Sucessfully()
        {
            var boardMem = new List<List<bool>>() {
                new List<bool> { false, false, false },
                new List<bool> { false, true, false },
                new List<bool> { false, false, false }
            };
            var board = new GameBoard(boardMem);

            Assert.True(board.DoesBoardHaveFood());
        }

        [Fact]
        public void Have_Board_No_Food_Sucessfully()
        {
            var boardMem = new List<List<bool>>() {
                new List<bool> { false, false, false },
                new List<bool> { false, false, false },
                new List<bool> { false, false, false }
            };
            var board = new GameBoard(boardMem);

            Assert.False(board.DoesBoardHaveFood());
        }
    }
}