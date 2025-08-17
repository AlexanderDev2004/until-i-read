using Assets.Scripts.Interaction;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Scene
{
    public class SceneTrigger : Base
    {
        [System.Serializable]
        public class SceneTransition
        {
            public string fromScene;
            public string toScene;
        }

        [Header("Scene Transition")]
        public SceneTransition[] transitions;

        public override void Interact()
        {
            string currentScene = SceneManager.GetActiveScene().name;
            string nextScene = GetNextScene(currentScene);

            if (!string.IsNullOrEmpty(nextScene))
            {
                SceneManager.LoadScene(nextScene);
            }
            else
            {
                Debug.LogWarning($"No scene transition found for current scene: {currentScene}.");
            }
        }

        private string GetNextScene(string currentScene)
        {
            foreach (var transition in transitions)
            {
                if (transition.fromScene == currentScene)
                {
                    return transition.toScene;
                }
            }

            return null;
        }
    }
}