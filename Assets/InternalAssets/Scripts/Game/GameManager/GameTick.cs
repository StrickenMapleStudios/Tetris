using System.Collections;
using UnityEngine;

namespace Game {

    public partial class GameManager
    {
        private IEnumerator _tick = EmptyCoroutine();

        private void StartTickCoroutine() {
            StopCoroutine(_tick);
            _tick = Tick();
            StartCoroutine(_tick);
        }
        
        private IEnumerator Tick() {
            while (true) {
                yield return new WaitForSeconds(_gamePrefs.TickRate - Level * _gamePrefs.SpeedUpForLevel);
                GameEventChannel.current.OnTick.Invoke();
            }
        }

        private void OnTick() {
            CurrentTetromino.OnTick();
        }
    }
}