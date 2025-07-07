using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Systems
{
    public class PauseMenu : MonoBehaviour
    {
        [Header("UI Panel")]
        public GameObject pauseMenuUI, firstSelectedButton;

        private bool isPaused = false;

        void Start()
        {
            if (pauseMenuUI != null) pauseMenuUI?.SetActive(false);
            Time.timeScale = 1f;
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (isPaused) Resume();
                else Pause();
            }
        }

        public void Pause()
        {
            if (pauseMenuUI == null) return;

            pauseMenuUI.SetActive(true);
            Time.timeScale = 0f;
            isPaused = true;

            if (firstSelectedButton != null)
            {
                EventSystem.current.SetSelectedGameObject(null);
                EventSystem.current.SetSelectedGameObject(firstSelectedButton);
            }
        }

        public void Resume()
        {
            if (pauseMenuUI == null) return;
            pauseMenuUI.SetActive(false);
            Time.timeScale = 1f;
            isPaused = false;
        }

        public void ExitToMainMenu()
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene("StartMenu");
        }

        public void OpenSettings()
        {
            Debug.Log("The settings button is pressed.");
        }
    }
}