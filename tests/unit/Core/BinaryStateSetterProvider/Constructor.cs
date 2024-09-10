namespace Paraminter.BinaryState;

using Moq;

using Paraminter.BinaryState.Models;

using System;

using Xunit;

public sealed class Constructor
{
    [Fact]
    public void NullStateSetter_ThrowsArgumentNullException()
    {
        var result = Record.Exception(() => Target(null!));

        Assert.IsType<ArgumentNullException>(result);
    }

    [Fact]
    public void ValidArguments_ReturnsProvider()
    {
        var result = Target(Mock.Of<IBinaryStateSetter>());

        Assert.NotNull(result);
    }

    private static BinaryStateSetterProvider Target(
        IBinaryStateSetter stateSetter)
    {
        return new BinaryStateSetterProvider(stateSetter);
    }
}
