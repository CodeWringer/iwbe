using Iwbe.Domain.Model;
using StoreSystem;
using System;

namespace Iwbe.Domain.StoreSystem
{
    public class RootState
    {
        public ArticleState ArticleState { get; private set; } = new ArticleState();

        public CalendarState CalendarState { get; private set; } = new CalendarState();

        public CanvasState CanvasState { get; private set; } = new CanvasState();

        public ProjectState ProjectState { get; private set; } = new ProjectState();

        public TagState TagState { get; private set; } = new TagState();

        public RootState()
        {
        }
    }
}