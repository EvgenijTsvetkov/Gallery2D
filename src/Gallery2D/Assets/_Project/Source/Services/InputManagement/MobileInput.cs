using System;
using UnityEngine;

namespace Gallery.Source.InputManagement
{
    public class MobileInput : MonoBehaviour, IMobileInput
    {
        [Range(100, 300)]
        [SerializeField] private int _swipeDistance = 200;
        
        public event Action OnRightSwipe;
        public event Action OnBackButtonClicked;

        private Vector2 _startTouchPosition;
        private Vector2 _endTouchPosition;

        private void Update()
        {
            if (HasTouch())
            {
                GetTouchPosition();
                CheckRightSwipe();
            }

#if PLATFORM_ANDROID
            CheckBackButtonClicked();
#endif
        }

        private bool HasTouch()
        {
            return Input.touchCount > 0;
        }
        
        private void GetTouchPosition()
        {
            Touch touch = Input.GetTouch(0);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    _startTouchPosition = touch.position;
                    break;

                case TouchPhase.Ended:
                    _endTouchPosition = touch.position;
                    break;
            }
        }

        private void CheckRightSwipe()
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase != TouchPhase.Canceled && touch.phase != TouchPhase.Ended) 
                return;
            
            var swipeDelta = _endTouchPosition - _startTouchPosition;
            if (swipeDelta.magnitude < _swipeDistance)
                return;
            
            if (Mathf.Abs(swipeDelta.x) > Mathf.Abs(swipeDelta.y) && swipeDelta.x > 0) 
                OnRightSwipe?.Invoke();
        }

        private void CheckBackButtonClicked()
        {
            if (Application.platform == RuntimePlatform.Android && Input.GetKeyDown(KeyCode.Escape))
                OnBackButtonClicked?.Invoke();
        }
    }
}
