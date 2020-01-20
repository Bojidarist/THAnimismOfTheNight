using TH.Controllers;
using TH.Core;
using TH.Utilities;
using UnityEngine;

namespace TH
{
    public class EnemyShots : MonoBehaviour
    {
        /// <summary>
        /// The next time the enemy will fire
        /// </summary>
        private float nextFire;

        /// <summary>
        /// The bullet <see cref="GameManager"/>
        /// </summary>
        [SerializeField] private GameObject bullet = default;

        /// <summary>
        /// The rate of fire
        /// </summary>
        [SerializeField] private float fireRate = default;

        /// <summary>
        /// The <see cref="EnemyController"/> that is shooting
        /// </summary>
        private EnemyController enemyController;

        // Shoot directions
        private Vector2 leftDirection;
        private Vector2 leftUpDirection;
        private Vector2 leftDownDirection;
        private Vector2 leftTopDirection;

        private void Awake()
        {
            leftDirection = new Vector2(-180, 0);
            leftUpDirection = new Vector2(-180, 35);
            leftTopDirection = new Vector2(-180, 70);
            leftDownDirection = new Vector2(-180, -35);
            enemyController = GetComponent<EnemyController>();
        }

        void Update()
        {
            if (!GameManager.Instance.isPaused)
            {
                if (Time.time > nextFire)
                {
                    nextFire = Time.time + fireRate;
                    if (enemyController.enemyType == EnemyType.ShiroUneri)
                    {
                        SpawnBullet(leftDirection);
                        return;
                    }
                    int rng = Random.Range(0, 2);
                    if (rng == 0)
                    {
                        StartCoroutine("ShotgunPattern");
                    }
                    else
                    {
                        SpawnBullet(leftDirection);
                    }
                }
            }
        }

        /// <summary>
        /// Fires shotgun pattern
        /// </summary>
        public void ShotgunPattern()
        {
            SpawnBullet(leftDirection);
            SpawnBullet(leftUpDirection);
            SpawnBullet(leftTopDirection);
            SpawnBullet(leftDownDirection);
        }

        /// <summary>
        /// Spawns a bullet
        /// </summary>
        /// <param name="direction">The direction of the bullet</param>
        public void SpawnBullet(Vector2 direction)
        {
            var temp = Instantiate(bullet, transform.position, Quaternion.identity);
            var bController = temp.GetComponent<EnemyBulletController>();
            bController.enemyType = enemyController.enemyType;
            bController.direction = direction;
        }
    }
}
