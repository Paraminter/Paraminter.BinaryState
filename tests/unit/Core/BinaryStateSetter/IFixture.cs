namespace Paraminter.BinaryState;

using Moq;

using Paraminter.BinaryState.Commands;
using Paraminter.BinaryState.Models;
using Paraminter.Cqs;

internal interface IFixture
{
    public abstract ICommandHandler<ISetBinaryStateCommand> Sut { get; }

    public abstract Mock<IBinaryStateSetter> ModelMock { get; }
}
