using TH.Controllers;
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

        /// <summary>
        /// Indicates if the game is paused
        /// </summary>
        public bool isPaused = false;

        /// <summary>
        /// The player's score
        /// </summary>
        public ulong score = 0;

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

        private void Start()
        {
            AudioManager.Instance.PlayBackgroundMusic();
        }

        private void FixedUpdate()
        {
            if (SceneManager.GetActiveScene().name == SceneNames.MainScene && !isPaused)
            {
                score += 10;
                UIManager.Instance.UpdateScore(score);
            }
        }

        /// <summary>
        /// Handles the player's death
        /// </summary>
        public void PlayerDeath()
        {
            UIManager.Instance.HideScore();
            UIManager.Instance.ShowDeathMenu(score);
            FindObjectOfType<PlayerController>().gameObject.SetActive(false);
        }

        /// <summary>
        /// Handles the variables when the player spawns
        /// </summary>
        public void PlayerSpawned()
        {
            score = 0;
            UIManager.Instance.ShowScore();
        }

        /// <summary>
        /// Changes the current scene
        /// </summary>
        /// <param name="scene">The new scene</param>
        public void ChangeScene(string scene)
        {
            SceneManager.LoadScene(scene);
        }

        /// <summary>
        /// Handles game pause
        /// </summary>
        public void PauseGame()
        {
            isPaused = !isPaused;
            UIManager.Instance.ShowPauseMenu();
        }

        /// <summary>
        /// Handles exiting the game
        /// </summary>
        public void ExitGame()
        {
            Application.Quit();
        }

        /// <summary>
        /// Checks if the position is out of bounds
        /// </summary>
        /// <param name="position">The position to check</param>
        /// <param name="offset">The offset after the end of the screen</param>
        /// <returns>If the position is out of bounds</returns>
        public bool IsOutOfBoundsCheck(Vector3 position, float offset = 2f)
        {
            var borderDetector = FindObjectOfType<ScreenBorderDetector>();
            float x = position.x;
            float y = position.y;
            float xl = borderDetector.leftBorder - offset;
            float xr = borderDetector.rightBorder + offset;
            float yu = borderDetector.upperBorder + offset;
            float yb = borderDetector.bottomBorder - offset;

            return x > xr || x < xl || y < yb || y > yu;
        }
    }
}
