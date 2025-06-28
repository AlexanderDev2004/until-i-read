using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Characters.Player
{
    public class HealthPoint : MonoBehaviour
    {
        public float maxHealthPoint = 100f;
        public float currentHealth;
        public Slider healthBar;
        public GameObject healthBarCanvas;

        void Start()
        {
            currentHealth = maxHealthPoint;
            UpdateHealthBar();

            if (healthBarCanvas != null)
            {
                healthBarCanvas.SetActive(false);
            }
        }

        /*
         * Sistem heal pada permainan ini adalah membeli atau memungut sesuatu
         * dan menukarkannya dengan uang. Uang tersebut yang nantinya bisa membeli
         * makanan atau minuman untuk menambah HP pemain.
         */
        public void Heal(float amount)
        {
            currentHealth += amount;
            currentHealth = Mathf.Clamp(currentHealth, 0, maxHealthPoint);
            UpdateHealthBar();
            Debug.Log("Healed " + amount + ". Current HP is " + currentHealth + ".");
        }

        /*
         * Fungsi TakeDamage() bertujuan agar HP pemain berkurang ketika terkena
         * serangan dari musuh, tergantung lawannya siapa.
         */
        public void TakeDamage(float amount)
        {
            currentHealth -= amount;
            currentHealth = Mathf.Clamp(currentHealth, 0, maxHealthPoint);
            UpdateHealthBar();
            Debug.Log("Took damage " + amount + ". Current HP is " + currentHealth + ".");

            if (healthBarCanvas != null)
            {
                healthBarCanvas.SetActive(true);
            }
            else if (currentHealth <= 0)
            {
                Die();
            }
        }

        void UpdateHealthBar()
        {
            if (healthBar != null)
            {
                healthBar.value = currentHealth / maxHealthPoint;
            }
        }

        void Die()
        {
            Debug.Log(gameObject.name + " died!");
            Destroy(gameObject);
        }
    }
}