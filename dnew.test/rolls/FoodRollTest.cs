using dnew.rolls;
using dnew.test.mocks;

namespace dnew.test.rolls
{
    public class FoodRollTest
    {
        [Fact]
        public void Roll_Food_Sucessfully()
        {
            var stubRolls = new List<int>() {
                4, 50
            };
            var diceRollMock = new DiceRollMock().StubRollsWith(stubRolls);
            var snakeMock = new SnakeMock().StubIsBodyPos(new List<bool>() {false});
            var foodRoll = new FoodRoll(diceRollMock, 64);

            var result = foodRoll.Roll(snakeMock);

            snakeMock.AssertSnakeIsBodyPosWasCalledWith(4, 50);
            Assert.Equal(4, result.x);
            Assert.Equal(50, result.y);
        }

        [Fact]
        public void Roll_Food_RetryThreeTimes_Sucessfully()
        {
            var stubRolls = new List<int>() {
                4, 50,
                60, 3,
                3, 10
            };
            var diceRollMock = new DiceRollMock().StubRollsWith(stubRolls);
            var snakeMock = new SnakeMock().StubIsBodyPos(new List<bool>() {true, true, false});
            var foodRoll = new FoodRoll(diceRollMock, 64);

            var result = foodRoll.Roll(snakeMock);

            snakeMock.AssertSnakeIsBodyPosWasCalledWith(4, 50);
            snakeMock.AssertSnakeIsBodyPosWasCalledWith(60, 3);
            snakeMock.AssertSnakeIsBodyPosWasCalledWith(3, 10);
            Assert.Equal(3, result.x);
            Assert.Equal(10, result.y);
        }
    }
}