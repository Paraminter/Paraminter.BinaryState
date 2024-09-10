namespace Paraminter.BinaryState.Models;

internal static class FixtureFactory
{
    public static IFixture Create()
    {
        var sut = new UnresettableBinaryStateAccessor();

        return new Fixture(sut);
    }

    private sealed class Fixture
        : IFixture
    {
        private readonly IUnresettableBinaryStateAccessor Sut;

        public Fixture(
            IUnresettableBinaryStateAccessor sut)
        {
            Sut = sut;
        }

        IUnresettableBinaryStateAccessor IFixture.Sut => Sut;
    }
}
