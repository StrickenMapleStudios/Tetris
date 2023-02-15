using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Leaderboards {

    using Game.Data;
    using UnityEngine.SceneManagement;
    using static Order;

    public enum Order {
        NAME,
        SCORE,
        LEVEL,
        LIFETIME
    }

    public partial class LeaderboardsManager : MonoBehaviour
    {
        [Header("UI")]
        [SerializeField] private WarningManager _warning;

        [Header("Containers")]
        [SerializeField] private LeaderboardsRow _row;
        [SerializeField] private Transform _container;

        [Header("Buttons")]
        [SerializeField] private Button _reset;
        [SerializeField] private Button _ok;

        private List<Result> _results;
        
        private void OnEnable() {

            _name.onClick.AddListener(OnNameClicked);
            _score.onClick.AddListener(OnScoreClicked);
            _level.onClick.AddListener(OnLevelClicked);
            _lifetime.onClick.AddListener(OnLifetimeClicked);

            _reset.onClick.AddListener(OnResetClicked);
            _ok.onClick.AddListener(OnOkClicked);
        }

        private void OnDisable() {
            _name.onClick.RemoveListener(OnNameClicked);
            _score.onClick.RemoveListener(OnScoreClicked);
            _level.onClick.RemoveListener(OnLevelClicked);
            _lifetime.onClick.RemoveListener(OnLifetimeClicked);

            _reset.onClick.RemoveListener(OnResetClicked);
            _ok.onClick.RemoveListener(OnOkClicked);
        }

        private void Start() {
            SortBy(SCORE);
        }

        private void UpdateResults() {
            var leaderboards = SaveSystem.GetLeaderboards();
            _results = leaderboards.Results;
        }

        private void UpdateTable() {
            Clear();

            for (int i = 0; i < _results.Count; ++i) {
                LeaderboardsRow row = Instantiate(_row, Vector3.zero, Quaternion.identity, _container);
                
                row.UpdateRow(i+1, _results[i]);
            }
        }

        private void SortBy(Order order) {

            UpdateResults();

            switch (order) {
                case NAME: _results.Sort((r1,r2) => r1.Name.CompareTo(r2.Name)); break;
                case SCORE: _results.Sort((r2,r1) => r1.Score.CompareTo(r2.Score)); break;
                case LEVEL: _results.Sort((r2,r1) => r1.Level.CompareTo(r2.Level)); break;
                case LIFETIME: _results.Sort((r2,r1) => r1.Lifetime.CompareTo(r2.Lifetime)); break;
            }

            UpdateTable();
        }

        private void Clear() {
            foreach (Transform row in _container) {
                Destroy(row.gameObject);
            }
        }


        private void OnResetClicked() {
            _warning.gameObject.SetActive(true);
        }

        private void OnOkClicked() {
            SceneManager.LoadScene("Menu");
        }
    }
}