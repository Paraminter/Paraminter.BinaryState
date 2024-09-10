namespace Paraminter.BinaryState;

using Paraminter.BinaryState.Queries;
using Paraminter.Cqs;

/// <summary>Handles queries by reading a binary state.</summary>
/// <typeparam name="TQuery">The type of the handled queries.</typeparam>
public sealed class BinaryStateReadingQueryHandler<TQuery>
    : IQueryHandler<TQuery, bool>
    where TQuery : IQuery
{
    private readonly IQueryHandler<IIsBinaryStateSetQuery, bool> StateReader;

    /// <summary>Instantiates a query-handler which reads a binary state.</summary>
    /// <param name="stateReader">Reads the binary state.</param>
    public BinaryStateReadingQueryHandler(
        IQueryHandler<IIsBinaryStateSetQuery, bool> stateReader)
    {
        StateReader = stateReader ?? throw new System.ArgumentNullException(nameof(stateReader));
    }

    bool IQueryHandler<TQuery, bool>.Handle(
        TQuery query)
    {
        if (query is null)
        {
            throw new System.ArgumentNullException(nameof(query));
        }

        return StateReader.Handle(IsBinaryStateSetQuery.Instance);
    }
}
