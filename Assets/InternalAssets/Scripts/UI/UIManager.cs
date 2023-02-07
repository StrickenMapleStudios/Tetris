using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI {

    public class UIManager : MonoBehaviour
    {
        [SerializeField] private GameUIManager _gameUI;
        [SerializeField] private PauseManager _pauseUI;

        private void OnEnable() {
            UIEventChannel.current.OnPauseClicked.AddListener(OnPauseClicked);
        }

        private void OnDisable() {
            UIEventChannel.current.OnPauseClicked.RemoveListener(OnPauseClicked);
        }

        private void OnPauseClicked() {
            _pauseUI.gameObject.SetActive(true);
        }
    }
}