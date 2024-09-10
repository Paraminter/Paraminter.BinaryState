namespace Paraminter.BinaryState;

using Moq;

using Paraminter.BinaryState.Models;
using Paraminter.BinaryState.Queries;
using Paraminter.Cqs;

using System;

using Xunit;

public sealed class Constructor
{
    [Fact]
    public void NullStateResetterProvider_ThrowsArgumentNullException()
    {
        var result = Record.Exception(() => Target(null!));

        Assert.IsType<ArgumentNullException>(result);
    }

    [Fact]
    public void ValidArguments_ReturnsResetter()
    {
        var result = Target(Mock.Of<IQueryHandler<IGetBinaryStateResetterQuery, IBinaryStateResetter>>());

        Assert.NotNull(result);
    }

    private static BinaryStateResetter Target(
        IQueryHandler<IGetBinaryStateResetterQuery, IBinaryStateResetter> stateResetterProvider)
    {
        return new BinaryStateResetter(stateResetterProvider);
    }
}
