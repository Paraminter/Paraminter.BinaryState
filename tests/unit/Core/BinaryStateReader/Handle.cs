namespace Paraminter.BinaryState;

using Moq;

using Paraminter.BinaryState.Queries;

using System;
using System.Threading;
using System.Threading.Tasks;

using Xunit;

public sealed class Handle
{
    private readonly IFixture Fixture = FixtureFactory.Create();

    [Fact]
    public async Task NullQuery_ThrowsArgumentNullException()
    {
        var result = await Record.ExceptionAsync(() => Target(null!, CancellationToken.None));

        Assert.IsType<ArgumentNullException>(result);
    }

    [Fact]
    public async Task Set_ReturnsTrue() => await ReturnsValue(true);

    [Fact]
    public async Task NotSet_ReturnsFalse() => await ReturnsValue(false);

    private async Task<bool> Target(
        IIsBinaryStateSetQuery query,
        CancellationToken cancellationToken)
    {
        return await Fixture.Sut.Handle(query, cancellationToken);
    }

    private async Task ReturnsValue(bool expected)
    {
        Fixture.ModelMock.Setup(static (model) => model.IsSet).Returns(expected);

        var result = await Target(Mock.Of<IIsBinaryStateSetQuery>(), CancellationToken.None);

        Assert.Equal(expected, result);
    }
}
