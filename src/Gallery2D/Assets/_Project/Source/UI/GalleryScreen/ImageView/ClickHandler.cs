using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Gallery.Source.UI
{
    public class ClickHandler : MonoBehaviour, IPointerClickHandler
    {
        public event Action OnClick;
        
        public void OnPointerClick(PointerEventData eventData)
        {
            OnClick?.Invoke();
        }
    }
}
