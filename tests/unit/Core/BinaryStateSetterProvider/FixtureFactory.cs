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

        var sut = new BinaryStateSetterProvider(stateProviderMock.Object);

        return new Fixture(sut, stateProviderMock);
    }

    private sealed class Fixture
        : IFixture
    {
        private readonly IQueryHandler<IGetBinaryStateSetterQuery, IBinaryStateSetter> Sut;

        private readonly Mock<IQueryHandler<IGetBinaryStateQuery, IBinaryState>> StateProviderMock;

        public Fixture(
            IQueryHandler<IGetBinaryStateSetterQuery, IBinaryStateSetter> sut,
            Mock<IQueryHandler<IGetBinaryStateQuery, IBinaryState>> stateProviderMock)
        {
            Sut = sut;

            StateProviderMock = stateProviderMock;
        }

        IQueryHandler<IGetBinaryStateSetterQuery, IBinaryStateSetter> IFixture.Sut => Sut;

        Mock<IQueryHandler<IGetBinaryStateQuery, IBinaryState>> IFixture.StateProviderMock => StateProviderMock;
    }
}
