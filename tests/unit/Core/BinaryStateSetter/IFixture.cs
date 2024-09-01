namespace Paraminter.BinaryState;

using Moq;

using Paraminter.BinaryState.Commands;
using Paraminter.BinaryState.Models;
using Paraminter.BinaryState.Queries;
using Paraminter.Cqs.Handlers;

internal interface IFixture
{
    public abstract ICommandHandler<ISetBinaryStateCommand> Sut { get; }

    public abstract Mock<IQueryHandler<IGetBinaryStateSetterQuery, IBinaryStateSetter>> StateSetterProviderMock { get; }
}
