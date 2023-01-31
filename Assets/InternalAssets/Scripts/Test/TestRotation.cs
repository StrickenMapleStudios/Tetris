using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Test {

    public class TestRotation : MonoBehaviour
    {
        [SerializeField] private Transform normal, rotated;

        private void Start() {
            Debug.Log(normal.position);
            Debug.Log(rotated.position);
            Dictionary<Vector2, Transform> dict = new Dictionary<Vector2, Transform>();
            dict[normal.position] = normal;
            Debug.Log(dict[rotated.position]);
        }
    }
}
