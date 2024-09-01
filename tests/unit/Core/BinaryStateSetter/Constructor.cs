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
    public void NullStateSetterProvider_ThrowsArgumentNullException()
    {
        var result = Record.Exception(() => Target(null!));

        Assert.IsType<ArgumentNullException>(result);
    }

    [Fact]
    public void ValidArguments_ReturnsSetter()
    {
        var result = Target(Mock.Of<IQueryHandler<IGetBinaryStateSetterQuery, IBinaryStateSetter>>());

        Assert.NotNull(result);
    }

    private static BinaryStateSetter Target(
        IQueryHandler<IGetBinaryStateSetterQuery, IBinaryStateSetter> stateSetterProvider)
    {
        return new BinaryStateSetter(stateSetterProvider);
    }
}
