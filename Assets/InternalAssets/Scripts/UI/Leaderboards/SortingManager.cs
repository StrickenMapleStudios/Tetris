using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Leaderboards {
    
    using static Order;

    public partial class LeaderboardsManager
    {
        [Header("SortingButtons")]
        [SerializeField] private Button _name;
        [SerializeField] private Button _score;
        [SerializeField] private Button _level;
        [SerializeField] private Button _lifetime;

        private void OnNameClicked() {
            SortBy(NAME);
        }

        private void OnScoreClicked() {
            SortBy(SCORE);
        }

        private void OnLevelClicked() {
            SortBy(LEVEL);
        }

        private void OnLifetimeClicked() {
            SortBy(LIFETIME);
        }
    }
}