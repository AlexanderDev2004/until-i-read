using UnityEngine;

namespace Assets.Scripts.Characters.Player.Attack
{
    public class Slingshot : BaseAttack
    {
        [Header("Slingshot")]
        [SerializeField] private GameObject projectilePrefab;
        [SerializeField] private Transform firePoint;

        public override void Attack()
        {
            GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
            projectile.GetComponent<Projectile>().Initialize(damage, range, speed);
        }
    }
}