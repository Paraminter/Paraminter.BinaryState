namespace Paraminter.BinaryState;

using Moq;

using Paraminter.BinaryState.Commands;
using Paraminter.Cqs;
using Paraminter.Cqs.Handlers;

internal static class FixtureFactory
{
    public static IFixture<TCommand> Create<TCommand>()
        where TCommand : ICommand
    {
        Mock<ICommandHandler<IResetBinaryStateCommand>> stateResetterMock = new();

        var sut = new BinaryStateResettingCommandHandler<TCommand>(stateResetterMock.Object);

        return new Fixture<TCommand>(sut, stateResetterMock);
    }

    private sealed class Fixture<TCommand>
        : IFixture<TCommand>
        where TCommand : ICommand
    {
        private readonly ICommandHandler<TCommand> Sut;

        private readonly Mock<ICommandHandler<IResetBinaryStateCommand>> StateResetterMock;

        public Fixture(
            ICommandHandler<TCommand> sut,
            Mock<ICommandHandler<IResetBinaryStateCommand>> stateResetterMock)
        {
            Sut = sut;

            StateResetterMock = stateResetterMock;
        }

        ICommandHandler<TCommand> IFixture<TCommand>.Sut => Sut;

        Mock<ICommandHandler<IResetBinaryStateCommand>> IFixture<TCommand>.StateResetterMock => StateResetterMock;
    }
}
