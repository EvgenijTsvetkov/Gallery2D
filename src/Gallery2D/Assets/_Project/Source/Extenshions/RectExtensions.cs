using UnityEngine;

namespace Gallery.Source.Extensions
{
    public static class RectExtensions
    {
        public static bool IsFullyVisibleFrom(this RectTransform rectTransform, Camera camera = null)
        {
            if (!rectTransform.gameObject.activeInHierarchy)
                return false;
 
            return CountCornersVisibleFrom(rectTransform, camera) == 4;
        }
        
        public static bool IsVisibleFrom(this RectTransform rectTransform, Camera camera = null)
        {
            if (!rectTransform.gameObject.activeInHierarchy)
                return false;
 
            return CountCornersVisibleFrom(rectTransform, camera) > 0; 
        }
        
        private static int CountCornersVisibleFrom(this RectTransform rectTransform, Camera camera = null)
        {
            Rect screenBounds = new Rect(0f, 0f, Screen.width, Screen.height); 
            Vector3[] objectCorners = new Vector3[4];
            rectTransform.GetWorldCorners(objectCorners);
 
            int visibleCorners = 0;
            for (var i = 0; i < objectCorners.Length; i++)
            {
                var tempScreenSpaceCorner = camera != null 
                    ? camera.WorldToScreenPoint(objectCorners[i]) 
                    : objectCorners[i];
                
                if (screenBounds.Contains(tempScreenSpaceCorner)) 
                    visibleCorners++;
            }
            
            return visibleCorners;
        }
    }
}
