using UnityEngine;

namespace Game.Field {

    using Minoes;

    public class TetrominoSpawner : MonoBehaviour
    {
        [SerializeField] private SpawnPoint _spawnPoint, _nextSpawnPoint;


        public Tetromino SpawnTetromino() {
            var prefab = TetrominoSpawnerSO.Instance.GetRandomTetromino();
            var tetromino = Instantiate(prefab, _nextSpawnPoint.transform.position, Quaternion.identity, transform);
            
            //_nextSpawnPoint.Place(tetromino);
            return tetromino;
        }

        public void Place(Tetromino tetromino) {
            _spawnPoint.Place(tetromino);
        }
    }
}