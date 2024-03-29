using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace Input {

    using Game;

    [CreateAssetMenu(fileName = "InputEventChannel", menuName = "Channels/InputEventChannel")]
    public class InputEventChannel : ScriptableObject
    {
        public static InputEventChannel current { get; private set; }

        public UnityEvent<int> OnMove = new UnityEvent<int>();
        public UnityEvent OnLower = new UnityEvent();
        public UnityEvent OnLand = new UnityEvent();
        public UnityEvent OnRotate = new UnityEvent();
        public UnityEvent OnHold = new UnityEvent();

        public bool IsMoving { get; private set; } = false;
        public bool IsLowering { get; private set; } = false;
        public bool IsRotating { get; private set; } = false;

        public int LastDirection { get; private set; }

        private void OnEnable() {
            current = this;
        }

        private void OnDisable() {
            IsMoving = false;
            IsLowering = false;
            IsRotating = false;
        }

        public void OnMoveInput(InputAction.CallbackContext context) {

            if (!CheckActive()) {
                IsMoving = false;
                return;
            }

            if (context.started) {
                LastDirection = (int) context.ReadValue<float>();
                OnMove.Invoke(LastDirection);
            }
            IsMoving = !context.canceled;
        }

        public void OnLowerInput(InputAction.CallbackContext context) {

            if (context.started) {
                OnLower.Invoke();
            }
            
            IsLowering = !context.canceled;
        }

        public void OnLandInput(InputAction.CallbackContext context) {
            
            if (context.started) {
                OnLand.Invoke();
            }
        }

        public void OnRotateInput(InputAction.CallbackContext context) {

            if (context.started) {
                OnRotate.Invoke();
            }

            IsRotating = !context.canceled;
        }

        public void OnHoldInput(InputAction.CallbackContext context) {
            if (context.started) {
                OnHold.Invoke();
            }
        }

        public bool CheckActive() {
            return GameManager.Instance.CheckActive();
        }
    }
}