namespace Paraminter.BinaryState;

using Moq;

using Paraminter.BinaryState.Models;
using Paraminter.BinaryState.Queries;
using Paraminter.Cqs.Handlers;

internal static class FixtureFactory
{
    public static IFixture Create()
    {
        Mock<IQueryHandler<IGetBinaryStateQuery, IBinaryState>> stateProviderMock = new();

        var sut = new BinaryStateResetterProvider(stateProviderMock.Object);

        return new Fixture(sut, stateProviderMock);
    }

    private sealed class Fixture
        : IFixture
    {
        private readonly IQueryHandler<IGetBinaryStateResetterQuery, IBinaryStateResetter> Sut;

        private readonly Mock<IQueryHandler<IGetBinaryStateQuery, IBinaryState>> StateProviderMock;

        public Fixture(
            IQueryHandler<IGetBinaryStateResetterQuery, IBinaryStateResetter> sut,
            Mock<IQueryHandler<IGetBinaryStateQuery, IBinaryState>> stateProviderMock)
        {
            Sut = sut;

            StateProviderMock = stateProviderMock;
        }

        IQueryHandler<IGetBinaryStateResetterQuery, IBinaryStateResetter> IFixture.Sut => Sut;

        Mock<IQueryHandler<IGetBinaryStateQuery, IBinaryState>> IFixture.StateProviderMock => StateProviderMock;
    }
}
