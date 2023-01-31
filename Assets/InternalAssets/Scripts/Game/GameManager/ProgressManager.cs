using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game {

    public partial class GameManager
    {
        [SerializeField] private int _level = 0;
        private int _score = 0;
        private int _rowsCount = 0;

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

            pts *= (Level + 1);

            Score += pts;
        }
    }
}
