using UnityEngine;

namespace Assets.Scripts.Characters.Enemy.BossOne
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