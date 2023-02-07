using Game;
using UnityEngine;
using UnityEngine.UI;

namespace UI {

    public class OptionsManager : MonoBehaviour
    {
        [Header("Sound")]
        [SerializeField] private Slider _general;
        [SerializeField] private Slider _fx;
        [SerializeField] private Slider _music;

        [Header("Visual")]
        [SerializeField] private Toggle _animations;
        [SerializeField] private Toggle _ghostPiece;

        [Header("Buttons")]
        [SerializeField] private Button _done;

        private void OnEnable() {
            _general.onValueChanged.AddListener(OnGeneralChanged);
            _fx.onValueChanged.AddListener(OnFXChanged);
            _music.onValueChanged.AddListener(OnMusicChanged);

            _animations.onValueChanged.AddListener(OnAnimationsChanged);
            _ghostPiece.onValueChanged.AddListener(OnGhostPieceChanged);

            _done.onClick.AddListener(OnDoneClicked);

            _general.value = GamePrefs.Instance.GeneralVolume;
            _fx.value = GamePrefs.Instance.FXVolume;
            _music.value = GamePrefs.Instance.MusicVolume;

            _animations.isOn = GamePrefs.Instance.ShowAnimations;
            _ghostPiece.isOn = GamePrefs.Instance.ShowGhostPiece;
        }

        private void OnDisable() {
            _general.onValueChanged.RemoveListener(OnGeneralChanged);
            _fx.onValueChanged.RemoveListener(OnFXChanged);
            _music.onValueChanged.RemoveListener(OnMusicChanged);

            _animations.onValueChanged.RemoveListener(OnAnimationsChanged);
            _ghostPiece.onValueChanged.RemoveListener(OnGhostPieceChanged);

            _done.onClick.RemoveListener(OnDoneClicked);
        }

        private void OnGeneralChanged(float value) {
            GamePrefs.Instance.GeneralVolume = value;
        }

        private void OnFXChanged(float value) {
            GamePrefs.Instance.FXVolume = value;
        }

        private void OnMusicChanged(float value) {
            GamePrefs.Instance.MusicVolume = value;
        }

        private void OnAnimationsChanged(bool value) {
            GamePrefs.Instance.ShowAnimations = value;
        }

        private void OnGhostPieceChanged(bool value) {
            GamePrefs.Instance.ShowGhostPiece = value;
        }

        private void OnDoneClicked() {
            gameObject.SetActive(false);
        }
    }
}