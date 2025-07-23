using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Environments
{
    public class ChangeScene : MonoBehaviour
    {
        public string SceneName;

        private void OnTriggerEnter2D(Collider2D other)
        {
            SceneManager.LoadScene(SceneName);
        }
    }
}