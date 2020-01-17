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
        }

        public static GameObject SpawnPlayer(Vector3 position)
        {
            var prefab = Resources.Load<GameObject>(Config.SakuyaPrefabPath);
            prefab = Instantiate(prefab, position, Quaternion.identity);
            return prefab;
        }
    }
}
