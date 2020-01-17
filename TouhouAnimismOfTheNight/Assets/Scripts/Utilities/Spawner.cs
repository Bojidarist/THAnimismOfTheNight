using UnityEngine;

namespace TH.Utilities
{
    public class Spawner : MonoBehaviour
    {
        private void Start()
        {
            // Test with spawning player
            // Make sure the methods are called from another place
            // like GameManager
            SpawnPlayer(Vector3.zero);
            SpawnEnemy(Vector3.zero, EnemyType.SoriNoKanmushi);
        }

        public static GameObject SpawnPlayer(Vector3 position)
        {
            var prefab = Resources.Load<GameObject>(Config.SakuyaPrefabPath);
            prefab = Instantiate(prefab, position, Quaternion.identity);
            return prefab;
        }

        public static GameObject SpawnEnemy(Vector3 position, EnemyType type)
        {
            GameObject prefab = null;
            switch (type)
            {
                case EnemyType.Nigawarai:
                    prefab = Resources.Load<GameObject>(Config.NigawaraiPrefabPath);
                    break;
                case EnemyType.ShiroUneri:
                    prefab = Resources.Load<GameObject>(Config.ShiroUneriPrefabPath);
                    break;
                case EnemyType.SoriNoKanmushi:
                    prefab = Resources.Load<GameObject>(Config.SoriNoKanmushiPrefabPath);
                    break;
            }
            return Instantiate(prefab);
        }
    }
}
