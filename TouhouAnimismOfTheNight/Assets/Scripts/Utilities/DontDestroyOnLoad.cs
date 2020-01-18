using UnityEngine;

namespace TH.Utilities
{
    public class DontDestroyOnLoad : MonoBehaviour
    {
        /// <summary>
        /// Singleton instance of <see cref="DontDestroyOnLoad"/>
        /// </summary>
        public static DontDestroyOnLoad Instance { get; set; }

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(this.gameObject);
            }
            else
            {
                Instance = this;
                DontDestroyOnLoad(this.gameObject);
            }
        }
    }
}
