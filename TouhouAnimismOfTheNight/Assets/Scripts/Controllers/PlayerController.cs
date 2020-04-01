using TH.Core;
using TH.Utilities;
using UnityEngine;

namespace TH.Controllers
{
    public class PlayerController : MonoBehaviour
    {
        /// <summary>
        /// The <see cref="Rigidbody2D"/> of the player controlled object
        /// </summary>
        private Rigidbody2D rb;

        /// <summary>
        /// The clamped position
        /// </summary>
        private Vector2 clampedPosition;

        /// <summary>
        /// The hitbox of the controlled object
        /// </summary>
        private new BoxCollider2D collider;

        /// <summary>
        /// The default hitbox size of the controlled object
        /// </summary>
        private Vector2 defaultColliderSize;

        /// <summary>
        /// The <see cref="ScreenBorderDetector"/>
        /// </summary>
        private ScreenBorderDetector screenBorderDetector;

        /// <summary>
        /// Controls the player's shooting ability
        /// </summary>
        private PlayerShots playerShooter;

        /// <summary>
        /// The sprite that appears when the player hits the focus button
        /// </summary>
        [SerializeField] private GameObject focusSprite = default;

        /// <summary>
        /// Indicates if the player has GodMode on
        /// </summary>
        [SerializeField] private bool godMode = false;

        private void Awake()
        {
            // Initialize
            rb = GetComponent<Rigidbody2D>();
            collider = GetComponent<BoxCollider2D>();
            playerShooter = GetComponent<PlayerShots>();
            defaultColliderSize = collider.size;
            screenBorderDetector = FindObjectOfType<ScreenBorderDetector>();

            GameManager.Instance.PlayerSpawned(this.gameObject);
        }

        void Update()
        {
            if (Input.GetKeyDown(Config.PauseKey))
            {
                GameManager.Instance.PauseGame();
            }
            if (!GameManager.Instance.isPaused)
            {
                if (Input.GetKeyDown(Config.PlayerShootKey)) { playerShooter.Shoot(); }
                if (Input.GetKeyDown(Config.PlayerBombKey)) { playerShooter.Bomb(); }

                // Handle movement
                bool isFocusClicked = Input.GetKey(Config.FocusMovementKey);
                focusSprite.SetActive(isFocusClicked);

                float focusMovementMultiplier = isFocusClicked ? Config.FocusMovementMultiplier : 1f;
                collider.size = isFocusClicked ? Config.FocusHitboxSize2D : defaultColliderSize;
                float horizontalMovement = Input.GetAxisRaw("Horizontal") * Config.GenericMovementMultiplier * focusMovementMultiplier;
                float verticalMovement = Input.GetAxisRaw("Vertical") * Config.GenericMovementMultiplier * focusMovementMultiplier;

                // Clamp the player's position so they do not go off-screen
                clampedPosition = rb.transform.position;
                clampedPosition.x += horizontalMovement * Time.fixedDeltaTime;
                clampedPosition.y += verticalMovement * Time.fixedDeltaTime;
                clampedPosition.x = Mathf.Clamp(clampedPosition.x, screenBorderDetector.leftBorder, screenBorderDetector.rightBorder - Config.PlayerXOffsetFromBorder);
                clampedPosition.y = Mathf.Clamp(clampedPosition.y, screenBorderDetector.bottomBorder, screenBorderDetector.upperBorder);

                rb.MovePosition(clampedPosition);
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "EnemyProjectile")
            {
                if (!godMode)
                {
                    GameManager.Instance.PlayerDeath(this.gameObject);
                }
                Destroy(collision.gameObject);
            }
            else if (collision.tag == "GraceProjectile")
            {
                playerShooter.numberOfBullets++;
                AudioManager.Instance.PlayPlayerGrazeFX();
            }
        }
    }
}
