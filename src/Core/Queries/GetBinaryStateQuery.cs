namespace Paraminter.BinaryState.Queries;

internal sealed class GetBinaryStateQuery
    : IGetBinaryStateQuery
{
    public static IGetBinaryStateQuery Instance { get; } = new GetBinaryStateQuery();

    private GetBinaryStateQuery() { }
}
