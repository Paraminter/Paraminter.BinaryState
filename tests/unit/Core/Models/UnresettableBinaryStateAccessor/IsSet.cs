namespace Paraminter.BinaryState.Models;

using Xunit;

public sealed class IsSet
{
    private readonly IFixture Fixture = FixtureFactory.Create();

    [Fact]
    public void NotSet_ReturnsFalse()
    {
        var result = Target();

        Assert.False(result);
    }

    [Fact]
    public void Set_ReturnsTrue()
    {
        Fixture.Sut.Set();

        var result = Target();

        Assert.True(result);
    }

    private bool Target() => Fixture.Sut.IsSet;
}
