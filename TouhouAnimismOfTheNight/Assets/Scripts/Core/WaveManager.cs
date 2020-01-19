using System.Collections.Generic;
using TH.Utilities;
using UnityEngine;

namespace TH.Core
{
    public class WaveManager : MonoBehaviour
    {
        private ScreenBorderDetector borderDetector;
        private Waiter waiter;
        private int wave = 1;
        private bool isNextWave = true;
        private List<GameObject> enemies;
        private float playerSpawnX;
        private float enemySpawnX;
        private System.Array enemyTypes;

        void Start()
        {
            enemies = new List<GameObject>();
            waiter = FindObjectOfType<Waiter>();
            borderDetector = FindObjectOfType<ScreenBorderDetector>();
            playerSpawnX = borderDetector.leftBorder + Config.PlayerXOffsetFromRightBorder;
            enemySpawnX = borderDetector.rightBorder - Config.EnemyXOffsetFromRightBorder;
            enemyTypes = System.Enum.GetValues(typeof(EnemyType));
            Spawner.SpawnPlayer(new Vector3(playerSpawnX, 0), Quaternion.identity);
        }

        void Update()
        {
            if (isNextWave)
            {
                if (wave > Config.EnemyLimit)
                {
                    wave = Config.EnemyLimit;
                }
                for (int i = 0; i < wave; i++)
                {
                    enemies.Add(Spawner.SpawnEnemy(new Vector3(enemySpawnX, Random.Range(borderDetector.bottomBorder, borderDetector.upperBorder)),
                        Quaternion.identity, (EnemyType)enemyTypes.GetValue(Random.Range(0, enemyTypes.Length))));
                }
                isNextWave = false;
                waiter.InvokeForSeconds(() =>
                {
                    wave++;
                    for (int i = 0; i < enemies.Count; i++)
                    {
                        Destroy(enemies[i].gameObject);
                    }
                    isNextWave = true;
                }, Config.TimeBetweenWave);
            }
        }
    }
}
