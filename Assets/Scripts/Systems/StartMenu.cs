using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Systems
{
    public class StartMenu : MonoBehaviour
    {
        public void Play()
        {
            Debug.Log("The play button is pressed.");
            SceneManager.LoadScene("Prolog");
        }

        public void Settings()
        {
            Debug.Log("The settings button is pressed.");
            SceneManager.LoadScene("Settings");
        }

        public void Credits()
        {
            Debug.Log("The credits button is pressed.");
            SceneManager.LoadScene("Credits");
        }

        public void Exit()
        {
            Debug.Log("The exit button is pressed.");
            Application.Quit();

            #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
            #endif
        }
    }
}