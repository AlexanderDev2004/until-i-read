using UnityEngine;

namespace Assets.Scripts.Characters.Player.Attack
{
    public class AttackInput : MonoBehaviour
    {
        [SerializeField] private BaseAttack currentWeapon;

        void Update()
        {
            if (Input.GetButtonDown(""))
            {
                currentWeapon.Attack();
            }
        }

        public void SetWeapon(BaseAttack weapon)
        {
            currentWeapon = weapon;
        }
    }
}