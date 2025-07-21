using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Systems
{
    public class RestrictionArea : MonoBehaviour
    {
        [Header("Reference")]
        public GameObject character;
        public Text dialogText;

        [Header("Boundaries")]
        public Vector2 xBounds = new(-10f, 10f);
        public Vector2 yBounds = new(-10f, 10f);

        [Header("Dialog")]
        public string warningMessage = "Di sana masih banyak orang, aku takut buat ke sana.";
        public float dialogDuration = 2f;

        private bool isWarningActive = false;
        private float dialogTimer = 0f;

        void Update()
        {
            Boundaries();
        }

        private void Boundaries()
        {
            Vector3 position = character.transform.position;
            bool isOutOfBound = IsOutOfBound(position);

            if (isOutOfBound)
            {
                ClampCharacterPosition(position);
                ShowWarning();
            }

            UpdateDialogTimer();
        }

        private bool IsOutOfBound(Vector3 position)
        {
            return position.x < xBounds.x || position.x > xBounds.y || position.y < yBounds.x || position.y > yBounds.y;
        }

        private void ClampCharacterPosition(Vector3 position)
        {
            float clampedX = Mathf.Clamp(position.x, xBounds.x, xBounds.y);
            float clampedY = Mathf.Clamp(position.y, xBounds.x, xBounds.y);
            character.transform.position = new Vector3(clampedX, clampedY, position.z);
        }

        private void ShowWarning()
        {
            if (isWarningActive || dialogText == null)
            {
                return;
            }

            dialogText.text = warningMessage;
            dialogText.enabled = true;
            isWarningActive = true;
            dialogTimer = dialogDuration;
        }

        private void UpdateDialogTimer()
        {
            if (!isWarningActive)
            {
                return;
            }

            dialogTimer -= Time.deltaTime;

            if (dialogTimer > 0f)
            {
                return;
            }

            dialogText.enabled = false;
            isWarningActive = false;
        }
    }
}