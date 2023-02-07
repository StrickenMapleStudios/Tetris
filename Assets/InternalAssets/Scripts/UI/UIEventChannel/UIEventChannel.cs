using UnityEngine;
using UnityEngine.Events;

namespace UI {

    [CreateAssetMenu(fileName = "UIEventChannel", menuName = "Channels/UIEventChannel")]
    public class UIEventChannel : ScriptableObject
    {
        public static UIEventChannel current { get; private set; }

        public UnityEvent OnPauseClicked = new UnityEvent();

        public UnityEvent OnResumeClicked = new UnityEvent();

        private void OnEnable() {
            current = this;
        }
    }
}