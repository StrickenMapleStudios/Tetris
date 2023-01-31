using UnityEngine;

namespace Game {
    using System.Collections;
    using Field;
    using Tetrominoes;

    public partial class GameManager
    {
        public static GameManager Instance { get; private set; }

        [Header("GAME BEHAVIOUR")]
        [SerializeField] private FieldManager _field;
        [SerializeField] private TetrominoSpawner _spawner;
        [SerializeField] private Player.Player _player;

        private Tetromino _currentTetromino;
        private Tetromino _nextTetromino;
        private Tetromino _holdenTetromino;

        private bool _holdCooldown = false;

        public Tetromino CurrentTetromino {
            get => _currentTetromino;
            private set {
                _currentTetromino = value;
                _spawner.Place(_currentTetromino);
                _currentTetromino.IsActive = true;
            }
        }

        private Tetromino HoldenTetromino {
            get => _holdenTetromino;
            set {
                _holdenTetromino = value;
                _holdenTetromino.IsActive = false;
                _holdenTetromino.ResetRotation();
                _holdenTetromino.Place(_holdPoint.transform.position);
            }
        }

        private void OnEnable() {
            Instance = this;

            GameEventChannel.current.OnTick.AddListener(OnTick);
            GameEventChannel.current.OnLand.AddListener(OnLand);
            GameEventChannel.current.OnHoldAction.AddListener(OnHoldAction);

            GameEventChannel.current.OnRowsFilled.AddListener(OnRowsFilled);
            GameEventChannel.current.OnGameOver.AddListener(OnGameOver);
        }

        private void OnDisable() {
            GameEventChannel.current.OnTick.RemoveListener(OnTick);
            GameEventChannel.current.OnLand.RemoveListener(OnLand);
            GameEventChannel.current.OnHoldAction.RemoveListener(OnHoldAction);

            GameEventChannel.current.OnRowsFilled.RemoveListener(OnRowsFilled);
            GameEventChannel.current.OnGameOver.RemoveListener(OnGameOver);
        }

        private void Start() {
            StartCoroutine(StartGame(0));
        }

        private IEnumerator StartGame(float seconds) {
            yield return new WaitForSeconds(seconds);
            _nextTetromino = _spawner.SpawnTetromino();

            UpdateTetromino();
        }

        private void UpdateTetromino() {
            CurrentTetromino = _nextTetromino;
            _nextTetromino = _spawner.SpawnTetromino();
            
            StartTickCoroutine();
        }

        private void OnLand() {
            //CurrentTetromino.gameObject.SetActive(false);

            _field.Place(CurrentTetromino);
            Destroy(CurrentTetromino?.gameObject);

            UpdateTetromino();
            _holdCooldown = false;
        }

        private void OnHoldAction() {
            if (_holdCooldown || !_currentTetromino.IsActive) return;
            
            if (_holdenTetromino == null) {
                HoldenTetromino = CurrentTetromino;
                UpdateTetromino();
            } else {
                var tetromino = CurrentTetromino;
                CurrentTetromino = _holdenTetromino;
                HoldenTetromino = tetromino;
            }
            _holdCooldown = true;
        }
        
        internal Status CheckStatus(Vector2 pos) {
            return _field.CheckStatus(pos);
        }

        internal bool CheckActive() {
            return CurrentTetromino.IsActive;
        }
    }
}