namespace Paraminter.BinaryState.Models;

using Xunit;

public sealed class Constructor
{
    [Fact]
    public void ReturnsAccessor()
    {
        var result = Target();

        Assert.NotNull(result);
    }

    private static ResettableBinaryStateAccessor Target() => new();
}
