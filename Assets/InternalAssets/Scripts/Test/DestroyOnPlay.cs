using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Test {

    public class DestroyOnPlay : MonoBehaviour
    {
        private void OnEnable() {
            Destroy(gameObject);
        }
    }
}