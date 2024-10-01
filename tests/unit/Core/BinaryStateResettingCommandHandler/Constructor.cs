namespace Paraminter.BinaryState;

using Moq;

using Paraminter.BinaryState.Commands;
using Paraminter.Cqs;

using System;

using Xunit;

public sealed class Constructor
{
    [Fact]
    public void NullStateResetter_ThrowsArgumentNullException()
    {
        var result = Record.Exception(() => Target<ICommand>(null!));

        Assert.IsType<ArgumentNullException>(result);
    }

    [Fact]
    public void ValidArguments_ReturnsHandler()
    {
        var result = Target<ICommand>(Mock.Of<ICommandHandler<IResetBinaryStateCommand>>());

        Assert.NotNull(result);
    }

    private static BinaryStateResettingCommandHandler<TCommand> Target<TCommand>(
        ICommandHandler<IResetBinaryStateCommand> stateResetter)
        where TCommand : ICommand
    {
        return new BinaryStateResettingCommandHandler<TCommand>(stateResetter);
    }
}
