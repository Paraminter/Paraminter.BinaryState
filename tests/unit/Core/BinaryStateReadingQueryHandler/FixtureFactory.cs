namespace Paraminter.BinaryState;

using Moq;

using Paraminter.BinaryState.Queries;
using Paraminter.Cqs;
using Paraminter.Cqs.Handlers;

internal static class FixtureFactory
{
    public static IFixture<TQuery> Create<TQuery>()
        where TQuery : IQuery
    {
        Mock<IQueryHandler<IIsBinaryStateSetQuery, bool>> stateReaderMock = new();

        var sut = new BinaryStateReadingQueryHandler<TQuery>(stateReaderMock.Object);

        return new Fixture<TQuery>(sut, stateReaderMock);
    }

    private sealed class Fixture<TQuery>
        : IFixture<TQuery>
        where TQuery : IQuery
    {
        private readonly IQueryHandler<TQuery, bool> Sut;

        private readonly Mock<IQueryHandler<IIsBinaryStateSetQuery, bool>> StateReaderMock;

        public Fixture(
            IQueryHandler<TQuery, bool> sut,
            Mock<IQueryHandler<IIsBinaryStateSetQuery, bool>> stateReaderMock)
        {
            Sut = sut;

            StateReaderMock = stateReaderMock;
        }

        IQueryHandler<TQuery, bool> IFixture<TQuery>.Sut => Sut;

        Mock<IQueryHandler<IIsBinaryStateSetQuery, bool>> IFixture<TQuery>.StateReaderMock => StateReaderMock;
    }
}
