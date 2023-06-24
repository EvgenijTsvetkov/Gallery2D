using System.Threading.Tasks;
using UnityEngine;

namespace Gallery.Source.UI
{
    public interface IUIFactory
    {
        Task<IImageView> CreateImageView(RectTransform parent);
    }
}
