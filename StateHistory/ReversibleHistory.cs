using System;
using System.Collections.Generic;

namespace StateHistory
{
    /// <summary>
    /// Abstract base class a history whose items can be undone and redone. 
    /// </summary>
    public abstract class ReversibleHistory<T> : IReversibleHistory 
        where T : class
    {
        protected LimitedStack<T> _undoStack;
        /// <summary>
        /// Reversible items. 
        /// </summary>
        public IEnumerable<T> UndoStack
        {
            get { return this._undoStack.ToArray(); }
            protected set { this._undoStack = new LimitedStack<T>(value, this.MaxHistoryLength); }
        }

        protected Stack<T> _redoStack;
        /// <summary>
        /// Reversed items. 
        /// </summary>
        public IEnumerable<T> RedoStack
        {
            get { return _redoStack.ToArray(); }
            protected set { this._redoStack = new Stack<T>(value); }
        }

        /// <summary>
        /// If not null, the last reversed item. 
        /// </summary>
        protected T _lastRedo;

        /// <summary>
        /// Maximum number of items to keep in the history list. 
        /// </summary>
        public int MaxHistoryLength
        {
            get { return this._undoStack.MaxEntryCount; }
            set { this._undoStack.MaxEntryCount = value; }
        }

        public ReversibleHistory(int maxHistoryLength = 255)
        {
            this._undoStack = new LimitedStack<T>(maxHistoryLength);
            this._redoStack = new Stack<T>();
        }

        /// <summary>
        /// Pops the last redo history entry and returns it, if possible. 
        /// </summary>
        /// <returns>The last redo history entry or default(T). </returns>
        protected T TryPopRedo()
        {
            if (this._redoStack.Count == 0)
                return default;

            var popped = this._redoStack.Pop();

            this._undoStack.Push(popped);
            this._lastRedo = popped;

            return popped;
        }

        /// <summary>
        /// Pops the last undo history entry and returns it, if possible. 
        /// </summary>
        /// <returns>The last undo history entry or default(T). </returns>
        protected T TryPopUndo()
        {
            if (this._undoStack.Count == 0)
                return default;

            var popped = this._undoStack.Pop();
            this._redoStack.Push(popped);

            return popped;
        }

        /// <summary>
        /// Pushes the given history entry to the undo history. 
        /// 
        /// Will clear the redo history, if the given history entry and the last redone history entry differ. 
        /// </summary>
        /// <param name="entry"></param>
        protected void PushToUndoHistory(T entry)
        {
            this._undoStack.Push(entry);

            if (this._lastRedo != entry)
            {
                this.ClearRedoHistory();
            }
        }

        /// <summary>
        /// Removes all reversed items. 
        /// </summary>
        public void ClearRedoHistory()
        {
            this._redoStack.Clear();
            this._lastRedo = default;
        }

        /// <summary>
        /// Redoes the last previously undone item to the state, if possible. 
        /// </summary>
        /// <remarks>
        /// Use this.TryPopRedo() to get the last redo history entry. 
        /// Returns null, if there are no redo history entries. 
        /// </remarks>
        /// <returns>True, if there was a item to re-apply. </returns>
        public abstract bool Redo();

        /// <summary>
        /// Undoes the last item to the state, if possible. 
        /// </summary>
        /// <remarks>
        /// Use this.TryPopUndo() to get the last undo history entry. 
        /// Returns null, if there are no undo history entries. 
        /// </remarks>
        /// <returns>True, if there was a item to undo. </returns>
        public abstract bool Undo();
    }
}
