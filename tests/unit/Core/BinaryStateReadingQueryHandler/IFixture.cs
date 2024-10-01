namespace Paraminter.BinaryState;

using Moq;

using Paraminter.BinaryState.Queries;
using Paraminter.Cqs;

internal interface IFixture<in TQuery, TResponse>
    where TQuery : IQuery
{
    public abstract IQueryHandler<TQuery, TResponse> Sut { get; }

    public abstract Mock<IQueryHandler<IIsBinaryStateSetQuery, TResponse>> StateReaderMock { get; }
}
