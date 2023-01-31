using UnityEngine;
using Input;

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

        public void Restart() {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        private void OnGameOver() {
            CurrentTetromino.IsActive = false;
            _field.Place(CurrentTetromino, fieldUpdate: false);
            Destroy(CurrentTetromino.gameObject);
            Debug.Log("Game Over!");
            StopCoroutine(_tick);
        }
    }
}