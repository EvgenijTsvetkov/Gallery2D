using System.Threading.Tasks;
using UnityEngine;

namespace Gallery.Source.NetworkManagement
{
    public interface IImageDownloader
    {
        Task<Texture2D> Load(string imageName);
    }
}