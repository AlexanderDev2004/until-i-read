using UnityEngine;
using UnityEngine.UI;

public class Interactable : MonoBehaviour
{
    public GameObject interactPrompt; // assign UI Text/Image dari inspector

    private bool isPlayerNearby = false;

    private void Start()
    {
        if (interactPrompt != null)
            interactPrompt.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerNearby = true;
            if (interactPrompt != null)
                interactPrompt.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerNearby = false;
            if (interactPrompt != null)
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
