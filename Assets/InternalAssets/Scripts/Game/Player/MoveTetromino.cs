using UnityEngine;
using Input;
using System.Collections;

namespace Game.Player {
    
    using Tetrominoes;

    public partial class Player
    {
        private IEnumerator _move = GameManager.EmptyCoroutine();

        private void OnMove(int direction) {

            StopCoroutine(_move);

            if (!CurrentTetromino.IsActive) return;
            Move(CurrentTetromino, direction);

            _move = MoveCoroutine(CurrentTetromino, direction);
            StartCoroutine(_move);
        }

        private IEnumerator MoveCoroutine(Tetromino tetromino, int direction) {

            yield return new WaitForSeconds(InputPrefs.Instance.TimeToHold);

            while (CurrentTetromino.IsActive && InputEventChannel.current.IsMoving) {
                Move(tetromino, direction);
                yield return new WaitForSeconds(InputPrefs.Instance.TimeToUpdatePress);
            }
        }

        private void Move(Tetromino tetromino, int direction) {
            tetromino.TryMove(direction);
        }
    }
}