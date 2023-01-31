using System.Collections.Generic;
using UnityEngine;

namespace Game.Minoes {

    public class Locator : MonoBehaviour
    {
        [field: SerializeField] public List<Point> Points { get; private set; }

        public void Rotate() {
            transform.Rotate(0,0,-90);
        }

        public bool Check() {

            foreach (var point in Points) {
                if (GameManager.Instance.CheckStatus(point.transform.position) != Status.EMPTY) {
                    return false;
                }
            }
            return true;
        }

        public void Reset() {
            transform.position = transform.parent.position;
            transform.rotation = transform.parent.rotation;
        }
    }
}