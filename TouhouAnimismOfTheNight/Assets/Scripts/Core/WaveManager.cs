using System.Collections.Generic;
using TH.Utilities;
using UnityEngine;

namespace TH.Core
{
    public class WaveManager : MonoBehaviour
    {
        private ScreenBorderDetector borderDetector;
        private Waiter waiter;
        [SerializeField] private int wave = 1;
        private bool isNextWave = true;
        private bool shouldDestroy = false;
        private List<GameObject> enemies;
        private float playerSpawnX;
        private float enemySpawnX;
        private System.Array enemyTypes;
        private Vector3 enemySpawnPosition;

        private void Awake()
        {
            enemySpawnPosition = Vector3.zero;
            enemies = new List<GameObject>();
            waiter = FindObjectOfType<Waiter>();
            borderDetector = FindObjectOfType<ScreenBorderDetector>();
            enemyTypes = System.Enum.GetValues(typeof(EnemyType));
        }

        private void Start()
        {
            playerSpawnX = borderDetector.leftBorder + Config.PlayerXOffsetFromBorder;
            enemySpawnX = borderDetector.rightBorder - Config.EnemyXOffsetFromRightBorder;
            Spawner.SpawnPlayer(new Vector3(playerSpawnX, 0), Quaternion.identity);
        }

        private void Update()
        {
            if (isNextWave && !GameManager.Instance.isPaused)
            {
                if (shouldDestroy)
                {
                    for (int i = 0; i < enemies.Count; i++)
                    {
                        Destroy(enemies[i].gameObject);
                    }
                }
                if (wave > Config.WaveLimit) { wave = Config.WaveLimit; }
                for (int i = 0; i < wave; i++)
                {
                    enemySpawnPosition.x = enemySpawnX;
                    enemySpawnPosition.y = Random.Range(borderDetector.bottomBorder, borderDetector.upperBorder);
                    enemies.Add(Spawner.SpawnEnemy(enemySpawnPosition, Quaternion.identity,
                        (EnemyType)enemyTypes.GetValue(Random.Range(0, enemyTypes.Length))));
                }
                isNextWave = false;
                waiter.InvokeAfterSeconds(() =>
                {
                    wave++;
                    shouldDestroy = true;
                    isNextWave = true;
                }, Config.TimeBetweenWave);
            }
        }
    }
}
