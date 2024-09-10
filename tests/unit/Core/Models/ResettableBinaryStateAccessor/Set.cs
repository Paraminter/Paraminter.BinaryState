namespace Paraminter.BinaryState.Models;

using Xunit;

public sealed class Set
{
    private readonly IFixture Fixture = FixtureFactory.Create();

    [Fact]
    public void NotAlreadySet_Sets()
    {
        Target();

        Assert.True(Fixture.Sut.IsSet);
    }

    [Fact]
    public void AlreadySet_LeavesSet()
    {
        Fixture.Sut.Set();

        Target();

        Assert.True(Fixture.Sut.IsSet);
    }

    private void Target() => Fixture.Sut.Set();
}
