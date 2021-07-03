namespace StateHistory
{
    /// <summary>
    /// Keeps a history of mutations applied to the state and allows reversing them. 
    /// Requires access to instances of implementations of IMutationsHandler and IMutationReverser. 
    /// </summary>
    public class CommandHistory : ReversibleHistory<ICommand>
    {
        protected ICommandReverser reverser;

        public CommandHistory(ICommandReverser reverser, int maxHistoryLength = 255)
            : base(maxHistoryLength)
        {
            this.reverser = reverser;
        }

        public override bool Redo()
        {
            throw new System.NotImplementedException();
        }

        public override bool Undo()
        {
            throw new System.NotImplementedException();
        }
    }
}
