using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Leaderboards {

    using Game.Data;
    using UnityEngine.SceneManagement;

    public class WarningManager : MonoBehaviour
    {
        [SerializeField] private Button _ok, _cancel;

        private void OnEnable()
        {
            _ok.onClick.AddListener(OnOkClicked);
            _cancel.onClick.AddListener(OnCancelClicked);
        }

        private void OnDisable() {
            _ok.onClick.RemoveListener(OnOkClicked);
            _cancel.onClick.RemoveListener(OnCancelClicked);
        }

        private void OnOkClicked() {
            SaveSystem.Reset();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        private void OnCancelClicked() {
            gameObject.SetActive(false);
        }
    }
}