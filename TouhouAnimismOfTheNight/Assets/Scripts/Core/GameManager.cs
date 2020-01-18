using TH.Utilities;
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

        public bool isPaused = false;

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

        public void PlayerDeath()
        {
            Debug.Log("The player died :(");
        }

        public void ChangeScene(string scene)
        {
            SceneManager.LoadScene(scene);
        }

        public void PauseGame()
        {
            isPaused = !isPaused;
            UIManager.Instance.ShowPauseMenu();
        }

        public void ExitGame()
        {
            Application.Quit();
        }

        public bool IsOutOfBoundsCheck(Vector3 position)
        {
            var borderDetector = FindObjectOfType<ScreenBorderDetector>();
            float x = position.x;
            float y = position.y;
            float xl = borderDetector.leftBorder - 2f;
            float xr = borderDetector.rightBorder + 2f;
            float yu = borderDetector.upperBorder + 2f;
            float yb = borderDetector.bottomBorder - 2f;

            return x > xr || x < xl || y < yb || y > yu;
        }
    }
}
