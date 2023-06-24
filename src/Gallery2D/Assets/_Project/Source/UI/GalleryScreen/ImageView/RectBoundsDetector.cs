using System;
using Gallery.Source.Extensions;
using UnityEngine;

namespace Gallery.Source.UI
{
    [RequireComponent(typeof(RectTransform))]
    public class RectBoundsDetector : MonoBehaviour
    {
        private RectTransform _selfRectTransform;
        public event Action OnScreenBoundsContainRect;

        private void Awake()
        {
            _selfRectTransform = GetComponent<RectTransform>();
        }

        private void Update()
        {
            if (_selfRectTransform.IsVisibleFrom())
                OnScreenBoundsContainRect?.Invoke();
        }
    }
}
