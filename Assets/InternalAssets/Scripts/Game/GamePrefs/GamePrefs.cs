using System.Collections.Generic;
using UnityEngine;

namespace Game {
    using Minoes;

    [CreateAssetMenu(fileName = "GamePrefs", menuName = "Prefs/GamePrefs")]
    public class GamePrefs : ScriptableObject
    {
        public static GamePrefs Instance { get; private set; }

        [field: Header("Preferences")]
        [field: SerializeField] public float TimerAcc { get; private set; }
        [field: SerializeField] public float TickRate { get; private set; }
        [field: SerializeField] public float SpeedUpForLevel { get; private set; }
        [field: SerializeField] public float LandTick { get; private set; }
        [field: SerializeField] public float BlockFieldSpeed { get; private set; }

        [field: Header("Options")]
        [field: SerializeField] public float GeneralVolume { get; set; } = 1;
        [field: SerializeField] public float FXVolume { get; set; } = 1;
        [field: SerializeField] public float MusicVolume { get; set; } = 1;

        [field: SerializeField] public bool ShowAnimations { get; set; } = true;
        [field: SerializeField] public bool ShowGhostPiece { get; set; } = true;

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