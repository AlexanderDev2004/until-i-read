using UnityEngine;

namespace Assets.Scripts.Characters.Player.Attack
{
    public class AmmoManager : MonoBehaviour
    {
        [SerializeField] private int currentAmmo;
        [SerializeField] private int defaultAmmo = 10;

        private void Start()
        {
            currentAmmo = defaultAmmo;
        }

        public bool HasAmmo()
        {
            return currentAmmo > 0;
        }

        public void ConsumeAmmo()
        {
            if (currentAmmo > 0)
            {
                currentAmmo--;
            }
            else
            {
                Debug.Log("No more ammo!");
                currentAmmo = 0;
            }
        }

        public void AddAmmo(int amount)
        {
            currentAmmo += amount;
        }

        public int GetAmmo()
        {
            return currentAmmo;
        }
    }
}