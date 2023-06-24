using UnityEngine;
using static Eatable.Source.Data.Constants;

namespace Gallery.Source.Data
{
    [CreateAssetMenu(fileName = "GalleryConfig", menuName = ProjectName + "/Gallery Config")]
    public class GalleryConfig : ScriptableObject, IGalleryConfig
    {
        [MinAttribute(0)] [SerializeField] private int _imagesCount = 3;

        [SerializeField] private string _pathForDownload = "http://data.ikppbb.com/test-task-unity-data/pics/";

        public int ImagesCount => _imagesCount;
        public string PathForDownload => _pathForDownload;
    }
}
