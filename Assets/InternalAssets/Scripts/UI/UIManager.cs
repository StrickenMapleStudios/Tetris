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

            UIEventChannel.current.OnEscape.AddListener(Pause);
            
            GameEventChannel.current.OnGameOver.AddListener(OnGameOver);
        }

        private void OnDisable() {
            UIEventChannel.current.OnEscape.RemoveListener(Pause);

            GameEventChannel.current.OnGameOver.RemoveListener(OnGameOver);
        }

        private void Pause() {
            Time.timeScale = 0;
            _pauseUI.gameObject.SetActive(true);
        }

        private void OnGameOver() {
            _gameOverUI.gameObject.SetActive(true);
        }
    }
}