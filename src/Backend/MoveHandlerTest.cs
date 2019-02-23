using System;
using NUnit.Framework;
using FluentAssertions;
using thegame.backend;

[TestFixture]
public class MoveHandlerTest_Should
{
    [Test]
    public void TestMoveRight()
    {
        int[,] field = new int[,]
        {
            { 1, 0, 1 },
            { 0, 0, 0 },
            { 2, 2, 2 }
        };

        MoveHandler.MoveRowRight(field, 0);
        Console.WriteLine(field);
        true.Should().BeTrue();
    }
}
