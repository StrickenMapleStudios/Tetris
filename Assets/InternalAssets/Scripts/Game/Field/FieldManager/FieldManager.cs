using UnityEngine;

namespace Game.Field {

    using Tetrominoes;
    using System.Collections.Generic;
    using static Tetrominoes.Status;
    using System.Collections;

    public class Borders {
        internal int Top => FieldSO.Instance.Height;
        internal int Bottom = 0;
        internal int Left = 0;
        internal int Right => FieldSO.Instance.Width;

        internal int Width => Right - Left;
        internal int Height => Top - Bottom;
    }

    public partial class FieldManager : MonoBehaviour
    {
        public static FieldManager Instance { get; private set; }

        [SerializeField] private Mino _blockedMino;

        [SerializeField] private List<Row> _rows;

        private void OnEnable() {
            Instance = this;

            GameEventChannel.current.OnGameOver.AddListener(BlockField);
        }

        private void OnDisable() {
            GameEventChannel.current.OnGameOver.RemoveListener(BlockField);
        }

        public void Place(Tetromino tetromino, bool fieldUpdate = true) {
            foreach (var mino in tetromino.Minoes) {
                int x = Mathf.RoundToInt(mino.transform.position.x);
                int y = Mathf.RoundToInt(mino.transform.position.y);

                _rows[y].Place(x, mino);
            }
            if (fieldUpdate) { UpdateField(); }
        }

        private void UpdateField() {
            int count = 0;
            for (int i = _rows.Count - 1; i >= 0; --i) {

                if (!_rows[i].IsFilled) continue;

                count++;

                _rows[i].Clear();
                LowerRows(i);
            }
            if (count != 0) {
                GameEventChannel.current.OnRowsFilled.Invoke(count);
            }
        }

        private void LowerRows(int index) {
            for (int i = index + 1; i < _rows.Count; ++i) {
                MoveRow(from: _rows[i], to: _rows[i - 1]);
            }
        }

        private void MoveRow(Row from, Row to) {
            for (int i = 0; i < from.Minoes.Count; ++i) {
                if (from.Minoes[i].Status == FILLED) {
                    to.Place(i, from.Minoes[i]);
                    from.Clear(i);
                }
            }
        }

        internal Status CheckStatus(Vector2 pos) {
            try {
                if (GetMino(pos).Status == FILLED) {
                    return FILLED;
                }
            } catch {
                return ERROR;
            }
            return EMPTY;
        }

        public Mino GetMino(Vector2 pos) {
            pos.x = Mathf.Round(pos.x);
            pos.y = Mathf.Round(pos.y);
            try {
                return _rows[(int) pos.y].Minoes[(int) pos.x];
            } catch {
                return null;
            }
        }

        private void BlockField() {
            StartCoroutine(BlockFieldCoroutine(GamePrefs.Instance.BlockFieldSpeed));
        }

        private IEnumerator BlockFieldCoroutine(float seconds) {
            foreach (var row in _rows) {
                yield return new WaitForSeconds(seconds);

                foreach (var mino in row.Minoes) {
                    mino.ReplaceBy(_blockedMino);
                }
            }
        }
    }
}