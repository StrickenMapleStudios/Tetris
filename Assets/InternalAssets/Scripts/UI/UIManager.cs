using UnityEngine;
using TMPro;

namespace UI {

    using Game;
    
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _level;
        [SerializeField] private TextMeshProUGUI _rowsCount;
        [SerializeField] private TextMeshProUGUI _score;

        private void OnEnable() {
            GameEventChannel.current.OnLevelChanged.AddListener(OnLevelChanged);
            GameEventChannel.current.OnScoreChanged.AddListener(OnScoreChanged);
            GameEventChannel.current.OnRowsCountChanged.AddListener(OnRowsCountChanged);            
        }

        private void OnDisable() {
            GameEventChannel.current.OnLevelChanged.RemoveListener(OnLevelChanged);
            GameEventChannel.current.OnScoreChanged.RemoveListener(OnScoreChanged);
            GameEventChannel.current.OnRowsCountChanged.RemoveListener(OnRowsCountChanged);
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
            Application.Quit();
        }
    }
}