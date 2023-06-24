namespace Gallery.Source.UI
{
    public interface IUIProvider
    {
        ILoadScreen LoadScreen { get; set; }
        IViewScreen ViewScreen { get; set; }
    }
}