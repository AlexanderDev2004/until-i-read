using UnityEngine;

namespace Assets.Scripts.Characters.Player.Attack
{
    public class Gun : BaseAttack
    {
        [SerializeField] private GameObject projectilePrefab;
        [SerializeField] private Transform firePoint;
        [SerializeField] private AmmoManager ammoManager;

        public override void Attack()
        {
            if (!ammoManager.HasAmmo())
            {
                return;
            }

            ammoManager.ConsumeAmmo();
            GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
            projectile.GetComponent<Projectile>().Initialize(damage, range, speed);
        }
    }
}