namespace Paraminter.BinaryState;

using Paraminter.BinaryState.Commands;
using Paraminter.BinaryState.Models;
using Paraminter.BinaryState.Queries;
using Paraminter.Cqs.Handlers;

using System;

/// <summary>Resets a binary state.</summary>
public sealed class BinaryStateResetter
    : ICommandHandler<IResetBinaryStateCommand>
{
    private readonly IQueryHandler<IGetBinaryStateResetterQuery, IBinaryStateResetter> StateResetterProvider;

    /// <summary>Instantiates a resetter of a binary state.</summary>
    /// <param name="stateResetterProvider">Provides a resetter of the binary state.</param>
    public BinaryStateResetter(
        IQueryHandler<IGetBinaryStateResetterQuery, IBinaryStateResetter> stateResetterProvider)
    {
        StateResetterProvider = stateResetterProvider ?? throw new ArgumentNullException(nameof(stateResetterProvider));
    }

    void ICommandHandler<IResetBinaryStateCommand>.Handle(
        IResetBinaryStateCommand command)
    {
        if (command is null)
        {
            throw new ArgumentNullException(nameof(command));
        }

        var stateResetter = StateResetterProvider.Handle(GetBinaryStateResetterQuery.Instance);

        stateResetter.Reset();
    }
}
