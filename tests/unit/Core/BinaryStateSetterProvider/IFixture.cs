namespace Paraminter.BinaryState;

using Moq;

using Paraminter.BinaryState.Models;
using Paraminter.BinaryState.Queries;
using Paraminter.Cqs;

internal interface IFixture
{
    public abstract IQueryHandler<IGetBinaryStateSetterQuery, IBinaryStateSetter> Sut { get; }

    public abstract Mock<IBinaryStateSetter> StateSetterMock { get; }
}
