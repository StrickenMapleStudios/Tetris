using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Minoes {

    public enum TetrominoType {
        I, J, L, O, S, T, Z, BASE
    }

    public enum Spawn {
        SPAWN_A,
        SPAWN_B
    }

    public class Tetromino : MonoBehaviour
    {
        [Header("VFX")]
        [SerializeField] private Animator _trail;
        [SerializeField] private ParticleSystem _dust;

        [field: Header("Parameters")]
        [field: SerializeField] public TetrominoType Type { get; private set; }

        [Header("Children")]
        [SerializeField] private SpriteRenderer _renderer;
        [SerializeField] private Locator _moveLocator;
        [SerializeField] private Locator _lowerLocator;
        [SerializeField] private Locator _rotateLocator;
        [SerializeField] private Locator _previewLocator;


        [field: SerializeField] public List<Mino> Minoes { get; private set; }

        private Material _material => GamePrefs.Instance.TetrominoDict[Type].Material;

        private bool _isActive = false;

        public bool IsActive {
            get => _isActive;
            set {
                if (_isActive != value) {

                    _isActive = value;
                    GameEventChannel.current.OnTetrominoActiveStateChanged.Invoke();
                }
                if (_isActive) {
                    if (CheckSpawn()) { UpdateLandPreview(); }
                    else { GameEventChannel.current.OnGameOver.Invoke(); }
                } else {
                    _previewLocator.Reset();
                }
            }
        }

        private void OnEnable() {

            for (int i = 0; i < Minoes.Count; ++i) {

                Minoes[i].UpdateStatus(Type);
                
                _moveLocator.Points[i].transform.position = Minoes[i].transform.position;
                _lowerLocator.Points[i].transform.position = Minoes[i].transform.position;
                _rotateLocator.Points[i].transform.position = Minoes[i].transform.position;
                _previewLocator.Points[i].transform.position = Minoes[i].transform.position;
                _previewLocator.Points[i].UpdateMaterial(_material);

                var renderer = _previewLocator.Points[i].GetComponent<SpriteRenderer>();
            }
        }

        private void OnDisable() {
            IsActive = false;
        }

        internal void Place(Vector2 pos) {
            transform.position = pos;
        }

        internal void TryMove(int direction) {
            
            if (!IsActive) return;

            _moveLocator.Reset();
            _moveLocator.transform.position += Vector3.right * direction;

            if (!_moveLocator.Check()) return;
            transform.position += Vector3.right * direction;

            UpdateLandPreview();
        }

        internal void TryRotate() {

            if (!IsActive) return;

            _rotateLocator.Reset();

            _rotateLocator.Rotate();
            if (!_rotateLocator.Check()) return;

            transform.Rotate(0, 0, -90);
            foreach (var mino in Minoes) {
                mino.transform.Rotate(0, 0, 90);
            }

            UpdateLandPreview();
        }

        internal bool TryLower(bool forceMode = false) {

            if (!forceMode && !IsActive) return false;

            _lowerLocator.Reset();

            _lowerLocator.transform.position += Vector3.down;

            if (!_lowerLocator.Check()) {
                IsActive = false;
                GameEventChannel.current.OnLand.Invoke();
                return false;
            }

            transform.position += Vector3.down;
            
            if (!forceMode) { UpdateLandPreview(); }
            return true;
        }

        internal bool CheckSpawn() {
            _lowerLocator.Reset();

            return _lowerLocator.Check();
        }

        internal void UpdateLandPreview() {
            _previewLocator.Reset();
            do {
                _previewLocator.transform.position += Vector3.down;
            } while (_previewLocator.Check());
            _previewLocator.transform.position += Vector3.up;
        }

        internal void Land() {
            if (!IsActive) { return; }

            IsActive = false;

            UpdateLandPreview();
            _previewLocator.gameObject.SetActive(false);
            float height = transform.position.y - _previewLocator.transform.position.y;
            transform.position = _previewLocator.transform.position;
            
            CreateVFX(height);

            GameEventChannel.current.OnLand.Invoke();

            //StartCoroutine(LandCoroutine(GamePrefs.Instance.LandTick));
        }

        private void CreateVFX(float height) {

            var pos = _renderer.bounds.center;
            float width;

            if (transform.rotation.z % 180 <= 1) {
                width = _renderer.bounds.size.x;
                pos.y -= _renderer.bounds.extents.y;
            } else {
                width = _renderer.bounds.size.y;
                pos.y -= _renderer.bounds.extents.x;
            }

            var pos1 = new Vector2(pos.x, transform.position.y + height / 2);
            ParticleSystem dust = Instantiate(_dust, pos1, Quaternion.identity);

            Animator vfx = Instantiate(_trail, pos, Quaternion.identity);
            vfx.transform.localScale = new Vector2(width, height);

            
        }

        private IEnumerator LandCoroutine(float time) {

            while (TryLower(forceMode: true)) {

                UpdateLandPreview();
                yield return new WaitForSeconds(time);
            }
        }

        public void OnTick() {
            TryLower();
        }

        public void ResetRotation() {
            transform.rotation = Quaternion.Euler(0,0,0);
            foreach (var mino in Minoes) {
                mino.transform.rotation = Quaternion.Euler(0,0,0);
            }
        }
    }
}