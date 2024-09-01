namespace Paraminter.BinaryState;

using Moq;

using Paraminter.BinaryState.Models;
using Paraminter.BinaryState.Queries;
using Paraminter.Cqs.Handlers;

using System;

using Xunit;

public sealed class Constructor
{
    [Fact]
    public void NullStateProvider_ThrowsArgumentNullException()
    {
        var result = Record.Exception(() => Target(null!));

        Assert.IsType<ArgumentNullException>(result);
    }

    [Fact]
    public void ValidArguments_ReturnsProvider()
    {
        var result = Target(Mock.Of<IQueryHandler<IGetBinaryStateQuery, IBinaryState>>());

        Assert.NotNull(result);
    }

    private static BinaryStateResetterProvider Target(
        IQueryHandler<IGetBinaryStateQuery, IBinaryState> stateProvider)
    {
        return new BinaryStateResetterProvider(stateProvider);
    }
}
