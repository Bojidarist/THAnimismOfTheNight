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
        public GameObject bullet;

        /// <summary>
        /// The rate of fire
        /// </summary>
        public float fireRate;

        /// <summary>
        /// The <see cref="EnemyController"/> that is shooting
        /// </summary>
        private EnemyController enemyController;

        private void Start()
        {
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
                        SpawnBullet(new Vector2(-180, 0));
                        return;
                    }
                    int rng = Random.Range(0, 2);
                    if (rng == 0)
                    {
                        ShotgunPattern();
                    }
                    else
                    {
                        SpawnBullet(new Vector2(-180, 0));
                    }
                }
            }
        }

        /// <summary>
        /// Fires shotgun pattern
        /// </summary>
        public void ShotgunPattern()
        {
            SpawnBullet(new Vector2(-180, 0));
            SpawnBullet(new Vector2(-180, 35));
            SpawnBullet(new Vector2(-180, 70));
            SpawnBullet(new Vector2(-180, -35));
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
