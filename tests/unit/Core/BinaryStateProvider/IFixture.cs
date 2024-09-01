namespace Paraminter.BinaryState;

using Moq;

using Paraminter.BinaryState.Models;
using Paraminter.BinaryState.Queries;
using Paraminter.Cqs.Handlers;

internal interface IFixture
{
    public abstract IQueryHandler<IGetBinaryStateQuery, IBinaryState> Sut { get; }

    public abstract Mock<IBinaryState> StateMock { get; }
}
