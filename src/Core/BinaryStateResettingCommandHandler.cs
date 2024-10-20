namespace Paraminter.BinaryState;

using Paraminter.BinaryState.Commands;
using Paraminter.Cqs;

using System.Threading;
using System.Threading.Tasks;

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

    async Task ICommandHandler<TQuery>.Handle(
        TQuery command,
        CancellationToken cancellationToken)
    {
        if (command is null)
        {
            throw new System.ArgumentNullException(nameof(command));
        }

        await StateResetter.Handle(ResetBinaryStateCommand.Instance, cancellationToken);
    }
}
