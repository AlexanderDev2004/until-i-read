using UnityEngine;
using UnityEngine.UI;

public class Manuscript : MonoBehaviour
{
    [Header("UI")]
    public GameObject dialogPanel; // Panel dialog (diaktifkan saat player dekat)
    public Button okButton;        // Tombol OK untuk mengonfirmasi teleportasi

    [Header("Teleport Settings")]
    public Transform bossArenaSpawnPoint; // Target lokasi teleportasi

    private bool playerInTrigger = false;
    private GameObject player;

    void Start()
    {
        dialogPanel.SetActive(false); // pastikan dialog awalnya mati
        okButton.onClick.AddListener(OnOkClicked);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInTrigger = true;
            player = other.gameObject;
            dialogPanel.SetActive(true); // tampilkan UI
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInTrigger = false;
            dialogPanel.SetActive(false);
        }
    }

    void OnOkClicked()
    {
        if (playerInTrigger && player != null)
        {
            player.transform.position = bossArenaSpawnPoint.position;
            dialogPanel.SetActive(false);
        }
    }
}
