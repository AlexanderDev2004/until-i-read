using UnityEngine;

namespace Assets.Scripts.Characters.Player.KaraSarjito
{
    public class Explore : MonoBehaviour
    {
        [Header("Movement Settings")]
        [SerializeField] private float walkSpeed = 3f;
        [SerializeField] private float runSpeed = 6f;

        [Header("Audio")]
        [SerializeField] private AudioSource audioSource;
        [SerializeField] private AudioClip walkClip;

        private Rigidbody2D rb;
        private Vector2 movement;
        private bool wasMoving = false;

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            HandleInput();
            HandleWalkingSound();
        }

        private void FixedUpdate()
        {
            Move();
        }

        private void HandleInput()
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");

            // Biar gak bisa diagonal, pilih sumbu dominan
            if (Mathf.Abs(horizontal) > 0)
            {
                vertical = 0; // matikan gerakan vertikal
            }
            else if (Mathf.Abs(vertical) > 0)
            {
                horizontal = 0; // matikan gerakan horizontal
            }

            movement = new Vector2(horizontal, vertical);
        }

        private void Move()
        {
            float currentSpeed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed;
            rb.MovePosition(rb.position + currentSpeed * Time.fixedDeltaTime * movement);
        }

        private void HandleWalkingSound()
        {
            if (audioSource == null || walkClip == null)
            {
                return;
            }

            bool isMoving = movement.magnitude > 0.1f;
            bool isRunning = Input.GetKey(KeyCode.LeftShift);
            bool shouldPlay = isMoving;

            if (!shouldPlay || (wasMoving && !isMoving))
            {
                audioSource.Stop();
                wasMoving = false;
                return;
            }

            AudioClip targetClip = walkClip;
            float targetPitch = isRunning ? 1.5f : 1f;

            bool justStartedMoving = !wasMoving;
            bool clipChanged = audioSource.clip != targetClip;

            if (justStartedMoving || clipChanged)
            {
                audioSource.clip = targetClip;
                audioSource.pitch = targetPitch;
                audioSource.loop = true;
                audioSource.Play();
            }
            else
            {
                audioSource.pitch = targetPitch;
            }

            wasMoving = true;
        }
    }
}