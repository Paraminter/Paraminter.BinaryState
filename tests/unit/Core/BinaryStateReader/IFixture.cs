namespace Paraminter.BinaryState;

using Moq;

using Paraminter.BinaryState.Models;
using Paraminter.BinaryState.Queries;
using Paraminter.Cqs.Handlers;

internal interface IFixture
{
    public abstract IQueryHandler<IIsBinaryStateSetQuery, bool> Sut { get; }

    public abstract Mock<IQueryHandler<IGetBinaryStateReaderQuery, IBinaryStateReader>> StateReaderProviderMock { get; }
}
