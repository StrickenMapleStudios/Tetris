using System.Collections.Generic;
using UnityEngine;

namespace Game.Minoes {

    [CreateAssetMenu(fileName = "TetrominoSpawner", menuName = "SO/TetrominoSpawner")]
    public class TetrominoSpawnerSO : ScriptableObject
    {
        public static TetrominoSpawnerSO Instance { get; private set; }

        [SerializeField] private List<Tetromino> _tetrominoes;
        
        private void OnEnable() {
            Instance = this;
        }

        public Tetromino GetRandomTetromino() {
            return _tetrominoes[Random.Range(0, _tetrominoes.Count)];
        }
    }
}