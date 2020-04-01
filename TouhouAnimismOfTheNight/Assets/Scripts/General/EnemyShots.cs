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

        private void Awake()
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
                        SpawnBullet(Config.EnemyShootLeftDirection);
                        return;
                    }
                    int rng = Random.Range(0, 2);
                    if (rng == 0)
                    {
                        StartCoroutine("ShotgunPattern");
                    }
                    else
                    {
                        SpawnBullet(Config.EnemyShootLeftDirection);
                    }
                }
            }
        }

        /// <summary>
        /// Fires shotgun pattern
        /// </summary>
        public void ShotgunPattern()
        {
            SpawnBullet(Config.EnemyShootLeftDirection);
            SpawnBullet(Config.EnemyShootLeftUpDirection);
            SpawnBullet(Config.EnemyShootLeftTopDirection);
            SpawnBullet(Config.EnemyShootLeftDownDirection);
            AudioManager.Instance.PlayEnemyAtackFX();
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
            AudioManager.Instance.PlayEnemyAtackFX();
        }
    }
}
