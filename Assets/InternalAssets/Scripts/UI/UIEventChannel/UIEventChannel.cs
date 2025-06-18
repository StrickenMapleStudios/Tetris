using UnityEngine;
using UnityEngine.Events;

namespace UI {

    using Input;

    [CreateAssetMenu(fileName = "UIEventChannel", menuName = "Channels/UIEventChannel")]
    public class UIEventChannel : ScriptableObject
    {
        public static UIEventChannel current { get; private set; }

        public UnityEvent OnEscape = new UnityEvent();

        public UnityEvent OnResumeClicked = new UnityEvent();

        private void OnEnable() {
            current = this;

            InputEventChannel.current.OnEscape.AddListener(Escape);
        }

        private void OnDisable() {
            InputEventChannel.current.OnEscape.RemoveListener(Escape);
        }

        private void Escape() {
            OnEscape.Invoke();
        }
    }
}