namespace Paraminter.BinaryState;

using Moq;

using Paraminter.BinaryState.Commands;

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
        Target(Mock.Of<IResetBinaryStateCommand>());

        Fixture.ModelMock.Verify(static (model) => model.Reset(), Times.Once);
    }

    private void Target(
        IResetBinaryStateCommand command)
    {
        Fixture.Sut.Handle(command);
    }
}
