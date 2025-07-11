using UnityEngine;

namespace Assets.Scripts.Characters.Enemy.BossTwo
{
    public class Attack : MonoBehaviour
    {
        public float attackDamage = 10f;
        public float attackRange = 1.5f;
        public float attackSpeed = 1f;

        private Transform player;
        private float cooldownTimer = 0f;

        void Start()
        {
            GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
            if (playerObject != null)
            {
                player = playerObject.transform;
            }
        }

        void Update()
        {
            cooldownTimer -= Time.deltaTime;

            if (player == null) return;

            float distance = Vector2.Distance(transform.position, player.position);
            if (distance <= attackRange && cooldownTimer <= 0f)
            {
                AttackPlayer(attackDamage);
                cooldownTimer = attackSpeed;
            }
        }

        public void AttackPlayer(float damage)
        {
            Debug.Log("Boss attacks the player for " + damage + " damage.");

            if (player.TryGetComponent<IDamageable>(out var playerHealth))
            {
                playerHealth.GetAttackByWeapon(damage);
            }
        }
    }
}