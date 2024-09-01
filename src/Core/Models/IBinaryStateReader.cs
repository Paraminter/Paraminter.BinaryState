namespace Paraminter.BinaryState.Models;

/// <summary>Reads a binary state.</summary>
public interface IBinaryStateReader
{
    /// <summary>Indicates whether the binary state is set.</summary>
    public abstract bool IsSet { get; }
}
