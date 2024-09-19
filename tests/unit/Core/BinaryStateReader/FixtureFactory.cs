namespace Paraminter.BinaryState;

using Moq;

using Paraminter.BinaryState.Models;
using Paraminter.BinaryState.Queries;
using Paraminter.Cqs;

internal static class FixtureFactory
{
    public static IFixture Create()
    {
        Mock<IBinaryStateReader> modelMock = new();

        var sut = new BinaryStateReader(modelMock.Object);

        return new Fixture(sut, modelMock);
    }

    private sealed class Fixture
        : IFixture
    {
        private readonly IQueryHandler<IIsBinaryStateSetQuery, bool> Sut;

        private readonly Mock<IBinaryStateReader> ModelMock;

        public Fixture(
            IQueryHandler<IIsBinaryStateSetQuery, bool> sut,
            Mock<IBinaryStateReader> modelMock)
        {
            Sut = sut;

            ModelMock = modelMock;
        }

        IQueryHandler<IIsBinaryStateSetQuery, bool> IFixture.Sut => Sut;

        Mock<IBinaryStateReader> IFixture.ModelMock => ModelMock;
    }
}
