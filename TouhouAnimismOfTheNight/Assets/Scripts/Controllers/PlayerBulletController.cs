using TH.Core;
using TH.Utilities;
using UnityEngine;

namespace TH.Controllers
{
    public class PlayerBulletController : MonoBehaviour
    {
        private Rigidbody2D rb;
        private Vector3 position;
        private ScreenBorderDetector borderDetector;

        public Vector2 direction;

        private void Start()
        {
            borderDetector = FindObjectOfType<ScreenBorderDetector>();
            rb = GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void Update()
        {
            if (!GameManager.Instance.isPaused)
            {
                float x = transform.position.x;
                float y = transform.position.y;
                float xl = borderDetector.leftBorder - 2f;
                float xr = borderDetector.rightBorder + 2f;
                float yu = borderDetector.upperBorder + 2f;
                float yb = borderDetector.bottomBorder - 2f;
                if (x > xr || x < xl || y < yb || y > yu)
                {
                    Destroy(this.gameObject);
                }
                rb.velocity = direction * Config.GenericBulletSpeedMultiplier * Time.deltaTime;
                position = transform.position;
            }
            else
            {
                rb.velocity = new Vector2(0, 0);
                transform.position = position;
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "EnemyProjectile")
            {
                Destroy(this.gameObject);
                Destroy(collision.gameObject);
            }
        }
    }
}
