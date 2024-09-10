namespace Paraminter.BinaryState;

using Paraminter.BinaryState.Commands;
using Paraminter.Cqs;

/// <summary>Handles commands by setting a binary state.</summary>
/// <typeparam name="TCommand">The type of the handled commands.</typeparam>
public sealed class BinaryStateSettingCommandHandler<TCommand>
    : ICommandHandler<TCommand>
    where TCommand : ICommand
{
    private readonly ICommandHandler<ISetBinaryStateCommand> StateSetter;

    /// <summary>Instantiates a command-handler which sets a binary state.</summary>
    /// <param name="stateSetter">Sets the binary state.</param>
    public BinaryStateSettingCommandHandler(
        ICommandHandler<ISetBinaryStateCommand> stateSetter)
    {
        StateSetter = stateSetter ?? throw new System.ArgumentNullException(nameof(stateSetter));
    }

    void ICommandHandler<TCommand>.Handle(
        TCommand command)
    {
        if (command is null)
        {
            throw new System.ArgumentNullException(nameof(command));
        }

        StateSetter.Handle(SetBinaryStateCommand.Instance);
    }
}
