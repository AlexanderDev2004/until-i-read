using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Characters.Enemy.BusBrokers
{
    public class HealthPoint : MonoBehaviour
    {
        public float maxHealth = 100f;
        public float currentHealth;
        public Image healthBar;

        private BaseAttack regularAttack;
        private BaseAttack ultimate;
        private int turnCounter = 0;

        void Start()
        {
            currentHealth = maxHealth;

            // Inisialisasi dua tipe serangan (jika belum di-attach via Inspector)
            regularAttack = GetComponent<RegularAttack>();
            if (regularAttack == null) regularAttack = gameObject.AddComponent<RegularAttack>();

            ultimate = GetComponent<Ultimate>();
            if (ultimate == null) ultimate = gameObject.AddComponent<Ultimate>();

            UpdateHealthBar();
        }

        void Update()
        {
            HandleTurnInput();
        }

        private void HandleTurnInput()
        {
            // Simulasi: musuh menyerang saat tombol Space ditekan
            if (Input.GetKeyDown(KeyCode.Space))
            {
                turnCounter++;
                Debug.Log($"Turn {turnCounter}: Enemy turn");
                PerformTurnAttack();
            }
        }

        private void PerformTurnAttack()
        {
            if (turnCounter % 3 == 0)
            {
                ultimate.Attack(gameObject);
            }
            else
            {
                regularAttack.Attack(gameObject);
            }
        }

        public void TakeDamage(float amount)
        {
            currentHealth -= amount;

            if (currentHealth < 0)
            {
                currentHealth = 0;
            }

            Debug.Log($"Enemy took {amount} damage. Remaining HP: {currentHealth}.");
            UpdateHealthBar();

            if (currentHealth <= 0)
            {
                Die();
            }
        }

        private void UpdateHealthBar()
        {
            if (healthBar != null)
            {
                float fillAmount = currentHealth / maxHealth;
                healthBar.fillAmount = fillAmount;
            }
        }

        private void Die()
        {
            Debug.Log("Enemy died!");
        }
    }
}