namespace Paraminter.BinaryState;

using Paraminter.BinaryState.Models;
using Paraminter.BinaryState.Queries;
using Paraminter.Cqs.Handlers;

using System;

/// <summary>Provides a setter of a binary state.</summary>
public sealed class BinaryStateSetterProvider
    : IQueryHandler<IGetBinaryStateSetterQuery, IBinaryStateSetter>
{
    private readonly IQueryHandler<IGetBinaryStateQuery, IBinaryState> StateProvider;

    /// <summary>Instantiates a provider of a setter of a binary state.</summary>
    /// <param name="stateProvider">Provides the binary state.</param>
    public BinaryStateSetterProvider(
        IQueryHandler<IGetBinaryStateQuery, IBinaryState> stateProvider)
    {
        StateProvider = stateProvider ?? throw new ArgumentNullException(nameof(stateProvider));
    }

    IBinaryStateSetter IQueryHandler<IGetBinaryStateSetterQuery, IBinaryStateSetter>.Handle(
        IGetBinaryStateSetterQuery query)
    {
        if (query is null)
        {
            throw new ArgumentNullException(nameof(query));
        }

        var state = StateProvider.Handle(GetBinaryStateQuery.Instance);

        return state.Setter;
    }
}
