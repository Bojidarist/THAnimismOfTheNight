using TH.Utilities;
using UnityEngine;
using UnityEngine.UI;

namespace TH.Controllers
{
    public class AudioSliderController : MonoBehaviour
    {
        [SerializeField]
        public Slider slider;

        [SerializeField]
        public SliderType sliderType;

        private void Start()
        {
            slider.onValueChanged.AddListener((value) => { ChangeVolume(value); });
        }

        private void OnEnable()
        {
            switch (sliderType)
            {
                case SliderType.MusicVolume:
                    slider.value = Config.MusicVolume;
                    break;
                case SliderType.SFXVolume:
                    slider.value = Config.SFXVolume;
                    break;
                default:
                    return;
            }
        }

        public void ChangeVolume(float value)
        {
            switch (sliderType)
            {
                case SliderType.MusicVolume:
                    Config.MusicVolume = value;
                    break;
                case SliderType.SFXVolume:
                    Config.SFXVolume = value;
                    break;
                default:
                    return;
            }
        }
    }
}
