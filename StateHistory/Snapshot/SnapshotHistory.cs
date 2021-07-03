namespace StateHistory
{
    /// <summary>
    /// Keeps a history of state changes and allows reversing them. 
    /// </summary>
    public class SnapshotHistory : ReversibleHistory<IStateOverrideable>
    {
        protected IStateOverrideable stateOverridable;

        public SnapshotHistory(IStateOverrideable stateOverrideable, int maxHistoryLength = 255)
            : base(maxHistoryLength)
        {
            this.stateOverridable = stateOverrideable;
        }

        public void RecordSnapshot(IStateOverrideable state)
        {
            this.PushToUndoHistory(state);
        }

        public override bool Redo()
        {
            var state = this.TryPopRedo();
            if (state == null)
                return false;

            this.stateOverridable.SetState(state);

            return true;
        }

        public override bool Undo()
        {
            var state = this.TryPopUndo();
            if (state == null)
                return false;

            this.stateOverridable.SetState(state);

            return true;
        }
    }
}
