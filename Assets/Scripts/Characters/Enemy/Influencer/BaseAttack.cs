using UnityEngine;

namespace Assets.Scripts.Characters.Enemy.Influencer
{
    public abstract class BaseAttack : MonoBehaviour
    {
        public float damage;

        public abstract void AreaOfEffect();
        public abstract void RegularAttack();
        public abstract void Regenerate();
    }
}