using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public int Health = 100;

    [Header("UI")]
    public RectTransform RectTransform;
    public Image HealthBarImage;

    private float originalWidth;

    private void Start()
    {
        originalWidth = RectTransform.sizeDelta.x;
        UpdateHealthBar();
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
        Health = Mathf.Clamp(Health, 0, 100);
        UpdateHealthBar();
    }

    public void Heal(int amount)
    {
        Health += amount;
        Health = Mathf.Clamp(Health, 0, 100);
        UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
        float healthPercent = Health / 100f;

        if (HealthBarImage != null)
            HealthBarImage.fillAmount = healthPercent; // lebih halus dan stabil

        // Optional: jika masih ingin pakai RectTransform
        RectTransform.sizeDelta = new Vector2(originalWidth * healthPercent, RectTransform.sizeDelta.y);
    }


    private void Update()
    {
        // Heal saat tekan Arrow Up
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Heal(10);
            Debug.Log("Healed: " + Health);
        }

        // Damage saat tekan Arrow Down
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            TakeDamage(10);
            Debug.Log("Took Damage: " + Health);
        }
    }

}

