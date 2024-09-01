namespace Paraminter.BinaryState.Models;

internal static class FixtureFactory
{
    public static IFixture Create()
    {
        var sut = new BinaryState();

        return new Fixture(sut);
    }

    private sealed class Fixture
        : IFixture
    {
        private readonly IBinaryState Sut;

        public Fixture(
            IBinaryState sut)
        {
            Sut = sut;
        }

        IBinaryState IFixture.Sut => Sut;
    }
}
