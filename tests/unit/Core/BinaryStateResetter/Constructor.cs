namespace Paraminter.BinaryState;

using Moq;

using Paraminter.BinaryState.Models;

using System;

using Xunit;

public sealed class Constructor
{
    [Fact]
    public void NullModel_ThrowsArgumentNullException()
    {
        var result = Record.Exception(() => Target(null!));

        Assert.IsType<ArgumentNullException>(result);
    }

    [Fact]
    public void ValidArguments_ReturnsResetter()
    {
        var result = Target(Mock.Of<IBinaryStateResetter>());

        Assert.NotNull(result);
    }

    private static BinaryStateResetter Target(
        IBinaryStateResetter model)
    {
        return new BinaryStateResetter(model);
    }
}
