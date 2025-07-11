using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Characters.Player.Health
{
    public class Bar : MonoBehaviour
    {
        [SerializeField] private Slider slider;
        [SerializeField] private GameObject canvas;
        [SerializeField] private Point healthPoint;

        private void Start()
        {
            if (canvas != null)
            {
                canvas.SetActive(false);
            }

            UpdateUI();
        }

        private void Update()
        {
            UpdateUI();

            if (healthPoint.currentHealth < healthPoint.maxHealth && canvas != null)
            {
                canvas.SetActive(true);
            }
        }

        void UpdateUI()
        {
            if (slider != null)
            {
                slider.value = healthPoint.GetNormalized();
            }
        }
    }
}