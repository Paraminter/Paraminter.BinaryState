namespace Paraminter.BinaryState;

using Moq;

using Paraminter.BinaryState.Commands;
using Paraminter.BinaryState.Models;
using Paraminter.Cqs;

internal static class FixtureFactory
{
    public static IFixture Create()
    {
        Mock<IBinaryStateResetter> modelMock = new();

        var sut = new BinaryStateResetter(modelMock.Object);

        return new Fixture(sut, modelMock);
    }

    private sealed class Fixture
        : IFixture
    {
        private readonly ICommandHandler<IResetBinaryStateCommand> Sut;

        private readonly Mock<IBinaryStateResetter> ModelMock;

        public Fixture(
            ICommandHandler<IResetBinaryStateCommand> sut,
            Mock<IBinaryStateResetter> modelMock)
        {
            Sut = sut;

            ModelMock = modelMock;
        }

        ICommandHandler<IResetBinaryStateCommand> IFixture.Sut => Sut;

        Mock<IBinaryStateResetter> IFixture.ModelMock => ModelMock;
    }
}
