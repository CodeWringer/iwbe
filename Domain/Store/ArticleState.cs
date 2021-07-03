using Iwbe.Domain.Model;
using StoreSystem;

namespace Iwbe.Domain.StoreSystem
{
    public class ArticleState
    {
        public WatchableCollection<Article> ArticlesWatchable { get; private set; } = new WatchableCollection<Article>();
        public ObservableList<Article> Articles
        {
            get => ArticlesWatchable.Collection;
            set => ArticlesWatchable.Collection = value;
        }

        public ObservableHierarchyDataLinker<Article> HierarchyLinks = new ObservableHierarchyDataLinker<Article>();

        public ArticleState()
        {
        }
    }
}