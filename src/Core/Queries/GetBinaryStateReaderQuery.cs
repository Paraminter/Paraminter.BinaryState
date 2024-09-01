namespace Paraminter.BinaryState.Queries;

internal sealed class GetBinaryStateReaderQuery
    : IGetBinaryStateReaderQuery
{
    public static IGetBinaryStateReaderQuery Instance { get; } = new GetBinaryStateReaderQuery();

    private GetBinaryStateReaderQuery() { }
}
