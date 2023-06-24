namespace Gallery.Source.Data
{
    public interface IGalleryConfig
    {
        int ImagesCount { get; }
        string PathForDownload { get; }
    }
}