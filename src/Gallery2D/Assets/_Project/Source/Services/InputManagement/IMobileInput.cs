using System;

namespace Gallery.Source.InputManagement
{
    public interface IMobileInput
    {
        event Action OnRightSwipe;
        event Action OnBackButtonClicked;
    }
}