namespace Paraminter.BinaryState;

using Moq;

using Paraminter.BinaryState.Queries;
using Paraminter.Cqs;

internal static class FixtureFactory
{
    public static IFixture<TQuery, TResponse> Create<TQuery, TResponse>()
        where TQuery : IQuery
    {
        Mock<IQueryHandler<IIsBinaryStateSetQuery, TResponse>> stateReaderMock = new();

        var sut = new BinaryStateReadingQueryHandler<TQuery, TResponse>(stateReaderMock.Object);

        return new Fixture<TQuery, TResponse>(sut, stateReaderMock);
    }

    private sealed class Fixture<TQuery, TResponse>
        : IFixture<TQuery, TResponse>
        where TQuery : IQuery
    {
        private readonly IQueryHandler<TQuery, TResponse> Sut;

        private readonly Mock<IQueryHandler<IIsBinaryStateSetQuery, TResponse>> StateReaderMock;

        public Fixture(
            IQueryHandler<TQuery, TResponse> sut,
            Mock<IQueryHandler<IIsBinaryStateSetQuery, TResponse>> stateReaderMock)
        {
            Sut = sut;

            StateReaderMock = stateReaderMock;
        }

        IQueryHandler<TQuery, TResponse> IFixture<TQuery, TResponse>.Sut => Sut;

        Mock<IQueryHandler<IIsBinaryStateSetQuery, TResponse>> IFixture<TQuery, TResponse>.StateReaderMock => StateReaderMock;
    }
}
