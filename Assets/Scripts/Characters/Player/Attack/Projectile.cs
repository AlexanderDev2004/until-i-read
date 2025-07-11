using UnityEngine;

namespace Assets.Scripts.Characters.Player.Attack
{
    public class Projectile : MonoBehaviour
    {
        private float damage;
        private float range;
        private float speed;
        private Vector2 startPosition;

        public void Initialize(float damage, float range, float speed)
        {
            this.damage = damage;
            this.range = range;
            this.speed = speed;
            startPosition = transform.position;
        }

        void Update()
        {
            transform.Translate(speed * Time.deltaTime * Vector2.right);

            if (Vector2.Distance(startPosition, transform.position) >= range)
            {
                Destroy(gameObject);
            }
        }

        void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent<Health.Point>(out var target))
            {
                target.TakeDamage(damage);
                Destroy(gameObject);
            }
        }
    }
}