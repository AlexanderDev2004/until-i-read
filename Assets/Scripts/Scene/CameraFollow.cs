using UnityEngine;

namespace Assets.Scripts.Scene
{
    public class CameraFollow : MonoBehaviour
    {
        [Header("Target")]
        public Transform playerTransform;

        [Header("Camera Settings")]
        [Range(0, 1)]
        public float mouseInfluence = 0.2f;
        public float smoothing = 5f;
        public float cameraZOffset = -10f;
        private Camera mainCamera;

        void Awake()
        {
            mainCamera = GetComponent<Camera>();

            if (playerTransform == null)
            {
                Debug.LogError("Player Transform is not assigned on the CameraFollow script. Please assign it in the Inspector.");
                this.enabled = false;
            }
        }

        void LateUpdate()
        {
            Vector3 mouseWorldPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            mouseWorldPosition.z = playerTransform.position.z;
            Vector3 targetPosition = Vector3.Lerp(playerTransform.position, mouseWorldPosition, mouseInfluence);
            targetPosition.z = cameraZOffset;
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing * Time.deltaTime);
        }
    }
}