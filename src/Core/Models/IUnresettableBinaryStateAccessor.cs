namespace Paraminter.BinaryState.Models;

/// <summary>Provides access to an unresettable binary state.</summary>
public interface IUnresettableBinaryStateAccessor
    : IBinaryStateReader,
    IBinaryStateSetter
{ }
