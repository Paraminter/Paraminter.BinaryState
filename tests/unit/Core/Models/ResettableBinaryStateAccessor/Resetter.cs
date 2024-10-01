namespace Paraminter.BinaryState.Models;

using Xunit;

public sealed class Resetter
{
    private readonly IFixture Fixture = FixtureFactory.Create();

    [Fact]
    public void ReturnsResetter()
    {
        var result = Target();

        Assert.NotNull(result);
    }

    private IBinaryStateResetter Target() => Fixture.Sut.Resetter;
}
