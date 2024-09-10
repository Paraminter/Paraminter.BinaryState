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
        Mock<IQueryHandler<IGetBinaryStateSetterQuery, IBinaryStateSetter>> stateSetterProviderMock = new();

        var sut = new BinaryStateSetter(stateSetterProviderMock.Object);

        return new Fixture(sut, stateSetterProviderMock);
    }

    private sealed class Fixture
        : IFixture
    {
        private readonly ICommandHandler<ISetBinaryStateCommand> Sut;

        private readonly Mock<IQueryHandler<IGetBinaryStateSetterQuery, IBinaryStateSetter>> StateSetterProviderMock;

        public Fixture(
            ICommandHandler<ISetBinaryStateCommand> sut,
            Mock<IQueryHandler<IGetBinaryStateSetterQuery, IBinaryStateSetter>> stateSetterProviderMock)
        {
            Sut = sut;

            StateSetterProviderMock = stateSetterProviderMock;
        }

        ICommandHandler<ISetBinaryStateCommand> IFixture.Sut => Sut;

        Mock<IQueryHandler<IGetBinaryStateSetterQuery, IBinaryStateSetter>> IFixture.StateSetterProviderMock => StateSetterProviderMock;
    }
}
