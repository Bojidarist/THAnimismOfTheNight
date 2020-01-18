using TH.Core;
using TH.Utilities;
using UnityEngine;

namespace TH.Controllers
{
    public class EnemyBulletController : MonoBehaviour
    {
        /// <summary>
        /// The bullet's <see cref="Rigidbody2D"/>
        /// </summary>
        private Rigidbody2D rb;

        /// <summary>
        /// The bullet's latest position
        /// </summary>
        private Vector3 position;

        /// <summary>
        /// The amount of spread in SpreadShot
        /// </summary>
        private int spreadShotOffset = 1;

        /// <summary>
        /// The direction of the bullet
        /// </summary>
        public Vector2 direction;

        /// <summary>
        /// The type of enemy firing this bullet
        /// </summary>
        [HideInInspector]
        public EnemyType enemyType;


        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            if (!GameManager.Instance.isPaused)
            {
                if (GameManager.Instance.IsOutOfBoundsCheck(transform.position))
                {
                    Destroy(this.gameObject);
                }
                switch (enemyType)
                {
                    case EnemyType.Nigawarai:
                        SpreadShot();
                        break;
                    case EnemyType.ShiroUneri:
                        NormalShot();
                        break;
                    case EnemyType.SoriNoKanmushi:
                        NormalShot();
                        break;
                    default:
                        return;
                }
            }
            else
            {
                rb.velocity = new Vector2(0, 0);
                transform.position = position;
            }
        }

        /// <summary>
        /// Normal shot calculation
        /// </summary>
        private void NormalShot()
        {
            rb.velocity = direction * Config.GenericBulletSpeedMultiplier * Time.deltaTime;
            position = transform.position;
        }

        /// <summary>
        /// Spread shot calculation
        /// </summary>
        private void SpreadShot()
        {
            direction.x -= spreadShotOffset;
            direction.y += spreadShotOffset;
            rb.velocity = direction * Config.GenericBulletSpeedMultiplier * 0.2f * Time.deltaTime;
            position = transform.position;
        }
    }
}
