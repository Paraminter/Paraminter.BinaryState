namespace Paraminter.BinaryState;

using Moq;

using Paraminter.BinaryState.Models;
using Paraminter.BinaryState.Queries;
using Paraminter.Cqs;

internal interface IFixture
{
    public abstract IQueryHandler<IGetBinaryStateResetterQuery, IBinaryStateResetter> Sut { get; }

    public abstract Mock<IBinaryStateResetter> StateResetterMock { get; }
}
