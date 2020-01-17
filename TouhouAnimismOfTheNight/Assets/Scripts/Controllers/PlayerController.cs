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

        // Start is called before the first frame update
        void Start()
        {
            // Initialize
            rb = GetComponent<Rigidbody2D>();
            collider = GetComponent<BoxCollider2D>();
            defaultColliderSize = collider.size;
            screenBorderDetector = FindObjectOfType<ScreenBorderDetector>();
        }

        // Update is called once per frame
        void Update()
        {
            // Handle movement
            bool isFocusClicked = Input.GetKey(Config.FocusMovementKey);
            float focusMovementMultiplier = isFocusClicked ? Config.FocusMovementMultiplier : 1f;
            collider.size = isFocusClicked ? Config.FocusHitboxSize2D : defaultColliderSize;
            float horizontalMovement = Input.GetAxis("Horizontal") * Config.GenericMovementMultiplier * focusMovementMultiplier;
            float verticalMovement = Input.GetAxis("Vertical") * Config.GenericMovementMultiplier * focusMovementMultiplier;

            // Clamp the player's position so they do not go off-screen
            Vector3 clampedPosition = rb.transform.position;
            clampedPosition += new Vector3(horizontalMovement * Time.deltaTime, verticalMovement * Time.deltaTime);
            clampedPosition.x = Mathf.Clamp(clampedPosition.x, screenBorderDetector.leftBorder, screenBorderDetector.rightBorder);
            clampedPosition.y = Mathf.Clamp(clampedPosition.y, screenBorderDetector.bottomBorder, screenBorderDetector.upperBorder);

            rb.transform.position = clampedPosition;
        }
    }
}
