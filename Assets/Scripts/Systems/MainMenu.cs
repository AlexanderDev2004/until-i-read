using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        Debug.Log("Play Game button pressed");
        SceneManager.LoadScene("Play");
    }

    public void ExitGame()
    {
        Debug.Log("Exit Game button pressed");
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    public void Credits()
    {
        Debug.Log("Credits button pressed");
        SceneManager.LoadScene("Credits");
    }
}
