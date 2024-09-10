namespace Paraminter.BinaryState.Models;

internal interface IFixture
{
    public abstract IUnresettableBinaryStateAccessor Sut { get; }
}
