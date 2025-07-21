using UnityEngine;

namespace Assets.Scripts.Characters.Enemy.BusBrokers
{
    public class Ultimate : BaseAttack
    {
        void Start()
        {
            damage = 15f;
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