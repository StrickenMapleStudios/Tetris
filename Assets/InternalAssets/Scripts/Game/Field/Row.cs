using System.Collections.Generic;
using UnityEngine;

namespace Game.Field {

    using Minoes;
    using static Minoes.Status;
    using static RowState;

    public enum RowState {
        UPDATED,
        NOT_UPDATED
    }

    public class Row : MonoBehaviour
    {
        [field: SerializeField] public List<Mino> Minoes { get; private set; }
        [SerializeField] private Animator _animator;

        private int filledCount;

        public bool IsFilled => filledCount == Minoes.Count;

        public RowState State { get; set; } = UPDATED;

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

        public void Light(int value = 1) {
            _animator.enabled = value != 0 ? true: false;
        }

        public void Clear() {
            if (!IsFilled) return;

            foreach (var mino in Minoes) {
                mino.Clear();
            }
            filledCount = 0;
            State = NOT_UPDATED;

            GameEventChannel.current.OnRowCleared.Invoke();
        }

        public void Clear(int index) {
            if (Minoes[index].Status == FILLED) { filledCount--; }
            Minoes[index].Clear();
        }
    }
}