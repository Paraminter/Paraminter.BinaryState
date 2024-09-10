namespace Paraminter.BinaryState;

using Moq;

using Paraminter.BinaryState.Models;

using System;

using Xunit;

public sealed class Constructor
{
    [Fact]
    public void NullStateResetter_ThrowsArgumentNullException()
    {
        var result = Record.Exception(() => Target(null!));

        Assert.IsType<ArgumentNullException>(result);
    }

    [Fact]
    public void ValidArguments_ReturnsProvider()
    {
        var result = Target(Mock.Of<IBinaryStateResetter>());

        Assert.NotNull(result);
    }

    private static BinaryStateResetterProvider Target(
        IBinaryStateResetter stateResetter)
    {
        return new BinaryStateResetterProvider(stateResetter);
    }
}
