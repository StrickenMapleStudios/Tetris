using UnityEngine;

namespace Game.Minoes {

    [CreateAssetMenu(fileName = "Tetromino", menuName = "SO/Tetromino")]
    public class TetrominoSO : ScriptableObject
    {
        [field: SerializeField] public TetrominoType Type { get; private set; }
        [field: SerializeField] public Spawn Spawn { get; private set; }
        [field: SerializeField] public Material Material { get; private set; }
    }
}