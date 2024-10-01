namespace Paraminter.BinaryState.Models;

using Xunit;

public sealed class Setter
{
    private readonly IFixture Fixture = FixtureFactory.Create();

    [Fact]
    public void ReturnsSetter()
    {
        var result = Target();

        Assert.NotNull(result);
    }

    private IBinaryStateSetter Target() => Fixture.Sut.Setter;
}
