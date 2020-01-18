using TH.Controllers;
using UnityEngine;

namespace TH
{
    public class PlayerShots : MonoBehaviour
    {
        public GameObject bullet;
        public int numberOfBullets = 0;

        public void Shoot()
        {
            if (numberOfBullets > 0)
            {
                SpawnBullet(new Vector2(180, 0));
                numberOfBullets--;
            }
        }

        public void SpawnBullet(Vector2 direction)
        {
            var temp = Instantiate(bullet, transform.position, Quaternion.identity);
            var bController = temp.GetComponent<PlayerBulletController>();
            bController.direction = direction;
        }
    }
}