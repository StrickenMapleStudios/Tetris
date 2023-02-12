using UnityEngine;

namespace Input {

    [CreateAssetMenu(fileName = "InputPrefs", menuName = "Prefs/InputPrefs")]
    public class InputPrefs : ScriptableObject
    {
        public static InputPrefs Instance { get; private set; }

        [field: SerializeField] public float TimeToHold { get; private set; }
        [field: SerializeField] public float TimeToUpdatePress { get; private set; }

        [field: Header("Gamepad prefs")]
        [field: SerializeField] public float Deadzone { get; private set; }

        private void OnEnable() {
            Instance = this;
        }
    }
}