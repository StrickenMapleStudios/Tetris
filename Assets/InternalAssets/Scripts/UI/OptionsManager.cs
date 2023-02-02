using UnityEngine;
using UnityEngine.UI;

namespace UI {

    public class OptionsManager : MonoBehaviour
    {
        [SerializeField] private Slider _soundSlider;

        private void OnEnable() {
            _soundSlider.onValueChanged.AddListener(OnSoundChanged);
        }

        private void OnDisable() {
            _soundSlider.onValueChanged.RemoveListener(OnSoundChanged);
        }

        private void OnSoundChanged(float value) {
            Debug.Log(value);
        }
    }
}