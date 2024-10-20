namespace Paraminter.BinaryState;

using Moq;

using Paraminter.BinaryState.Commands;

using System;
using System.Threading;
using System.Threading.Tasks;

using Xunit;

public sealed class Handle
{
    private readonly IFixture Fixture = FixtureFactory.Create();

    [Fact]
    public async Task NullCommand_ThrowsArgumentNullException()
    {
        var result = await Record.ExceptionAsync(() => Target(null!, CancellationToken.None));

        Assert.IsType<ArgumentNullException>(result);
    }

    [Fact]
    public async Task ValidArguments_Sets()
    {
        await Target(Mock.Of<ISetBinaryStateCommand>(), CancellationToken.None);

        Fixture.ModelMock.Verify(static (model) => model.Set(), Times.Once);
    }

    private async Task Target(
        ISetBinaryStateCommand command,
        CancellationToken cancellationToken)
    {
        await Fixture.Sut.Handle(command, cancellationToken);
    }
}
