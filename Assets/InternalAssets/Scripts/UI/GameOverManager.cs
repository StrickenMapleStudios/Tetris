using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Game;
using UnityEngine.SceneManagement;

namespace UI {

    public class GameOverManager : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _score;
        [SerializeField] private TextMeshProUGUI _time;

        [SerializeField] private TMP_InputField _input;

        [SerializeField] private Button _ok;

        private void OnEnable() {

            _ok.onClick.AddListener(OnOKClicked);
            
            _score.text = $"{GameManager.Instance.Score}";
            _time.text = $"{GameManager.Instance.Lifetime}";
        }

        private void OnDisable() {
            _ok.onClick.RemoveListener(OnOKClicked);
        }

        private void OnOKClicked() {
            if (_input.text != "") {
                GameEventChannel.current.SaveResult(_input.text);
            }

            SceneManager.LoadScene("Menu");
        }
    }
}