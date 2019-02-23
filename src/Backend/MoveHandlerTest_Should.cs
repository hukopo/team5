using FluentAssertions;
using NUnit.Framework;
using thegame.backend;

namespace thegame.Backend
{
    [TestFixture]
    public class MoveHandlerTest_Should
    {
        [Test]
        public void TestMoveRight()
        {
            int[,] field =
            {
                {1, 0, 1},
                {0, 0, 0},
                {2, 2, 2}
            };

            MoveHandler.MoveRowRight(field, 0);
            field.Should().BeEquivalentTo(new[,]
            {
                {0, 0, 2},
                {0, 0, 0},
                {2, 2, 2}
            });
        }
    }
}
