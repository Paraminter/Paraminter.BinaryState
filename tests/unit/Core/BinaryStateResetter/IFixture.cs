namespace Paraminter.BinaryState;

using Moq;

using Paraminter.BinaryState.Commands;
using Paraminter.BinaryState.Models;
using Paraminter.BinaryState.Queries;
using Paraminter.Cqs.Handlers;

internal interface IFixture
{
    public abstract ICommandHandler<IResetBinaryStateCommand> Sut { get; }

    public abstract Mock<IQueryHandler<IGetBinaryStateResetterQuery, IBinaryStateResetter>> StateResetterProviderMock { get; }
}
