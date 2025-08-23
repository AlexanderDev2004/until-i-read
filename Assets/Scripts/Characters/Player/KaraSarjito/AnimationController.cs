using UnityEngine;
using System.Collections.Generic;

namespace Assets.Scripts.Characters.Player.KaraSarjito
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class AnimationController : MonoBehaviour
    {
        [Header("Sprite Renderer")]
        [SerializeField] private SpriteRenderer spriteRenderer;

        [Header("Walk Frames")]
        [SerializeField] private Sprite[] walkUp;
        [SerializeField] private Sprite[] walkDown;
        [SerializeField] private Sprite[] walkLeft;
        [SerializeField] private Sprite[] walkRight;

        [Header("Animation Settings")]
        [SerializeField] private float frameRate = 0.2f;

        private float frameTimer;
        private int currentFrame;
        private Vector2 lastDirection = Vector2.down;
        private Dictionary<Vector2, Sprite[]> walkSprites;

        private void Awake()
        {
            if (spriteRenderer == null)
            {
                spriteRenderer = GetComponent<SpriteRenderer>();
            }

            walkSprites = new Dictionary<Vector2, Sprite[]>
            {
                { Vector2.up, walkUp },
                { Vector2.down, walkDown },
                { Vector2.left, walkLeft },
                { Vector2.right, walkRight }
            };
        }

        private void Update()
        {
            HandleAnimation();
        }

        private void HandleAnimation()
        {
            Vector2 move = new(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

            // Kalau tidak bergerak → pakai frame pertama dari animasi terakhir
            if (move.sqrMagnitude < 0.1f)
            {
                if (walkSprites.TryGetValue(lastDirection, out var frames) && frames.Length > 0)
                {
                    spriteRenderer.sprite = frames[0];
                }

                return;
            }

            lastDirection = Mathf.Abs(move.x) > Mathf.Abs(move.y) ? (move.x > 0 ? Vector2.right : Vector2.left) : (move.y > 0 ? Vector2.up : Vector2.down);
            frameTimer += Time.deltaTime;

            if (frameTimer >= frameRate)
            {
                frameTimer = 0f;
                currentFrame++;
            }

            // Ambil animasi jalan
            if (walkSprites.TryGetValue(lastDirection, out var framesAnim) && framesAnim.Length > 0)
            {
                spriteRenderer.sprite = framesAnim[currentFrame % framesAnim.Length];
            }
        }
    }
}