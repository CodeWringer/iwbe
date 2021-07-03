using System;
using System.Collections.Generic;
using System.Text;

namespace StateHistory
{
    public class DiffHistory : ReversibleHistory<object>
    {
        protected IStateOverrideable store;

        public DiffHistory(IStateOverrideable store, int maxHistoryLength = 255)
            : base(maxHistoryLength)
        {
            this.store = store;
        }

        public override bool Redo()
        {
            throw new NotImplementedException();
        }

        public override bool Undo()
        {
            throw new NotImplementedException();
        }
    }
}
