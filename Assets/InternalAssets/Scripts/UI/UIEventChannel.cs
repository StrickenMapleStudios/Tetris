using UnityEngine;
using UnityEngine.Events;

namespace UI {

    [CreateAssetMenu(fileName = "UIEventChannel", menuName = "Channels/UIEventChannel")]
    public class UIEventChannel : ScriptableObject
    {
        public static UIEventChannel Instance { get; private set; }

        public UnityEvent OnBGColorChanged = new UnityEvent();

        private void OnEnable() {
            Instance = this;
        }
    }
}