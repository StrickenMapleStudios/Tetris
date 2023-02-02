using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace UI {

    using Game;
    using UnityEngine.SceneManagement;

    public class UIManager : MonoBehaviour
    {
        [Header("Labels")]
        [SerializeField] private TextMeshProUGUI _level;
        [SerializeField] private TextMeshProUGUI _rowsCount;
        [SerializeField] private TextMeshProUGUI _score;

        [Header("Buttons")]
        [SerializeField] private Button _pause;
        [SerializeField] private Button _restart;
        [SerializeField] private Button _exit;

        private void OnEnable() {
            GameEventChannel.current.OnLevelChanged.AddListener(OnLevelChanged);
            GameEventChannel.current.OnScoreChanged.AddListener(OnScoreChanged);
            GameEventChannel.current.OnRowsCountChanged.AddListener(OnRowsCountChanged);

            _pause.onClick.AddListener(OnPauseClicked);
            _restart.onClick.AddListener(OnRestartClicked);
            _exit.onClick.AddListener(OnExitClicked);
        }

        private void OnDisable() {
            GameEventChannel.current.OnLevelChanged.RemoveListener(OnLevelChanged);
            GameEventChannel.current.OnScoreChanged.RemoveListener(OnScoreChanged);
            GameEventChannel.current.OnRowsCountChanged.RemoveListener(OnRowsCountChanged);

            _pause.onClick.RemoveListener(OnPauseClicked);
            _restart.onClick.RemoveListener(OnRestartClicked);
            _exit.onClick.RemoveListener(OnExitClicked);
        }

        private void Start() {
            OnLevelChanged();
            OnScoreChanged();
            OnRowsCountChanged();
        }

        private void OnLevelChanged() {
            _level.text = $"{GameManager.Instance.Level}";
        }

        private void OnScoreChanged() {
            _score.text = $"{GameManager.Instance.Score}";
        }

        private void OnRowsCountChanged() {
            _rowsCount.text = $"{GameManager.Instance.RowsCount}";
        }

        public void OnPauseClicked() {
            Time.timeScale = Time.timeScale == 0 ? 1 : 0;
        }

        public void OnRestartClicked() {
            GameManager.Instance.Restart();
        }

        public void OnExitClicked() {
            SceneManager.LoadScene("Menu");
        }
    }
}