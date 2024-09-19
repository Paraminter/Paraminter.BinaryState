namespace Paraminter.BinaryState;

using Moq;

using Paraminter.BinaryState.Models;
using Paraminter.BinaryState.Queries;
using Paraminter.Cqs;

internal interface IFixture
{
    public abstract IQueryHandler<IIsBinaryStateSetQuery, bool> Sut { get; }

    public abstract Mock<IBinaryStateReader> ModelMock { get; }
}
