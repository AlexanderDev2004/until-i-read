using UnityEngine;

namespace Assets.Scripts.Characters.Player.KaraSarjito.Attack
{
    public abstract class BaseAttack : MonoBehaviour
    {
        public float damage;
        public float speed;

        public abstract void BuffAttack();
        public abstract void RegularAttack();
    }
}