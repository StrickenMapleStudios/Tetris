using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI {

    public class PauseManager : MonoBehaviour
    {
        [SerializeField] private Button _resume, _restart, _options, _quit;

        [SerializeField] private OptionsManager _optionsManager;

        private void OnEnable() {
            Time.timeScale = 0;

            _resume.onClick.AddListener(OnResumeClicked);
            _restart.onClick.AddListener(OnRestartClicked);
            _options.onClick.AddListener(OnOptionsClicked);
            _quit.onClick.AddListener(OnQuitClicked);
        }

        private void OnDisable() {
            Time.timeScale = 1;
            _optionsManager.gameObject.SetActive(false);

            _resume.onClick.RemoveListener(OnResumeClicked);
            _restart.onClick.RemoveListener(OnRestartClicked);
            _options.onClick.RemoveListener(OnOptionsClicked);
            _quit.onClick.RemoveListener(OnQuitClicked);

        }

        private void OnResumeClicked() {
            UIEventChannel.current.OnResumeClicked.Invoke();
            gameObject.SetActive(false);
        }

        private void OnRestartClicked() {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        private void OnOptionsClicked() {
            _optionsManager.gameObject.SetActive(true);
        }

        private void OnQuitClicked() {
            SceneManager.LoadScene("Menu");
        }
    }
}