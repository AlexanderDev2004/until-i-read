using UnityEngine;

namespace Assets.Scripts.Characters.Player
{
    public class Movement : MonoBehaviour
    {
        [Header("Movement Settings")]
        public float walkSpeed = 3f;
        public float runSpeed = 6f;
        public float jumpHeight = 0.5f;
        public float jumpDuration = 0.3f;

        [Header("Audio Settings")]
        [SerializeField] private AudioSource audioSource;
        [SerializeField] private AudioClip walkClip;
        [SerializeField] private AudioClip runClip;
        [SerializeField] private AudioClip jumpClip;

        [Header("Animation")]
        [SerializeField] private Animator animator;

        private Rigidbody2D rb;
        private Vector2 movement;
        private bool isJumping = false;
        private float jumpTimer = 0f;
        private Vector3 originalPosition;
        private bool wasMoving = false;

        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            originalPosition = transform.localPosition;
        }

        void Update()
        {
            HandleInput();
            HandleJump();
            AnimateJumpOffset();
            HandleWalkingSound();
        }

        void FixedUpdate()
        {
            Move();
        }

        void HandleInput()
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");
            movement = new Vector2(horizontal, vertical).normalized;
        }

        void HandleJump()
        {
            if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
            {
                isJumping = true;
                jumpTimer = 0f;
                animator.SetTrigger("Jump");
                PlaySound(jumpClip);
            }
        }

        void AnimateJumpOffset()
        {
            if (!isJumping) return;

            jumpTimer += Time.deltaTime;
            float progress = jumpTimer / jumpDuration;

            if (progress >= 1f)
            {
                isJumping = false;
                transform.localPosition = originalPosition;
                return;
            }

            float height = Mathf.Sin(progress * Mathf.PI) * jumpHeight;
            transform.localPosition = originalPosition + new Vector3(0, height, 0);
        }

        void Move()
        {
            float currentSpeed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed;
            rb.MovePosition(rb.position + currentSpeed * Time.fixedDeltaTime * movement);
        }

        void HandleWalkingSound()
        {
            if (audioSource == null) return;

            bool isMoving = movement.magnitude > 0.1f;
            bool isRunning = Input.GetKey(KeyCode.LeftShift);
            bool shouldPlay = isMoving && !isJumping;

            if (!shouldPlay)
            {
                if (audioSource.isPlaying)
                    audioSource.Stop();

                wasMoving = false;
                return;
            }

            AudioClip targetClip = walkClip; // Gunakan hanya 1 clip, misal walkClip
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
                audioSource.pitch = targetPitch; // ubah pitch saat player lari/jalan
            }

            wasMoving = true;
        }


        void PlaySound(AudioClip clip)
        {
            if (clip != null)
            {
                audioSource.PlayOneShot(clip);
            }
        }
    }
}