using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI {

    public class MainMenuManager : MonoBehaviour
    {
        [SerializeField] private Button _play, _leaderboards, _options, _exit;

        [SerializeField] private Canvas _optionsCanvas;

        private void OnEnable() {
            _play.onClick.AddListener(Play);
            _leaderboards.onClick.AddListener(Leaderboards);
            _options.onClick.AddListener(Options);
            _exit.onClick.AddListener(Exit);
        }

        private void OnDisable() {
            _play.onClick.RemoveListener(Play);
            _leaderboards.onClick.RemoveListener(Leaderboards);
            _options.onClick.RemoveListener(Options);
            _exit.onClick.RemoveListener(Exit);
        }

        private void Play() {
            SceneManager.LoadScene("Game");
        }

        private void Leaderboards() {
            SceneManager.LoadScene("Leaderboards");
        }

        private void Options() {
            _optionsCanvas.gameObject.SetActive(true);
        }

        private void Exit() {
            Application.Quit();
        }
    }
}