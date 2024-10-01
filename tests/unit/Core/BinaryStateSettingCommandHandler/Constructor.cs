namespace Paraminter.BinaryState;

using Moq;

using Paraminter.BinaryState.Commands;
using Paraminter.Cqs;

using System;

using Xunit;

public sealed class Constructor
{
    [Fact]
    public void NullStateSetter_ThrowsArgumentNullException()
    {
        var result = Record.Exception(() => Target<ICommand>(null!));

        Assert.IsType<ArgumentNullException>(result);
    }

    [Fact]
    public void ValidArguments_ReturnsHandler()
    {
        var result = Target<ICommand>(Mock.Of<ICommandHandler<ISetBinaryStateCommand>>());

        Assert.NotNull(result);
    }

    private static BinaryStateSettingCommandHandler<TCommand> Target<TCommand>(
        ICommandHandler<ISetBinaryStateCommand> stateSetter)
        where TCommand : ICommand
    {
        return new BinaryStateSettingCommandHandler<TCommand>(stateSetter);
    }
}
