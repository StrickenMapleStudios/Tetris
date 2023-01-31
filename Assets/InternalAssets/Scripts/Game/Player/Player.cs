using UnityEngine;
using Input;
using System.Collections;

namespace Game.Player {

    using Tetrominoes;
    
    public partial class Player : MonoBehaviour
    {
        private Tetromino CurrentTetromino => GameManager.Instance.CurrentTetromino;

        private void OnEnable() {
            InputEventChannel.current.OnMove.AddListener(OnMove);
            InputEventChannel.current.OnLower.AddListener(OnLower);
            InputEventChannel.current.OnRotate.AddListener(OnRotate);
            InputEventChannel.current.OnLand.AddListener(OnLand);
            InputEventChannel.current.OnHold.AddListener(OnHold);

            GameEventChannel.current.OnTetrominoActiveStateChanged.AddListener(OnTetrominoActiveStateChanged);
        }

        private void OnDisable() {
            InputEventChannel.current.OnMove.RemoveListener(OnMove);
            InputEventChannel.current.OnLower.RemoveListener(OnLower);
            InputEventChannel.current.OnRotate.RemoveListener(OnRotate);
            InputEventChannel.current.OnLand.RemoveListener(OnLand);
            InputEventChannel.current.OnHold.RemoveListener(OnHold);

            GameEventChannel.current.OnTetrominoActiveStateChanged.RemoveListener(OnTetrominoActiveStateChanged);
        }

        private void OnLand() {
            CurrentTetromino.Land();
        }

        private void OnHold() {
            GameEventChannel.current.OnHoldAction.Invoke();
        }
        
        private void OnTetrominoActiveStateChanged() {
            
            StopAllCoroutines();

            StartCoroutine(ActivateInputCoroutine(.1f));
        }

        private IEnumerator ActivateInputCoroutine(float seconds) {
            yield return new WaitForSeconds(seconds);

            if (CurrentTetromino == null) {
                yield break; }
            
            if (InputEventChannel.current.IsLowering) OnLower(isNewTetromino: true);
            if (InputEventChannel.current.IsMoving) OnMove(InputEventChannel.current.LastDirection);
            if (InputEventChannel.current.IsRotating) OnRotate();
        }
    }
}