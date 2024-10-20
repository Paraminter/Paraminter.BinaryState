namespace Paraminter.BinaryState;

using Moq;

using Paraminter.BinaryState.Commands;
using Paraminter.Cqs;

using System;
using System.Threading;
using System.Threading.Tasks;

using Xunit;

public sealed class Handle
{
    [Fact]
    public async Task NullCommand_ThrowsArgumentNullException()
    {
        var fixture = FixtureFactory.Create<ICommand>();

        var result = await Record.ExceptionAsync(() => Target(fixture, null!, CancellationToken.None));

        Assert.IsType<ArgumentNullException>(result);
    }

    [Fact]
    public async Task ValidCommand_SetsState()
    {
        var fixture = FixtureFactory.Create<ICommand>();

        await Target(fixture, Mock.Of<ICommand>(), CancellationToken.None);

        fixture.StateSetterMock.Verify(static (handler) => handler.Handle(It.IsAny<ISetBinaryStateCommand>(), It.IsAny<CancellationToken>()), Times.Once());
    }

    private static async Task Target<TCommand>(
        IFixture<TCommand> fixture,
        TCommand command,
        CancellationToken cancellationToken)
        where TCommand : ICommand
    {
        await fixture.Sut.Handle(command, cancellationToken);
    }
}
