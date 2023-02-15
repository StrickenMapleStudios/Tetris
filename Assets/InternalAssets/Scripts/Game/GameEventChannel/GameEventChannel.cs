using UnityEngine;
using UnityEngine.Events;

namespace Game {

    [CreateAssetMenu(fileName = "GameEventChannel", menuName = "Channels/GameEventChannel")]
    public class GameEventChannel : ScriptableObject
    {
        public static GameEventChannel current { get; private set; }

        //Event invoked every tick
        public UnityEvent OnTick = new UnityEvent();

        //Event invoked when current tetromino is landed
        public UnityEvent OnLand = new UnityEvent();

        //Event invoked when hold action
        public UnityEvent OnHoldAction = new UnityEvent();

        //Event invoked when tetromino changes its active state
        public UnityEvent OnTetrominoActiveStateChanged = new UnityEvent();

        public UnityEvent<int> OnRowsFilled = new UnityEvent<int>();

        public UnityEvent OnRowCleared = new UnityEvent();

        public UnityEvent OnRowsCountChanged = new UnityEvent();

        public UnityEvent OnLifetimeChanged = new UnityEvent();

        public UnityEvent OnLevelChanged = new UnityEvent();

        public UnityEvent OnScoreChanged = new UnityEvent();

        public UnityEvent OnGameOver = new UnityEvent();

        public UnityEvent<string> OnSaveResult = new UnityEvent<string>();
        
        private void OnEnable() {
            current = this;
        }

        public void RowsFilled(int count) {
            OnRowsFilled.Invoke(count);
        }

        public void SaveResult(string name) {
            OnSaveResult.Invoke(name);
        }
    }
}