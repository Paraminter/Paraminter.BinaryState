namespace Paraminter.BinaryState.Models;

internal static class FixtureFactory
{
    public static IFixture Create()
    {
        var sut = new ResettableBinaryStateAccessor();

        return new Fixture(sut);
    }

    private sealed class Fixture
        : IFixture
    {
        private readonly IResettableBinaryStateAccessor Sut;

        public Fixture(
            IResettableBinaryStateAccessor sut)
        {
            Sut = sut;
        }

        IResettableBinaryStateAccessor IFixture.Sut => Sut;
    }
}
