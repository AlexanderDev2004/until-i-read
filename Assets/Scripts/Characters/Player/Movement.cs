using UnityEngine;

namespace Assets.Scripts.Characters.Player
{
    public class Movement : MonoBehaviour
    {
        public float walkSpeed = 3f;
        public float runSpeed = 6f;
        public float jumpForce = 5f;

        private Rigidbody2D rb;
        private Vector2 movement;
        private bool isGrounded = false;

        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        void Update()
        {
            HandleInput();
            HandleJump();
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
            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                isGrounded = false;
            }
        }

        void Move()
        {
            float currentSpeed = Input.GetMouseButton(1) ? runSpeed : walkSpeed;
            rb.MovePosition(rb.position + currentSpeed * Time.fixedDeltaTime * movement);
        }

        void OnCollisionStay2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Ground"))
            {
                isGrounded = true;
            }
        }

        void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Ground"))
            {
                isGrounded = false;
            }
        }
    }
}