namespace Paraminter.BinaryState;

using Moq;

using Paraminter.BinaryState.Models;
using Paraminter.BinaryState.Queries;
using Paraminter.Cqs.Handlers;

internal interface IFixture
{
    public abstract IQueryHandler<IGetBinaryStateReaderQuery, IBinaryStateReader> Sut { get; }

    public abstract Mock<IQueryHandler<IGetBinaryStateQuery, IBinaryState>> StateProviderMock { get; }
}
