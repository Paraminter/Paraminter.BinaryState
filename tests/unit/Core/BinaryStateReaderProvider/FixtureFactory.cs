namespace Paraminter.BinaryState;

using Moq;

using Paraminter.BinaryState.Models;
using Paraminter.BinaryState.Queries;
using Paraminter.Cqs;

internal static class FixtureFactory
{
    public static IFixture Create()
    {
        Mock<IBinaryStateReader> stateReaderMock = new();

        var sut = new BinaryStateReaderProvider(stateReaderMock.Object);

        return new Fixture(sut, stateReaderMock);
    }

    private sealed class Fixture
        : IFixture
    {
        private readonly IQueryHandler<IGetBinaryStateReaderQuery, IBinaryStateReader> Sut;

        private readonly Mock<IBinaryStateReader> StateReaderMock;

        public Fixture(
            IQueryHandler<IGetBinaryStateReaderQuery, IBinaryStateReader> sut,
            Mock<IBinaryStateReader> stateReaderMock)
        {
            Sut = sut;

            StateReaderMock = stateReaderMock;
        }

        IQueryHandler<IGetBinaryStateReaderQuery, IBinaryStateReader> IFixture.Sut => Sut;

        Mock<IBinaryStateReader> IFixture.StateReaderMock => StateReaderMock;
    }
}
