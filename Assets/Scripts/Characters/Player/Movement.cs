using UnityEngine;

namespace Assets.Scripts.Characters.Player
{
    public class Movement : MonoBehaviour
    {
        public float walkSpeed = 3f;
        public float runSpeed = 6f;
        public float jumpHeight = 0.5f;
        public float jumpDuration = 0.3f;

        private Rigidbody2D rb;
        private Vector2 movement;
        private bool isJumping = false;
        private float jumpTimer = 0f;
        private Vector3 originalPosition;

        [SerializeField] private Animator animator;

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
            float currentSpeed = Input.GetMouseButton(1) ? runSpeed : walkSpeed;
            rb.MovePosition(rb.position + currentSpeed * Time.fixedDeltaTime * movement);
        }
    }
}