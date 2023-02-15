using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace UI.Leaderboards {
    
    using Game.Data;
    using General;

    public class LeaderboardsRow : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _number, _name, _score, _level, _lifetime;

        public void UpdateRow(int number, Result result) {
            _number.text = $"{number}";
            _name.text = result.Name;
            _score.text = $"{result.Score}";
            _level.text = $"{result.Level}";
            _lifetime.text = Helper.FormatTime(result.Lifetime);
        }
    }
}