using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class PauseMenu : MonoBehaviour
{
    [Header("UI Panel")]
    public GameObject pauseMenuUI;        // Panel utama Pause Menu
    public GameObject firstSelectedButton; // Tombol pertama yang disorot (optional, untuk navigasi gamepad/keyboard)

    private bool isPaused = false;

    void Start()
    {
        // Pastikan pause menu tidak tampil saat game mulai
        if (pauseMenuUI != null)
            pauseMenuUI.SetActive(false);

        // Pastikan waktu berjalan normal saat start
        Time.timeScale = 1f;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                Resume();
            else
                Pause();
        }
    }

    public void Pause()
    {
        if (pauseMenuUI == null) return;

        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;

        // Reset focus tombol pertama (untuk keyboard/controller)
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
        // Wajib resume dulu sebelum load scene, agar Time.timeScale normal
        Time.timeScale = 1f;
        SceneManager.LoadScene("StartMenu");
    }

    public void OpenSettings()
    {
        // Di sini kamu bisa membuka panel settings lain
        Debug.Log("Open Settings (belum diimplementasi)");
    }
}
