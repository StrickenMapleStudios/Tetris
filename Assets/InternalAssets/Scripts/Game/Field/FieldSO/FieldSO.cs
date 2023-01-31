using UnityEngine;

namespace Game.Field {

    [CreateAssetMenu(fileName = "Field", menuName = "SO/Field")]
    public class FieldSO : ScriptableObject
    {
        public static FieldSO Instance { get; private set; }

        [field: SerializeField] public int Width { get; private set; }
        [field: SerializeField] public int Height { get; private set; }

        private void OnEnable() {
            Instance = this;
        }
    }
}