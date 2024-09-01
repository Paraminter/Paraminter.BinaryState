namespace Paraminter.BinaryState.Models;

using Xunit;

public sealed class Constructor
{
    [Fact]
    public void ReturnsState()
    {
        var result = Target();

        Assert.NotNull(result);
    }

    private static BinaryState Target() => new();
}
