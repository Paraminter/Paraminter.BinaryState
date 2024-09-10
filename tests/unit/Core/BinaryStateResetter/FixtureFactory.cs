namespace Paraminter.BinaryState;

using Moq;

using Paraminter.BinaryState.Commands;
using Paraminter.BinaryState.Models;
using Paraminter.BinaryState.Queries;
using Paraminter.Cqs;

internal static class FixtureFactory
{
    public static IFixture Create()
    {
        Mock<IQueryHandler<IGetBinaryStateResetterQuery, IBinaryStateResetter>> stateResetterProviderMock = new();

        var sut = new BinaryStateResetter(stateResetterProviderMock.Object);

        return new Fixture(sut, stateResetterProviderMock);
    }

    private sealed class Fixture
        : IFixture
    {
        private readonly ICommandHandler<IResetBinaryStateCommand> Sut;

        private readonly Mock<IQueryHandler<IGetBinaryStateResetterQuery, IBinaryStateResetter>> StateResetterProviderMock;

        public Fixture(
            ICommandHandler<IResetBinaryStateCommand> sut,
            Mock<IQueryHandler<IGetBinaryStateResetterQuery, IBinaryStateResetter>> stateResetterProviderMock)
        {
            Sut = sut;

            StateResetterProviderMock = stateResetterProviderMock;
        }

        ICommandHandler<IResetBinaryStateCommand> IFixture.Sut => Sut;

        Mock<IQueryHandler<IGetBinaryStateResetterQuery, IBinaryStateResetter>> IFixture.StateResetterProviderMock => StateResetterProviderMock;
    }
}
