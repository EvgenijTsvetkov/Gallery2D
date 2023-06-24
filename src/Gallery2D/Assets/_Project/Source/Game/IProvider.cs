namespace Gallery.Source.Game
{
    public interface IProvider<T>
    {
        T Value { get; set; }
    }
}