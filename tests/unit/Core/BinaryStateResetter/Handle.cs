namespace Paraminter.BinaryState;

using Moq;

using Paraminter.BinaryState.Commands;
using Paraminter.BinaryState.Models;
using Paraminter.BinaryState.Queries;

using System;

using Xunit;

public sealed class Handle
{
    private readonly IFixture Fixture = FixtureFactory.Create();

    [Fact]
    public void NullCommand_ThrowsArgumentNullException()
    {
        var result = Record.Exception(() => Target(null!));

        Assert.IsType<ArgumentNullException>(result);
    }

    [Fact]
    public void ValidArguments_Resets()
    {
        Mock<IBinaryStateResetter> stateResetterMock = new();

        Fixture.StateResetterProviderMock.Setup(static (handler) => handler.Handle(It.IsAny<IGetBinaryStateResetterQuery>())).Returns(stateResetterMock.Object);

        Target(Mock.Of<IResetBinaryStateCommand>());

        stateResetterMock.Verify(static (resetter) => resetter.Reset(), Times.Once);
    }

    private void Target(
        IResetBinaryStateCommand command)
    {
        Fixture.Sut.Handle(command);
    }
}
