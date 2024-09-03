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
        Mock<ICommandHandler<ISetBinaryStateCommand>> stateSetterMock = new();

        var sut = new BinaryStateSettingCommandHandler<TCommand>(stateSetterMock.Object);

        return new Fixture<TCommand>(sut, stateSetterMock);
    }

    private sealed class Fixture<TCommand>
        : IFixture<TCommand>
        where TCommand : ICommand
    {
        private readonly ICommandHandler<TCommand> Sut;

        private readonly Mock<ICommandHandler<ISetBinaryStateCommand>> StateSetterMock;

        public Fixture(
            ICommandHandler<TCommand> sut,
            Mock<ICommandHandler<ISetBinaryStateCommand>> stateSetterMock)
        {
            Sut = sut;

            StateSetterMock = stateSetterMock;
        }

        ICommandHandler<TCommand> IFixture<TCommand>.Sut => Sut;

        Mock<ICommandHandler<ISetBinaryStateCommand>> IFixture<TCommand>.StateSetterMock => StateSetterMock;
    }
}
