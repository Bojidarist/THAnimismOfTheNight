using TH.Controllers;
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
        /// Shoots a bullet
        /// </summary>
        public void Shoot()
        {
            if (numberOfBullets > 0)
            {
                SpawnBullet(new Vector2(180, 0));
                numberOfBullets--;
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