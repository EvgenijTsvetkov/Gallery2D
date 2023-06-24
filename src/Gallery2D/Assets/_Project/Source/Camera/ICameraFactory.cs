using System.Threading.Tasks;
using UnityEngine;

namespace Gallery.Source
{
    public interface ICameraFactory
    {
        Task<Camera> Create(string cameraKey);
    }
}