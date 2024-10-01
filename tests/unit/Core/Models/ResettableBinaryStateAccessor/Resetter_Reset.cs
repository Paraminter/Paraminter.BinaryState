namespace Paraminter.BinaryState.Models;

using Xunit;

public sealed class Resetter_Reset
{
    private readonly IFixture Fixture = FixtureFactory.Create();

    [Fact]
    public void NotAlreadySet_LeavesUnset()
    {
        Target();

        Assert.False(Fixture.Sut.Reader.IsSet);
    }

    [Fact]
    public void Set_Unsets()
    {
        Fixture.Sut.Setter.Set();

        Target();

        Assert.False(Fixture.Sut.Reader.IsSet);
    }

    private void Target() => Fixture.Sut.Resetter.Reset();
}
