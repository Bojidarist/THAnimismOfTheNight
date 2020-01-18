using TH.Core;
using TH.Utilities;
using UnityEngine;

namespace TH.Controllers
{
    public class PlayerBulletController : MonoBehaviour
    {
        private Rigidbody2D rb;
        private Vector3 position;

        public Vector2 direction;

        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void Update()
        {
            if (!GameManager.Instance.isPaused)
            {
                if (GameManager.Instance.IsOutOfBoundsCheck(transform.position))
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
