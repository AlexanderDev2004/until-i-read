using UnityEngine;

namespace Assets.Scripts.PlayerProperties
{
    public class CrowdStressHandler : MonoBehaviour
    {
        [SerializeField] private Point mentalHealth;
        [SerializeField] private float stressPerSecond = 5f;

        private void OnTriggerStay2D(Collider2D other)
        {
            if (other.CompareTag("Crowd") && mentalHealth.healthType == Type.MENTAL)
            {
                mentalHealth.TakeDamage(stressPerSecond * Time.deltaTime);
            }
        }
    }
}