using System.Collections.Generic;
using UnityEngine;

namespace Game.Field {

    using Tetrominoes;
    using static Tetrominoes.Status;

    public class Row : MonoBehaviour
    {
        [field: SerializeField] public List<Mino> Minoes { get; private set; }

        private int filledCount;

        public bool IsFilled => filledCount == Minoes.Count;

        private void Start() {
            filledCount = 0;
        }

        public void Place(int i, Mino mino) {
            var status = Minoes[i].Status;
            Minoes[i].ReplaceBy(mino);
            if (mino.Status == FILLED && status != FILLED) {
                filledCount++;
            }
        }

        public void Clear() {
            foreach (var mino in Minoes) {
                mino.Clear();
            }
            filledCount = 0;
        }

        public void Clear(int index) {
            if (Minoes[index].Status == FILLED) { filledCount--; }
            Minoes[index].Clear();
        }
    }
}