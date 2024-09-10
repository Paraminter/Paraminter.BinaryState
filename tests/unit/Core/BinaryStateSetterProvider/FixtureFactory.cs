namespace Paraminter.BinaryState;

using Moq;

using Paraminter.BinaryState.Models;
using Paraminter.BinaryState.Queries;
using Paraminter.Cqs;

internal static class FixtureFactory
{
    public static IFixture Create()
    {
        Mock<IBinaryStateSetter> stateSetterMock = new();

        var sut = new BinaryStateSetterProvider(stateSetterMock.Object);

        return new Fixture(sut, stateSetterMock);
    }

    private sealed class Fixture
        : IFixture
    {
        private readonly IQueryHandler<IGetBinaryStateSetterQuery, IBinaryStateSetter> Sut;

        private readonly Mock<IBinaryStateSetter> StateSetterMock;

        public Fixture(
            IQueryHandler<IGetBinaryStateSetterQuery, IBinaryStateSetter> sut,
            Mock<IBinaryStateSetter> stateSetterMock)
        {
            Sut = sut;

            StateSetterMock = stateSetterMock;
        }

        IQueryHandler<IGetBinaryStateSetterQuery, IBinaryStateSetter> IFixture.Sut => Sut;

        Mock<IBinaryStateSetter> IFixture.StateSetterMock => StateSetterMock;
    }
}
