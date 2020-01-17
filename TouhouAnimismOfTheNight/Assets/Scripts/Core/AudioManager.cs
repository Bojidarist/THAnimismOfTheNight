using UnityEngine;

namespace THCore
{
    public class AudioManager : MonoBehaviour
    {
        /// <summary>
        /// The singleton instance of <see cref="AudioManager"/>
        /// </summary>
        public static AudioManager Instance { get; set; }

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(this.gameObject);
            }
            else
            {
                Instance = this;
            }
        }
    }
}
