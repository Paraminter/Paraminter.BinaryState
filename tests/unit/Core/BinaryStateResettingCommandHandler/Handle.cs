namespace Paraminter.BinaryState;

using Moq;

using Paraminter.BinaryState.Commands;
using Paraminter.Cqs;

using System;
using System.Threading;

using Xunit;

public sealed class Handle
{
    [Fact]
    public void NullCommand_ThrowsArgumentNullException()
    {
        var fixture = FixtureFactory.Create<ICommand>();

        var result = Record.Exception(() => Target(fixture, null!, CancellationToken.None));

        Assert.IsType<ArgumentNullException>(result);
    }

    [Fact]
    public void ValidCommand_ResetsState()
    {
        var fixture = FixtureFactory.Create<ICommand>();

        Target(fixture, Mock.Of<ICommand>(), CancellationToken.None);

        fixture.StateResetterMock.Verify(static (handler) => handler.Handle(It.IsAny<IResetBinaryStateCommand>(), It.IsAny<CancellationToken>()), Times.Once());
    }

    private static void Target<TCommand>(
        IFixture<TCommand> fixture,
        TCommand command,
        CancellationToken cancellationToken)
        where TCommand : ICommand
    {
        fixture.Sut.Handle(command, cancellationToken);
    }
}
