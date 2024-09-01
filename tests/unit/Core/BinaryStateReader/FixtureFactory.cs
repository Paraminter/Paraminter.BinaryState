namespace Paraminter.BinaryState;

using Moq;

using Paraminter.BinaryState.Models;
using Paraminter.BinaryState.Queries;
using Paraminter.Cqs.Handlers;

internal static class FixtureFactory
{
    public static IFixture Create()
    {
        Mock<IQueryHandler<IGetBinaryStateReaderQuery, IBinaryStateReader>> stateReaderProviderMock = new();

        var sut = new BinaryStateReader(stateReaderProviderMock.Object);

        return new Fixture(sut, stateReaderProviderMock);
    }

    private sealed class Fixture
        : IFixture
    {
        private readonly IQueryHandler<IIsBinaryStateSetQuery, bool> Sut;

        private readonly Mock<IQueryHandler<IGetBinaryStateReaderQuery, IBinaryStateReader>> StateReaderProviderMock;

        public Fixture(
            IQueryHandler<IIsBinaryStateSetQuery, bool> sut,
            Mock<IQueryHandler<IGetBinaryStateReaderQuery, IBinaryStateReader>> stateReaderProviderMock)
        {
            Sut = sut;

            StateReaderProviderMock = stateReaderProviderMock;
        }

        IQueryHandler<IIsBinaryStateSetQuery, bool> IFixture.Sut => Sut;

        Mock<IQueryHandler<IGetBinaryStateReaderQuery, IBinaryStateReader>> IFixture.StateReaderProviderMock => StateReaderProviderMock;
    }
}
