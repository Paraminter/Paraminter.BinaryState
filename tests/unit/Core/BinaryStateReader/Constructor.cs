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
    public void ValidArguments_ReturnsProvider()
    {
        var result = Target(Mock.Of<IBinaryStateReader>());

        Assert.NotNull(result);
    }

    private static BinaryStateReader Target(
        IBinaryStateReader model)
    {
        return new BinaryStateReader(model);
    }
}
