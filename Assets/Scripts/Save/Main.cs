using UnityEngine;

namespace Assets.Scripts.Save
{
    public class Main : MonoBehaviour
    {
        [Header("General Save Settings")]
        [SerializeField] private Mode saveMode = Mode.Manual;
        [SerializeField] private int maxSaveCount = 5;

        [Header("Manual Save Settings")]
        [SerializeField] private GameObject interactPrompt;

        private int saveCount = 0;
        private bool isPlayerNearby = false;

        private void Update()
        {
            if (saveMode == Mode.Manual && isPlayerNearby && Input.GetKeyDown(KeyCode.E))
            {
                ManualSave();
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (saveMode != Mode.Manual || !collision.CompareTag("Player"))
            {
                return;
            }

            isPlayerNearby = true;

            if (interactPrompt != null)
            {
                interactPrompt.SetActive(true);
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (saveMode != Mode.Manual || !collision.CompareTag("Player"))
            {
                return;
            }

            isPlayerNearby = false;

            if (interactPrompt != null)
            {
                interactPrompt.SetActive(false);
            }
        }

        public void TriggerOnSave()
        {
            if (saveMode == Mode.Auto)
            {
                AutoSave();
            }
        }

        private void AutoSave()
        {
            if (saveCount >= maxSaveCount)
            {
                return;
            }

            Debug.Log("Auto saved.");
            SaveGame();
            saveCount++;
        }

        private void ManualSave()
        {
            if (saveCount >= maxSaveCount)
            {
                return;
            }

            Debug.Log("Manual saved.");
            SaveGame();
            saveCount++;
        }

        private void SaveGame()
        {
            Data data = new()
            {
                healthPoint = 100,
                manuscript = 0,
                playerPosition = transform.position,
            };

            FileHandler.Save(data);
        }
    }
}