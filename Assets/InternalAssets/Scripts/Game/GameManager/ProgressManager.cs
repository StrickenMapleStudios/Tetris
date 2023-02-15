using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game {

    public partial class GameManager
    {
        [SerializeField] private float _lifetime = 0;
        [SerializeField] private int _level = 1;
        [SerializeField] private int _score = 0;
        [SerializeField] private int _rowsCount = 0;

        public float Lifetime {
            get => _lifetime;
            private set {
                _lifetime = value;
                _gameEventChannel.OnLifetimeChanged.Invoke();
            }
        }

        public int Level {
            get => _level;
            private set {
                _level = value;
                _gameEventChannel.OnLevelChanged.Invoke();
            }
        }

        public int Score {
            get => _score;
            private set {
                _score = value;
                _gameEventChannel.OnScoreChanged.Invoke();
            }
        }

        public int RowsCount {
            get => _rowsCount;
            private set {
                _rowsCount = value;
                _gameEventChannel.OnRowsCountChanged.Invoke();
            }
        }

        private IEnumerator Timer(float time) {
            while (IsPlaying) {
                yield return new WaitForSeconds(time);
                Lifetime += Time.deltaTime;
            }
        }

        private void OnRowsFilled(int count) {

            RowsCount += count;
            
            //Checks if rows count reaches another 10
            if (RowsCount % 10 < count) {
                Level++;
            }

            int pts = 0;

            switch (count) {
                case 1: pts = 40; break;
                case 2: pts = 100; break;
                case 3: pts = 300; break;
                case 4: pts = 1200; break;
            }

            pts *= Level;

            Score += pts;
        }
    }
}
