using UnityEngine;
using Input;
using UI;

namespace Game {
    using System.Collections;
    using Field;
    using Minoes;
    using UnityEngine.SceneManagement;

    public partial class GameManager : MonoBehaviour
    {
        [Header("GAME MANAGER")]

        [Header("Channels")]
        [SerializeField] private GameEventChannel _gameEventChannel;
        [SerializeField] private InputEventChannel _inputEventChannel;
        [SerializeField] private UIEventChannel _uiEventChannel;

        [Header("Preferences")]
        [SerializeField] private GamePrefs _gamePrefs;
        [SerializeField] private InputPrefs _inputPrefs;

        [Header("SO")]
        [SerializeField] private FieldSO _fieldSO;
        [SerializeField] private TetrominoSpawnerSO _tetrominoSpawnerSO;

        [Header("Game Objects")]
        [SerializeField] private SpawnPoint _spawnPoint;
        [SerializeField] private SpawnPoint _nextPoint;
        [SerializeField] private SpawnPoint _holdPoint;

        public static IEnumerator EmptyCoroutine() {
            yield return null;
        }

        private void OnPauseClicked() {
            _player.enabled = false;
        }

        private void OnResumeClicked() {
            _player.enabled = true;
        }

        public void Restart() {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        private void OnGameOver() {
            IsPlaying = false;

            StopCoroutine(_tick);

            CurrentTetromino.IsActive = false;
            _field.Place(CurrentTetromino, fieldUpdate: false);
            Destroy(CurrentTetromino.gameObject);
        }
    }
}