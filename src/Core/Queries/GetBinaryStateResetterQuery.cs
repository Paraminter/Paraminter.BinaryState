namespace Paraminter.BinaryState.Queries;

internal sealed class GetBinaryStateResetterQuery
    : IGetBinaryStateResetterQuery
{
    public static IGetBinaryStateResetterQuery Instance { get; } = new GetBinaryStateResetterQuery();

    private GetBinaryStateResetterQuery() { }
}
