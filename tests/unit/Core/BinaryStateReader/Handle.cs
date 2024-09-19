namespace Paraminter.BinaryState;

using Moq;

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
    public void Set_ReturnsTrue() => ReturnsValue(true);

    [Fact]
    public void NotSet_ReturnsFalse() => ReturnsValue(false);

    private bool Target(
        IIsBinaryStateSetQuery query)
    {
        return Fixture.Sut.Handle(query);
    }

    private void ReturnsValue(bool expected)
    {
        Fixture.ModelMock.Setup(static (model) => model.IsSet).Returns(expected);

        var result = Target(Mock.Of<IIsBinaryStateSetQuery>());

        Assert.Equal(expected, result);
    }
}
