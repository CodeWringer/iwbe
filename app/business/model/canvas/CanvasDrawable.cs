using System.Collections.ObjectModel;
using Godot;

namespace iwbe.business.model
{
    /// <summary>
    /// Represents the base class for canvas objects. 
    /// Provides some common functionality. 
    /// </summary>
    public abstract class CanvasDrawable
    {
        /// <summary>
        /// Multiplier, defining the minimum zoom to display this object at. 
        /// If <= 0.0, is not considered relevant. 
        /// </summary>
        public float MinZoom;

        /// <summary>
        /// Multiplier, defining the maximum zoom to display this object at. 
        /// If <= 0.0, is not considered relevant. 
        /// </summary>
        public float MaxZoom;

        /// <summary>
        /// Position on canvas, in x and y coordinates. 
        /// </summary>
        public Vector2 Position;

        private CanvasDrawable _parent;
        /// <summary>
        /// Current parent of this canvas object. 
        /// </summary>
        public CanvasDrawable Parent
        {
            get { return _parent; }
            set { SetParent(value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public ObservableCollection<CanvasDrawable> Children;

        public CanvasDrawable()
        {
            Children.CollectionChanged += Children_CollectionChanged;
        }

        /// <summary>
        /// Internal method to override the current parent. 
        /// </summary>
        /// <param name="newParent"></param>
        private void SetParent(CanvasDrawable newParent)
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
                    foreach (CanvasDrawable item in e.NewItems)
                    {
                        item.SetParent(this);
                    }
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Remove:
                    foreach (CanvasDrawable item in e.OldItems)
                    {
                        item.SetParent(null);
                    }
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Replace:
                    foreach (CanvasDrawable item in e.NewItems)
                    {
                        item.SetParent(this);
                    }
                    foreach (CanvasDrawable item in e.OldItems)
                    {
                        item.SetParent(null);
                    }
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Move:
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Reset:
                    foreach (CanvasDrawable item in e.OldItems)
                    {
                        item.SetParent(null);
                    }
                    break;
                default:
                    break;
            }
        }
    }
}