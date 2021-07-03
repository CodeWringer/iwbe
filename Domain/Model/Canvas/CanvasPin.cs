using StoreSystem;

namespace Iwbe.Domain.Model
{
    /// <summary>
    /// Represents a point on canvas. 
    /// </summary>
    public class CanvasPin : CanvasDrawable
    {
        public Watchable<Symbol> SymbolWatchable = new Watchable<Symbol>();
        /// <summary>
        /// The symbol to draw in place of the pin. 
        /// </summary>
        public Symbol Symbol
        {
            get => SymbolWatchable.Value;
            set => SymbolWatchable.Value = value;
        }
    }
}