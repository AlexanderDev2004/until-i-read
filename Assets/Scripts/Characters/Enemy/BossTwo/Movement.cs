using UnityEngine;

namespace Assets.Scripts.Characters.Enemy.BossTwo
{
    public class Movement : MonoBehaviour
    {
        public Transform enemy;

        void Update()
        {
            Move();
        }

        public void Move()
        {
            if (enemy == null) return;
        }
    }
}