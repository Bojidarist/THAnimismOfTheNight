using TH.Controllers;
using TH.Core;
using UnityEngine;

namespace TH
{
    public class PlayerShots : MonoBehaviour
    {
        /// <summary>
        /// The bullet <see cref="GameObject"/>
        /// </summary>
        public GameObject bullet;

        /// <summary>
        /// The current number of bullets the player has
        /// </summary>
        public int numberOfBullets = 0;

        /// <summary>
        /// The current number of bombs the player has
        /// </summary>
        public int numberOfBombs = 3;

        /// <summary>
        /// Shoots a bullet
        /// </summary>
        public void Shoot()
        {
            if (numberOfBullets > 0)
            {
                SpawnBullet(new Vector2(180, 0));
                numberOfBullets--;
                AudioManager.Instance.PlayPlayerFireFX();
            }
        }

        /// <summary>
        /// Removes all enemy projectiles from the screen
        /// </summary>
        public void Bomb()
        {
            if (numberOfBombs > 0)
            {
                var bullets = FindObjectsOfType<EnemyBulletController>();
                foreach (var bullet in bullets)
                {
                    Destroy(bullet.gameObject);
                }
                numberOfBombs--;
            }
        }

        /// <summary>
        /// Spawns a bullet
        /// </summary>
        /// <param name="direction">The direction of the bullet</param>
        public void SpawnBullet(Vector2 direction)
        {
            var temp = Instantiate(bullet, transform.position, Quaternion.identity);
            var bController = temp.GetComponent<PlayerBulletController>();
            bController.direction = direction;
        }
    }
}