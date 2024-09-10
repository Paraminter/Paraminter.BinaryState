namespace Paraminter.BinaryState;

using Paraminter.BinaryState.Models;
using Paraminter.BinaryState.Queries;
using Paraminter.Cqs;

using System;

/// <summary>Provides a resetter of a binary state.</summary>
public sealed class BinaryStateResetterProvider
    : IQueryHandler<IGetBinaryStateResetterQuery, IBinaryStateResetter>
{
    private readonly IBinaryStateResetter StateResetter;

    /// <summary>Instantiates a provider of a resetter of a binary state.</summary>
    /// <param name="stateResetter">The resetter of the binary state.</param>
    public BinaryStateResetterProvider(
        IBinaryStateResetter stateResetter)
    {
        StateResetter = stateResetter ?? throw new ArgumentNullException(nameof(stateResetter));
    }

    IBinaryStateResetter IQueryHandler<IGetBinaryStateResetterQuery, IBinaryStateResetter>.Handle(
        IGetBinaryStateResetterQuery query)
    {
        if (query is null)
        {
            throw new ArgumentNullException(nameof(query));
        }

        return StateResetter;
    }
}
