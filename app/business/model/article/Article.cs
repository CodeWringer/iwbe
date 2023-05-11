using iwbe.business.state;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace iwbe.business.model
{
    /// <summary>
    /// Represents an article definition. 
    /// </summary>
    public class Article : ITaggable
    {
        private ApplicationState _applicationState;

        /// <summary>
        /// Unique ID. 
        /// </summary>
        public Guid Id;

        /// <summary>
        /// Localized name of the article. 
        /// </summary>
        public List<LocalizedContent> Name;

        /// <summary>
        /// The number of words the article content contains under the currently set language. 
        /// </summary>
        public long WordCount;

        /// <summary>
        /// The localized content of the article. 
        /// </summary>
        public List<LocalizedContent> Content;

        /// <summary>
        /// List of prominent content, which should be displayed in its own, easily accessible block. 
        /// </summary>
        public List<LocalizedContent> Prominent;

        private Article _parent;
        /// <summary>
        /// 
        /// </summary>
        public Article Parent
        {
            get { return _parent; }
            set { SetParent(value); }
        }

        public IEnumerable<Tag> Tags => throw new NotImplementedException();

        /// <summary>
        /// 
        /// </summary>
        public ObservableCollection<Article> Children;

        public Article(ApplicationState applicationState, Guid id)
        {
            Id = id;
            _applicationState = applicationState;

            Children.CollectionChanged += Children_CollectionChanged;
        }

        /// <summary>
        /// Internal method to override the current parent. 
        /// </summary>
        /// <param name="newParent"></param>
        private void SetParent(Article newParent)
        {
            // Remove from current parent. 
            if (_parent != null)
                _parent.Children.Remove(this);

            _parent = newParent;
        }

        private void Children_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
                    foreach (Article item in e.NewItems)
                    {
                        item.SetParent(this);
                    }
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Remove:
                    foreach (Article item in e.OldItems)
                    {
                        item.SetParent(null);
                    }
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Replace:
                    foreach (Article item in e.NewItems)
                    {
                        item.SetParent(this);
                    }
                    foreach (Article item in e.OldItems)
                    {
                        item.SetParent(null);
                    }
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Move:
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Reset:
                    foreach (Article item in e.OldItems)
                    {
                        item.SetParent(null);
                    }
                    break;
                default:
                    break;
            }
        }

        public void AddTag(Tag tag)
        {
            throw new NotImplementedException();
        }

        public bool RemoveTag(Tag tag)
        {
            throw new NotImplementedException();
        }
    }
}