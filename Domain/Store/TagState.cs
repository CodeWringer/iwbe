using Iwbe.Domain.Model;
using StoreSystem;

namespace Iwbe.Domain.StoreSystem
{
    public class TagState
    {
        public ObservableDataLinker<Tag, ITaggable> TagLinks = new ObservableDataLinker<Tag, ITaggable>();

        public TagState()
        {
        }
    }
}