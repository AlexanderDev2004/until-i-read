using UnityEngine;
using UnityEditor;

namespace Assets.Scripts.Editor
{
    public class MissingScriptFinder
    {
        [MenuItem("Tools/Find Missing Scripts In Scene")]
        [System.Obsolete]

        static void FindMissingInScene()
        {
            GameObject[] gos = GameObject.FindObjectsOfType<GameObject>();
            int count = 0;

            foreach (GameObject go in gos)
            {
                Component[] components = go.GetComponents<Component>();
                for (int i = 0; i < components.Length; i++)
                {
                    if (components[i] == null)
                    {
                        Debug.LogWarning($"[Missing Script] di GameObject: {go.name}", go);
                        count++;
                    }
                }
            }

            Debug.Log($"Selesai scan scene. Ditemukan {count} missing script.");
        }
    }
}