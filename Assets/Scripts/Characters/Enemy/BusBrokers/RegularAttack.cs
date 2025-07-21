using UnityEngine;

namespace Assets.Scripts.Characters.Enemy.BusBrokers
{
    public class RegularAttack : BaseAttack
    {
        void Start()
        {
            damage = 5f;
        }

        public override void Attack(GameObject target)
        {
            if (target.TryGetComponent<HealthPoint>(out var hp))
            {
                hp.TakeDamage(damage);
            }
        }
    }
}