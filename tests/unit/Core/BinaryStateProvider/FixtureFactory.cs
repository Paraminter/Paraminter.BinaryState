namespace Paraminter.BinaryState;

using Moq;

using Paraminter.BinaryState.Models;
using Paraminter.BinaryState.Queries;
using Paraminter.Cqs.Handlers;

internal static class FixtureFactory
{
    public static IFixture Create()
    {
        Mock<IBinaryState> stateMock = new();

        var sut = new BinaryStateProvider(stateMock.Object);

        return new Fixture(sut, stateMock);
    }

    private sealed class Fixture
        : IFixture
    {
        private readonly IQueryHandler<IGetBinaryStateQuery, IBinaryState> Sut;

        private readonly Mock<IBinaryState> StateMock;

        public Fixture(
            IQueryHandler<IGetBinaryStateQuery, IBinaryState> sut,
            Mock<IBinaryState> stateMock)
        {
            Sut = sut;

            StateMock = stateMock;
        }

        IQueryHandler<IGetBinaryStateQuery, IBinaryState> IFixture.Sut => Sut;

        Mock<IBinaryState> IFixture.StateMock => StateMock;
    }
}
