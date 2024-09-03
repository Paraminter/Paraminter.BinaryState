namespace Paraminter.BinaryState.Commands;

internal sealed class ResetBinaryStateCommand
    : IResetBinaryStateCommand
{
    public static IResetBinaryStateCommand Instance { get; } = new ResetBinaryStateCommand();

    private ResetBinaryStateCommand() { }
}
