using dnew.rolls;
using Moq;

namespace dnew.test.mocks {
    public class DiceRollMock : IDiceRoll
    {
        private Mock<IDiceRoll> _dice = new Mock<IDiceRoll>(); 

        public int Roll(int maxRoll)
        {
            return _dice.Object.Roll(maxRoll);
        }

        public DiceRollMock StubRollsWith(List<int> rolls) {
            var setup = _dice.SetupSequence(x => x.Roll(It.IsAny<int>()));
            foreach(var roll in rolls) {
               setup.Returns(roll);
            }
            return this;
        }
    }
}