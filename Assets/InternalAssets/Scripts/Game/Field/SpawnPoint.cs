using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Field {
    
    using Minoes;
    using static Minoes.Spawn;

    public class SpawnPoint : MonoBehaviour
    {
        [SerializeField] private Transform _typeA;
        [SerializeField] private Transform _typeB;

        public void Place(Tetromino tetromino) {
            Vector2 pos = GamePrefs.Instance.TetrominoDict[tetromino.Type].Spawn == SPAWN_A ?
                            _typeA.position :
                            _typeB.position;
            tetromino.Place(pos);
        }
    }
}