using UnityEngine;
using Input;
using System.Collections;

namespace Game.Player {
    
    using Minoes;

    public partial class Player
    {
        private IEnumerator _lower = GameManager.EmptyCoroutine();

        private void OnLower() {
            OnLower(isNewTetromino: false);
        }

        private void OnLower(bool isNewTetromino = false) {
            StopCoroutine(_lower);
            if (!CurrentTetromino.IsActive) return;

            if (!isNewTetromino) {
                Lower(CurrentTetromino);
            }
            
            _lower = LowerCoroutine(CurrentTetromino);
            StartCoroutine(_lower);
        }

        private IEnumerator LowerCoroutine(Tetromino tetromino) {

            yield return new WaitForSeconds(InputPrefs.Instance.TimeToHold);

            while (CurrentTetromino.IsActive && InputEventChannel.current.IsLowering) {
                Lower(tetromino);
                yield return new WaitForSeconds(InputPrefs.Instance.TimeToUpdatePress);
            }
        }

        private void Lower(Tetromino tetromino) {
            tetromino.TryLower();
        }
    }
}