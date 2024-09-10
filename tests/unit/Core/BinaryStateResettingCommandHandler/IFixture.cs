namespace Paraminter.BinaryState;

using Moq;

using Paraminter.BinaryState.Commands;
using Paraminter.Cqs;

internal interface IFixture<in TCommand>
    where TCommand : ICommand
{
    public abstract ICommandHandler<TCommand> Sut { get; }

    public abstract Mock<ICommandHandler<IResetBinaryStateCommand>> StateResetterMock { get; }
}
