namespace Paraminter.BinaryState.Models;

using Xunit;

public sealed class Reader
{
    private readonly IFixture Fixture = FixtureFactory.Create();

    [Fact]
    public void ReturnsReader()
    {
        var result = Target();

        Assert.NotNull(result);
    }

    private IBinaryStateReader Target() => Fixture.Sut.Reader;
}
