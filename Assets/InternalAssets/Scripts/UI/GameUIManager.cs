using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace UI {

    using Game;
    using General;

    public class GameUIManager : MonoBehaviour
    {
        [Header("Labels")]
        [SerializeField] private TextMeshProUGUI _timer;
        [SerializeField] private TextMeshProUGUI _level;
        [SerializeField] private TextMeshProUGUI _rowsCount;
        [SerializeField] private TextMeshProUGUI _score;

        [Header("Buttons")]
        [SerializeField] private Button _pause;

        private void OnEnable() {
            
            GameEventChannel.current.OnLifetimeChanged.AddListener(OnLifetimeChanged);
            GameEventChannel.current.OnLevelChanged.AddListener(OnLevelChanged);
            GameEventChannel.current.OnScoreChanged.AddListener(OnScoreChanged);
            GameEventChannel.current.OnRowsCountChanged.AddListener(OnRowsCountChanged);

            _pause.onClick.AddListener(OnPauseClicked);
        }

        private void OnDisable() {
            GameEventChannel.current.OnLifetimeChanged.RemoveListener(OnLifetimeChanged);
            GameEventChannel.current.OnLevelChanged.RemoveListener(OnLevelChanged);
            GameEventChannel.current.OnScoreChanged.RemoveListener(OnScoreChanged);
            GameEventChannel.current.OnRowsCountChanged.RemoveListener(OnRowsCountChanged);

            _pause.onClick.RemoveListener(OnPauseClicked);
        }

        private void Start() {
            OnLevelChanged();
            OnScoreChanged();
            OnRowsCountChanged();
        }

        private void OnLifetimeChanged() {
            _timer.text = Helper.FormatTime(GameManager.Instance.Lifetime, milliseconds: false);
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
            UIEventChannel.current.OnPauseClicked.Invoke();
        }

    }
}