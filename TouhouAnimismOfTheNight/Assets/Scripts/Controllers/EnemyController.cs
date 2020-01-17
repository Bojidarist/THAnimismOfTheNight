using TH.Utilities;
using UnityEngine;

namespace TH.Controllers
{
    public class EnemyController : MonoBehaviour
    {
        private Rigidbody2D rb;
        private int movementDirection = 1;
        private ScreenBorderDetector screenBorderDetector;

        // Start is called before the first frame update
        void Start()
        {
            // Initialize
            rb = GetComponent<Rigidbody2D>();
            screenBorderDetector = FindObjectOfType<ScreenBorderDetector>();
        }

        // Update is called once per frame
        void Update()
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
                Config.GenericEnemyMovementMultiplier * Time.deltaTime,
                screenBorderDetector.bottomBorder, screenBorderDetector.upperBorder);
            rb.transform.position = clampedPosition;
        }
    }
}
