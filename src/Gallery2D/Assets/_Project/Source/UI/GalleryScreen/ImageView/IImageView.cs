using UnityEngine;

namespace Gallery.Source.UI
{
    public interface IImageView
    {
        string ImageName { get; set; }
        RectTransform SelfTransform { get; }
    }
}
