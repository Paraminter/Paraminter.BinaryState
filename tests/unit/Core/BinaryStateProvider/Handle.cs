namespace Paraminter.BinaryState;

using Moq;

using Paraminter.BinaryState.Models;
using Paraminter.BinaryState.Queries;

using System;

using Xunit;

public sealed class Handle
{
    private readonly IFixture Fixture = FixtureFactory.Create();

    [Fact]
    public void NullQuery_ThrowsArgumentNullException()
    {
        var result = Record.Exception(() => Target(null!));

        Assert.IsType<ArgumentNullException>(result);
    }

    [Fact]
    public void ValidQuery_ReturnsState()
    {
        var result = Target(Mock.Of<IGetBinaryStateQuery>());

        Assert.Same(Fixture.StateMock.Object, result);
    }

    private IBinaryState Target(
        IGetBinaryStateQuery query)
    {
        return Fixture.Sut.Handle(query);
    }
}
