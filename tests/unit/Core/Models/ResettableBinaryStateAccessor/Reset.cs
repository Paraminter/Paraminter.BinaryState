namespace Paraminter.BinaryState.Models;

using Xunit;

public sealed class Reset
{
    private readonly IFixture Fixture = FixtureFactory.Create();

    [Fact]
    public void NotAlreadySet_LeavesUnset()
    {
        Target();

        Assert.False(Fixture.Sut.IsSet);
    }

    [Fact]
    public void Set_Unsets()
    {
        Fixture.Sut.Set();

        Target();

        Assert.False(Fixture.Sut.IsSet);
    }

    private void Target() => Fixture.Sut.Reset();
}
