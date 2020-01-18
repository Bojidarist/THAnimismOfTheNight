using UnityEngine;
using UnityEngine.SceneManagement;

namespace TH.Core
{
    public class GameManager : MonoBehaviour
    {
        /// <summary>
        /// Singleton instance of <see cref="GameManager"/>
        /// </summary>
        public static GameManager Instance { get; set; }

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

        public void ChangeScene(string scene)
        {
            SceneManager.LoadScene(scene);
        }

        public void ExitGame()
        {
            Application.Quit();
        }
    }
}
