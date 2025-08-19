using UnityEngine;

namespace Assets.Scripts.Characters.Player.KaraSarjito.Attack
{
    public abstract class BaseAttack : MonoBehaviour
    {
        public float damage;
        public float speed;

        public abstract void BuffHit();
        public abstract void RegularHit();
    }
}