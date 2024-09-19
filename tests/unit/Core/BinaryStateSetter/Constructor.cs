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
    public void ValidArguments_ReturnsSetter()
    {
        var result = Target(Mock.Of<IBinaryStateSetter>());

        Assert.NotNull(result);
    }

    private static BinaryStateSetter Target(
        IBinaryStateSetter model)
    {
        return new BinaryStateSetter(model);
    }
}
