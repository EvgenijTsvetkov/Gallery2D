namespace Gallery.Source.UI
{
    public class UIProvider : IUIProvider
    {
        public ILoadScreen LoadScreen { get; set; }
        public IViewScreen ViewScreen { get; set; }
    }
}
