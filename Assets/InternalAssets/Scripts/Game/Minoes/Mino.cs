using UnityEngine;

namespace Game.Minoes {

    using static Status;
    using static TetrominoType;
    
    public enum Status {
        EMPTY,
        FILLED,
        ERROR,
        BLOCKED
    }

    [RequireComponent(typeof(SpriteRenderer))]
    public class Mino : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _renderer;

        [field: SerializeField] public Status Status { get; private set; } = EMPTY;
        [field: SerializeField] public TetrominoType Type { get; private set; } = BASE;

        public Sprite Sprite {
            get => _renderer.sprite;
            set => _renderer.sprite = value;
        }

        public Material Material {
            get => _renderer.sharedMaterial;
            set => _renderer.material = value;
        }

        public void UpdateStatus(TetrominoType type) {
            Type = type;
            Status = type == BASE ? EMPTY : FILLED;
            //_renderer.material.color = GamePrefs.Instance.TetrominoDict[type].Color;
            //_renderer.color = GamePrefs.Instance.TetrominoDict[type].Color;
            Material = GamePrefs.Instance.TetrominoDict[type].Material;
        }

        public void ReplaceBy(Mino mino) {
            Type = mino.Type;
            Status = mino.Status;
            Sprite = mino.Sprite;
            Material = mino.Material;
        }

        public void Clear() {
            Type = BASE;
            Status = EMPTY;
            Material = GamePrefs.Instance.TetrominoDict[Type].Material;
        }
    }
}