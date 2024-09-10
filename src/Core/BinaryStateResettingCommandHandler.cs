namespace Paraminter.BinaryState;

using Paraminter.BinaryState.Commands;
using Paraminter.Cqs;

/// <summary>Handles commands by resetting a binary state.</summary>
/// <typeparam name="TQuery">The type of the handled commands.</typeparam>
public sealed class BinaryStateResettingCommandHandler<TQuery>
    : ICommandHandler<TQuery>
    where TQuery : ICommand
{
    private readonly ICommandHandler<IResetBinaryStateCommand> StateResetter;

    /// <summary>Instantiates a command-handler which resets a binary state.</summary>
    /// <param name="stateResetter">Resets the binary state.</param>
    public BinaryStateResettingCommandHandler(
        ICommandHandler<IResetBinaryStateCommand> stateResetter)
    {
        StateResetter = stateResetter ?? throw new System.ArgumentNullException(nameof(stateResetter));
    }

    void ICommandHandler<TQuery>.Handle(
        TQuery command)
    {
        if (command is null)
        {
            throw new System.ArgumentNullException(nameof(command));
        }

        StateResetter.Handle(ResetBinaryStateCommand.Instance);
    }
}
