namespace Paraminter.BinaryState.Models;

using Xunit;

public sealed class Setter_Set
{
    private readonly IFixture Fixture = FixtureFactory.Create();

    [Fact]
    public void NotAlreadySet_Sets()
    {
        Target();

        Assert.True(Fixture.Sut.Reader.IsSet);
    }

    [Fact]
    public void AlreadySet_LeavesSet()
    {
        Fixture.Sut.Setter.Set();

        Target();

        Assert.True(Fixture.Sut.Reader.IsSet);
    }

    private void Target() => Fixture.Sut.Setter.Set();
}
