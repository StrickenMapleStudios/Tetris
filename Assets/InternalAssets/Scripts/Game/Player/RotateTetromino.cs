using UnityEngine;
using Input;
using System.Collections;

namespace Game.Player {
    
    using Tetrominoes;

    public partial class Player
    {
        private IEnumerator _rotate = GameManager.EmptyCoroutine();

        private void OnRotate() {
            StopCoroutine(_rotate);

            if (!CurrentTetromino.IsActive) return;
            Rotate(CurrentTetromino);
            
            _rotate = RotateCoroutine();
            StartCoroutine(_rotate);
        }

        private IEnumerator RotateCoroutine() {
            
            yield return new WaitForSeconds(InputPrefs.Instance.TimeToHold);

            while (CurrentTetromino.IsActive && InputEventChannel.current.IsRotating) {
                Rotate(CurrentTetromino);
                yield return new WaitForSeconds(InputPrefs.Instance.TimeToUpdatePress);
            }
        }

        private void Rotate(Tetromino tetromino) {
            tetromino.TryRotate();
        }
    }
}