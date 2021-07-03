namespace StateHistory
{
    /// <summary>
    /// Represents a history record that can be undone or redone. 
    /// </summary>
    public interface IReversibleHistory
    {
        /// <summary>
        /// Undoes the last history item, if possible. 
        /// </summary>
        /// <returns>True, if there was a history item to reverse. </returns>
        bool Undo();

        /// <summary>
        /// Redoes the last previously undone history item, if possible. 
        /// </summary>
        /// <returns>True, if there was a history item to re-apply. </returns>
        bool Redo();
    }
}
