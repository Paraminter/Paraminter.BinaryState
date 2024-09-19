namespace Paraminter.BinaryState;

using Moq;

using Paraminter.BinaryState.Commands;
using Paraminter.BinaryState.Models;
using Paraminter.Cqs;

internal static class FixtureFactory
{
    public static IFixture Create()
    {
        Mock<IBinaryStateSetter> modelMock = new();

        var sut = new BinaryStateSetter(modelMock.Object);

        return new Fixture(sut, modelMock);
    }

    private sealed class Fixture
        : IFixture
    {
        private readonly ICommandHandler<ISetBinaryStateCommand> Sut;

        private readonly Mock<IBinaryStateSetter> ModelMock;

        public Fixture(
            ICommandHandler<ISetBinaryStateCommand> sut,
            Mock<IBinaryStateSetter> modelMock)
        {
            Sut = sut;

            ModelMock = modelMock;
        }

        ICommandHandler<ISetBinaryStateCommand> IFixture.Sut => Sut;

        Mock<IBinaryStateSetter> IFixture.ModelMock => ModelMock;
    }
}
