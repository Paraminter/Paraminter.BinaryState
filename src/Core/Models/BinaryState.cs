namespace Paraminter.BinaryState.Models;

/// <inheritdoc cref="IBinaryState"/>
public sealed class BinaryState
    : IBinaryState
{
    private readonly IBinaryStateReader Reader;
    private readonly IBinaryStateSetter Setter;
    private readonly IBinaryStateResetter Resetter;

    /// <summary>Instantiates a representation of a binary state.</summary>
    public BinaryState()
    {
        var state = new State();

        Reader = new BinaryStateReader(state);
        Setter = new BinaryStateSetter(state);
        Resetter = new BinaryStateResetter(state);
    }

    IBinaryStateReader IBinaryState.Reader => Reader;
    IBinaryStateSetter IBinaryState.Setter => Setter;
    IBinaryStateResetter IBinaryState.Resetter => Resetter;

    private sealed class State
    {
        public bool IsSet { get; private set; }

        public void Set()
        {
            IsSet = true;
        }

        public void Reset()
        {
            IsSet = false;
        }
    }

    private sealed class BinaryStateReader
        : IBinaryStateReader
    {
        private readonly State State;

        public BinaryStateReader(
            State state)
        {
            State = state;
        }

        bool IBinaryStateReader.IsSet => State.IsSet;
    }

    private sealed class BinaryStateSetter
        : IBinaryStateSetter
    {
        private readonly State State;

        public BinaryStateSetter(
            State state)
        {
            State = state;
        }

        void IBinaryStateSetter.Set() => State.Set();
    }

    private sealed class BinaryStateResetter
        : IBinaryStateResetter
    {
        private readonly State State;

        public BinaryStateResetter(
            State state)
        {
            State = state;
        }

        void IBinaryStateResetter.Reset() => State.Reset();
    }
}
