namespace Paraminter.BinaryState.Queries;

internal sealed class GetBinaryStateSetterQuery
    : IGetBinaryStateSetterQuery
{
    public static IGetBinaryStateSetterQuery Instance { get; } = new GetBinaryStateSetterQuery();

    private GetBinaryStateSetterQuery() { }
}
