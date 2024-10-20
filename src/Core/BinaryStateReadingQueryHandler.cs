namespace Paraminter.BinaryState;

using Paraminter.BinaryState.Queries;
using Paraminter.Cqs;

using System.Threading;
using System.Threading.Tasks;

/// <summary>Handles queries by reading a binary state.</summary>
/// <typeparam name="TQuery">The type of the handled queries.</typeparam>
/// <typeparam name="TResponse">The type of the response.</typeparam>
public sealed class BinaryStateReadingQueryHandler<TQuery, TResponse>
    : IQueryHandler<TQuery, TResponse>
    where TQuery : IQuery
{
    private readonly IQueryHandler<IIsBinaryStateSetQuery, TResponse> StateReader;

    /// <summary>Instantiates a query-handler which reads a binary state.</summary>
    /// <param name="stateReader">Reads the binary state.</param>
    public BinaryStateReadingQueryHandler(
        IQueryHandler<IIsBinaryStateSetQuery, TResponse> stateReader)
    {
        StateReader = stateReader ?? throw new System.ArgumentNullException(nameof(stateReader));
    }

    async Task<TResponse> IQueryHandler<TQuery, TResponse>.Handle(
        TQuery query,
        CancellationToken cancellationToken)
    {
        if (query is null)
        {
            throw new System.ArgumentNullException(nameof(query));
        }

        return await StateReader.Handle(IsBinaryStateSetQuery.Instance, cancellationToken).ConfigureAwait(false);
    }
}
