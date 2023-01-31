using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Field {

    using Minoes;

    public partial class FieldManager
    {
        // private void InitMinoes() {
        //     foreach (var mino in _minoes) {
        //         var pos = (Vector2) mino.transform.position;
        //         pos.x = Mathf.Round(pos.x);
        //         pos.y = Mathf.Round(pos.y);
        //         field[pos] = mino;
        //     }
        // }

        // private void InitRows() {
        //     _rows = new List<Row>();

        //     for (float y = Borders.Bottom; y < Borders.Height; ++y) {
        //         var row = Instantiate(_rowPrefab, new Vector2(-1, y), Quaternion.identity, _rowParent);

        //         for (float x = Borders.Left; x < Borders.Right; ++x) {
        //             row.Add(field[new Vector2(x,y)]);
        //         }
        //         _rows.Add(row);
        //     }
        // }

        // private void CreateRows() {
        //     _rows = new List<Row>();

        //     var row = Instantiate(_rowPrefab, Vector2.zero, Quaternion.identity, _rowParent);

        //     for (int x = Borders.Left; x < Borders.Right; ++x) {
        //         var mino = Instantiate(_minoPrefab, new Vector2(x, 0), Quaternion.identity, row.transform);
        //         row.Add(mino);
        //     }

        //     _rows.Add(row);

        //     for (int y = Borders.Bottom + 1; y < Borders.Top; y++) {
        //         _rows.Add(Instantiate(row, new Vector2(0, y), Quaternion.identity, _rowParent));
        //     }
        // }

        // private void Start() {
        //     InitMinoes();
        //     InitRows();

        //     CreateRows();
        // }
    }
}