using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game;

namespace UI {

    public class UIManager : MonoBehaviour
    {
        [SerializeField] private GameUIManager _gameUI;
        [SerializeField] private PauseManager _pauseUI;
        [SerializeField] private GameOverManager _gameOverUI;

        private void OnEnable() {
            UIEventChannel.current.OnPauseClicked.AddListener(OnPauseClicked);
            
            GameEventChannel.current.OnGameOver.AddListener(OnGameOver);
        }

        private void OnDisable() {
            UIEventChannel.current.OnPauseClicked.RemoveListener(OnPauseClicked);

            GameEventChannel.current.OnGameOver.RemoveListener(OnGameOver);
        }

        private void OnPauseClicked() {
            _pauseUI.gameObject.SetActive(true);
        }

        private void OnGameOver() {
            _gameOverUI.gameObject.SetActive(true);
        }
    }
}