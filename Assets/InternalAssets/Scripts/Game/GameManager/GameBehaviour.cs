using UnityEngine;

namespace Game {
    using System.Collections;
    using Field;
    using Minoes;

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


        public bool IsPlaying { get; private set; } = false;

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

            _gameEventChannel.OnTick.AddListener(OnTick);
            _gameEventChannel.OnLand.AddListener(OnLand);
            _gameEventChannel.OnHoldAction.AddListener(OnHoldAction);

            _gameEventChannel.OnRowsFilled.AddListener(OnRowsFilled);
            _gameEventChannel.OnGameOver.AddListener(OnGameOver);

            _uiEventChannel.OnPauseClicked.AddListener(OnPauseClicked);
            _uiEventChannel.OnResumeClicked.AddListener(OnResumeClicked);

            _gameEventChannel.OnSaveResult.AddListener(SaveResult);
        }

        private void OnDisable() {
            
            _gameEventChannel.OnTick.RemoveListener(OnTick);
            _gameEventChannel.OnLand.RemoveListener(OnLand);
            _gameEventChannel.OnHoldAction.RemoveListener(OnHoldAction);

            _gameEventChannel.OnRowsFilled.RemoveListener(OnRowsFilled);
            _gameEventChannel.OnGameOver.RemoveListener(OnGameOver);

            _uiEventChannel.OnPauseClicked.RemoveListener(OnPauseClicked);
            _uiEventChannel.OnResumeClicked.RemoveListener(OnResumeClicked);

            _gameEventChannel.OnSaveResult.RemoveListener(SaveResult);
        }

        private void Start() {
            StartCoroutine(StartGame(0));
        }

        private IEnumerator StartGame(float seconds) {
            yield return new WaitForSeconds(seconds);

            IsPlaying = true;

            StartCoroutine(Timer(_gamePrefs.TimerAcc));
            
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