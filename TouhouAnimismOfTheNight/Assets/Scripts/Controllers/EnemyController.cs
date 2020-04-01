using TH.Core;
using TH.Utilities;
using UnityEngine;

namespace TH.Controllers
{
    public class EnemyController : MonoBehaviour
    {
        /// <summary>
        /// The <see cref="Rigidbody2D"/> of the enemy
        /// </summary>
        private Rigidbody2D rb;

        /// <summary>
        /// The direction scalar used in the enemy movement
        /// </summary>
        private int movementDirection = 1;

        /// <summary>
        /// The <see cref="ScreenBorderDetector"/>
        /// </summary>
        private ScreenBorderDetector screenBorderDetector;

        /// <summary>
        /// The type of this enemy
        /// </summary>
        public EnemyType enemyType;

        private void Awake()
        {
            // Initialize
            rb = GetComponent<Rigidbody2D>();
            screenBorderDetector = FindObjectOfType<ScreenBorderDetector>();
        }

        private void Update()
        {
            if (!GameManager.Instance.isPaused)
            {
                Vector3 clampedPosition = rb.transform.position;
                if (clampedPosition.y == screenBorderDetector.upperBorder)
                {
                    movementDirection = -1;
                }
                else if (clampedPosition.y == screenBorderDetector.bottomBorder)
                {
                    movementDirection = 1;
                }
                clampedPosition.y = Mathf.Clamp(clampedPosition.y + movementDirection *
                    Config.GenericEnemyMovementMultiplier * Time.fixedDeltaTime,
                    screenBorderDetector.bottomBorder, screenBorderDetector.upperBorder);
                clampedPosition.x = Mathf.Clamp(clampedPosition.x,
                    screenBorderDetector.leftBorder, screenBorderDetector.rightBorder);
                rb.transform.position = clampedPosition;
            }
        }
    }
}
