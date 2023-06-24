using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Gallery.Source.UI
{
    public class LoadingScreen : MonoBehaviour, ILoadScreen
    {
        [SerializeField] private Slider _progressSlider;
        [SerializeField] private TMP_Text _percent;
        
        [Range(1, 3)]
        [SerializeField] private float _duration = 1;

        private TweenerCore<float, float, FloatOptions> _tweener;

        public float Progress => _progressSlider.value;
        
        private void Start()
        {
            CreateAnimation();
        }

        private void Update()
        {
            if (CanUpdateText())
                UpdatePercentText();
        }

        private void CreateAnimation()
        {
            _tweener = _progressSlider
                .DOValue(1, _duration)
                .OnComplete(() => { _percent.text = "100%"; });
        }

        private bool CanUpdateText()
        {
            return _tweener != null && _tweener.IsActive();
        }
        
        private void UpdatePercentText()
        {
            _percent.text = $"{(int) (_progressSlider.value * 100)} %";
        }
    }
}