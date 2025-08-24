using Assets.Scripts.Interaction;
using UnityEngine;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Assets.Scripts.Scene
{
    public class SceneTrigger : Base
    {
        [System.Serializable]
        public class SceneTransition
        {
            #if UNITY_EDITOR
                public SceneAsset fromScene; // drag & drop scene asset di Inspector
                public SceneAsset toScene;   // drag & drop scene asset di Inspector
            #endif
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
            #if UNITY_EDITOR
                foreach (var transition in transitions)
                {
                    if (transition.fromScene != null && transition.fromScene.name == currentScene)
                    {
                        return transition.toScene.name;
                    }
                }
            #endif

            return null;
        }
    }
}