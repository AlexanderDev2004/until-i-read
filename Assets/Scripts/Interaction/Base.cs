using UnityEngine;

namespace Assets.Scripts.Interaction
{
    public abstract class Base : MonoBehaviour
    {
        [Header("Interaction")]
        public GameObject interactPrompt;

        protected bool isPlayerNearby = false;

        protected virtual void Start()
        {
            if (interactPrompt != null)
            {
                interactPrompt.SetActive(false);
            }
        }

        protected virtual void Update()
        {
            if (isPlayerNearby && Input.GetKeyDown(KeyCode.E))
            {
                Interact();
            }
        }

        public void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("Player"))
            {
                return;
            }

            isPlayerNearby = true;

            if (interactPrompt != null)
            {
                interactPrompt.SetActive(true);
            }
        }

        public void OnTriggerExit2D(Collider2D other)
        {
            if (!other.CompareTag("Player"))
            {
                return;
            }

            isPlayerNearby = false;

            if (interactPrompt != null)
            {
                interactPrompt.SetActive(false);
            }
        }

        public abstract void Interact();
    }
}