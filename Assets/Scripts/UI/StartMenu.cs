using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.UI
{
    public class StartMenu : MonoBehaviour
    {
        public void Play()
        {
            SceneManager.LoadScene("KaraSarjitoRoom");
        }

        public void Settings()
        {
            SceneManager.LoadScene("Settings");
        }

        public void Credits()
        {
            SceneManager.LoadScene("Credits");
        }

        public void Exit()
        {
            Application.Quit();

            #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
            #endif
        }
    }
}