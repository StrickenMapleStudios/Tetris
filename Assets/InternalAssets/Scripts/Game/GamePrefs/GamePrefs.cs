using System.Collections.Generic;
using UnityEngine;

namespace Game {
    using Tetrominoes;

    [CreateAssetMenu(fileName = "GamePrefs", menuName = "Prefs/GamePrefs")]
    public class GamePrefs : ScriptableObject
    {
        public static GamePrefs Instance { get; private set; }

        [field: Header("Preferences")]
        [field: SerializeField] public float TickRate { get; private set; }
        [field: SerializeField] public float SpeedUpForLevel { get; private set; }
        [field: SerializeField] public float LandTick { get; private set; }
        [field: SerializeField] public float BlockFieldSpeed { get; private set; }

        [Header("")]
        [SerializeField] private List<TetrominoSO> tetrominoes;

        public Dictionary<TetrominoType, TetrominoSO> TetrominoDict { get; private set; } = new Dictionary<TetrominoType, TetrominoSO>();

        private void OnEnable() {
            Instance = this;

            foreach (var tetromino in tetrominoes) {
                TetrominoDict[tetromino.Type] = tetromino;
            }
        }
    }
}