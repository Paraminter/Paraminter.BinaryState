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
    public void ValidArguments_Sets()
    {
        Mock<IBinaryStateSetter> stateSetterMock = new();

        Fixture.StateSetterProviderMock.Setup(static (handler) => handler.Handle(It.IsAny<IGetBinaryStateSetterQuery>())).Returns(stateSetterMock.Object);

        Target(Mock.Of<ISetBinaryStateCommand>());

        stateSetterMock.Verify(static (setter) => setter.Set(), Times.Once);
    }

    private void Target(
        ISetBinaryStateCommand command)
    {
        Fixture.Sut.Handle(command);
    }
}
