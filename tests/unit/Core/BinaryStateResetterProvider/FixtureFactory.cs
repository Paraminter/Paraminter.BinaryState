namespace Paraminter.BinaryState;

using Moq;

using Paraminter.BinaryState.Models;
using Paraminter.BinaryState.Queries;
using Paraminter.Cqs;

internal static class FixtureFactory
{
    public static IFixture Create()
    {
        Mock<IBinaryStateResetter> stateResetterMock = new();

        var sut = new BinaryStateResetterProvider(stateResetterMock.Object);

        return new Fixture(sut, stateResetterMock);
    }

    private sealed class Fixture
        : IFixture
    {
        private readonly IQueryHandler<IGetBinaryStateResetterQuery, IBinaryStateResetter> Sut;

        private readonly Mock<IBinaryStateResetter> StateResetterMock;

        public Fixture(
            IQueryHandler<IGetBinaryStateResetterQuery, IBinaryStateResetter> sut,
            Mock<IBinaryStateResetter> stateResetterMock)
        {
            Sut = sut;

            StateResetterMock = stateResetterMock;
        }

        IQueryHandler<IGetBinaryStateResetterQuery, IBinaryStateResetter> IFixture.Sut => Sut;

        Mock<IBinaryStateResetter> IFixture.StateResetterMock => StateResetterMock;
    }
}
