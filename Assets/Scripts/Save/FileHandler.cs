using System.IO;
using UnityEngine;

namespace Assets.Scripts.Save
{
    public static class FileHandler
    {
        private static readonly string path = Path.Combine(Application.persistentDataPath, "save.json");

        public static void Save(Data data)
        {
            string json = JsonUtility.ToJson(data, true);
            File.WriteAllText(path, json);
            Debug.Log("Saved to: " + path);
        }

        public static Data Load()
        {
            if (!File.Exists(path))
            {
                return null;
            }

            string json = File.ReadAllText(path);
            return JsonUtility.FromJson<Data>(json);
        }
    }
}