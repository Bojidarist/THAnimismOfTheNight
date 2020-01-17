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
            SpawnPlayer(Vector3.zero, Quaternion.identity);
            SpawnEnemy(Vector3.zero, Quaternion.identity, EnemyType.SoriNoKanmushi);
        }

        /// <summary>
        /// Spawn a player character
        /// </summary>
        /// <param name="position">The spawn position of the player character</param>
        /// <param name="rotation">The rotation of the player character</param>
        /// <returns>The player <see cref="GameObject"/></returns>
        public static GameObject SpawnPlayer(Vector3 position, Quaternion rotation)
        {
            var prefab = Resources.Load<GameObject>(Config.SakuyaPrefabPath);
            prefab = Instantiate(prefab, position, rotation);
            return prefab;
        }

        /// <summary>
        /// Spawn a enemy character
        /// </summary>
        /// <param name="position">The spawn position of the enemy character</param>
        /// <param name="rotation">The rotation of the enemy character</param>
        /// <param name="type">The type of the enemy character</param>
        /// <returns>The enemy <see cref="GameObject"/></returns>
        public static GameObject SpawnEnemy(Vector3 position, Quaternion rotation, EnemyType type)
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
            return Instantiate(prefab, position, rotation);
        }
    }
}
