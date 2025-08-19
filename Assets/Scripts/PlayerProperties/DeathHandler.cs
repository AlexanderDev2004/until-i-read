using UnityEngine;

namespace Assets.Scripts.PlayerProperties
{
    public class DeathHandler : MonoBehaviour
    {
        [SerializeField] private Point healthPoint;

        private void Update()
        {
            if (healthPoint.IsDead())
            {
                Die();
            }
        }

        private void Die()
        {
            Debug.Log($"{gameObject.name} died!");
            Destroy(gameObject);
        }
    }
}