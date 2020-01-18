using TH.Controllers;
using TH.Core;
using TH.Utilities;
using UnityEngine;

public class EnemyShots : MonoBehaviour
{
    private float nextFire;

    public GameObject bullet;
    public float fireRate;
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

    public void ShotgunPattern()
    {
        SpawnBullet(new Vector2(-180, 0));
        SpawnBullet(new Vector2(-180, 35));
        SpawnBullet(new Vector2(-180, 70));
        SpawnBullet(new Vector2(-180, -35));
    }

    public void SpawnBullet(Vector2 direction)
    {
        var temp = Instantiate(bullet, transform.position, Quaternion.identity);
        var bController = temp.GetComponent<EnemyBulletController>();
        bController.enemyType = enemyController.enemyType;
        bController.direction = direction;
    }
}
