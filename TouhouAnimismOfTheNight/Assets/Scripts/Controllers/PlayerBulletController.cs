﻿using TH.Core;
using TH.Utilities;
using UnityEngine;

namespace TH.Controllers
{
    public class PlayerBulletController : MonoBehaviour
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
        /// The bullet's direction
        /// </summary>
        public Vector2 direction;

        private void Awake()
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
                    return;
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
