namespace Paraminter.BinaryState;

using Paraminter.BinaryState.Commands;
using Paraminter.BinaryState.Models;
using Paraminter.BinaryState.Queries;
using Paraminter.Cqs.Handlers;

using System;

/// <summary>Sets a binary state.</summary>
public sealed class BinaryStateSetter
    : ICommandHandler<ISetBinaryStateCommand>
{
    private readonly IQueryHandler<IGetBinaryStateSetterQuery, IBinaryStateSetter> StateSetterProvider;

    /// <summary>Instantiates a setter of a binary state.</summary>
    /// <param name="stateSetterProvider">Provides a setter of the binary state.</param>
    public BinaryStateSetter(
        IQueryHandler<IGetBinaryStateSetterQuery, IBinaryStateSetter> stateSetterProvider)
    {
        StateSetterProvider = stateSetterProvider ?? throw new ArgumentNullException(nameof(stateSetterProvider));
    }

    void ICommandHandler<ISetBinaryStateCommand>.Handle(
        ISetBinaryStateCommand command)
    {
        if (command is null)
        {
            throw new ArgumentNullException(nameof(command));
        }

        var stateSetter = StateSetterProvider.Handle(GetBinaryStateSetterQuery.Instance);

        stateSetter.Set();
    }
}
