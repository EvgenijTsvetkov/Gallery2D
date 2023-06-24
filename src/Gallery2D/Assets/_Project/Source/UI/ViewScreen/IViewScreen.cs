using TMPro;
using UnityEngine.UI;

namespace Gallery.Source.UI
{
    public interface IViewScreen
    {
        Image Image { get; }
        TMP_Text ImageName { get; }
    }
}