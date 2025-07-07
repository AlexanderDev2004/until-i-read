using UnityEngine;

namespace Assets.Scripts.Combat
{
    public class Weapon : MonoBehaviour
    {
        public int damage;

        void Update()
        {
            Attack();
            Reload();
        }

        public void Attack()
        {
            Debug.Log("Attack with " + damage + " damage.");
        }

        public void Reload() { }
    }
}