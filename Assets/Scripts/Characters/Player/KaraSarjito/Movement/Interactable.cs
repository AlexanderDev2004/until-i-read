using UnityEngine;

namespace Assets.Scripts.Characters.Player.KaraSarjito.Movement
{
    public class Interactable : MonoBehaviour
    {
        public GameObject interactPrompt;

        private bool isPlayerNearby = false;

        private void Start()
        {
            if (interactPrompt != null)
            {
                interactPrompt.SetActive(false);
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (!collision.CompareTag("Player"))
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
            if (!collision.CompareTag("Player"))
            {
                return;
            }

            isPlayerNearby = false;

            if (interactPrompt != null)
            {
                interactPrompt.SetActive(false);
            }
        }

        private void Update()
        {
            if (isPlayerNearby && Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Interacted!");
            }
        }
    }
}