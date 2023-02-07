using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI {

    public class MainMenuManager : MonoBehaviour
    {
        [SerializeField] private Button _play, _options, _exit;

        [SerializeField] private Canvas _optionsCanvas;

        private void OnEnable() {
            _play.onClick.AddListener(Play);
            _options.onClick.AddListener(Options);
            _exit.onClick.AddListener(Exit);
        }

        private void Play() {
            SceneManager.LoadScene("Game");
        }

        private void Options() {
            _optionsCanvas.gameObject.SetActive(true);
        }

        private void Exit() {
            Application.Quit();
        }
    }
}