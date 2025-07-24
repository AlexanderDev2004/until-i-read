using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenePortal : MonoBehaviour
{
    [System.Serializable]
    public class SceneTransition
    {
        public string fromScene;
        public string toScene;
    }

    public SceneTransition[] transitions;
    private bool playerInRange = false;

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            string currentScene = SceneManager.GetActiveScene().name;

            foreach (var transition in transitions)
            {
                if (transition.fromScene == currentScene)
                {
                    SceneManager.LoadScene(transition.toScene);
                    return;
                }
            }

            Debug.LogWarning("No scene transition found for current scene: " + currentScene);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            // Optional: Show "Press E to interact"
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            // Optional: Hide "Press E to interact"
        }
    }
}
