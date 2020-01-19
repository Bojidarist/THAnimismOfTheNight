using UnityEngine;
using UnityEngine.UI;

namespace TH.Core
{
    public class UIManager : MonoBehaviour
    {
        /// <summary>
        /// Singleton instance of <see cref="UIManager"/>
        /// </summary>
        public static UIManager Instance { get; set; }

        /// <summary>
        /// The main menu UI object
        /// </summary>
        [SerializeField]
        public GameObject mainMenu;

        /// <summary>
        /// The options menu UI object
        /// </summary>
        [SerializeField]
        public GameObject optionsMenu;

        /// <summary>
        /// The pause menu UI object
        /// </summary>
        [SerializeField]
        public GameObject pauseMenu;

        /// <summary>
        /// The score text
        /// </summary>
        [SerializeField]
        public Text scoreText;

        [SerializeField]
        public Text knifesText;

        [SerializeField]
        public Text bombsText;

        /// <summary>
        /// The death menu
        /// </summary>
        [SerializeField]
        public GameObject youDiedMenu;

        /// <summary>
        /// The score display for when the player dies
        /// </summary>
        [SerializeField]
        public Text youDiedScore;

        [SerializeField]
        public GameObject howToPlayMenu;

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

        #region Show methods

        public void ShowHowToPlayMenu()
        {
            howToPlayMenu.SetActive(true);
        }

        /// <summary>
        /// Shows the score UI
        /// </summary>
        public void ShowScore()
        {
            scoreText.gameObject.SetActive(true);
        }

        public void ShowKnifesCount()
        {
            knifesText.gameObject.SetActive(true);
        }

        public void ShowBombsCount()
        {
            bombsText.gameObject.SetActive(true);
        }

        /// <summary>
        /// Shows the death screen
        /// </summary>
        /// <param name="score">The score displayed on the death screen</param>
        public void ShowDeathMenu(ulong score)
        {
            youDiedScore.text = $"Score: { score }";
            youDiedMenu.SetActive(true);
        }

        /// <summary>
        /// Shows the main menu UI
        /// </summary>
        public void ShowMainMenu()
        {
            HideOptionsMenu();
            HidePauseMenu();
            mainMenu.SetActive(true);
        }

        /// <summary>
        /// Shows the options UI
        /// </summary>
        public void ShowOptionsMenu()
        {
            HideMainMenu();
            HidePauseMenu();
            optionsMenu.SetActive(true);
        }

        /// <summary>
        /// Shows the pause menu UI
        /// </summary>
        public void ShowPauseMenu()
        {
            pauseMenu.SetActive(GameManager.Instance.isPaused);
        }

        #endregion

        #region Hide methods

        public void HideHowToPlayMenu()
        {
            howToPlayMenu.SetActive(false);
        }

        /// <summary>
        /// Hides the score UI
        /// </summary>
        public void HideScore()
        {
            scoreText.gameObject.SetActive(false);
        }

        public void HideKnifesCount()
        {
            knifesText.gameObject.SetActive(false);
        }

        public void HideBombsCount()
        {
            bombsText.gameObject.SetActive(false);
        }

        /// <summary>
        /// Hides the death screen
        /// </summary>
        public void HideDeathMenu()
        {
            youDiedMenu.SetActive(false);
        }

        /// <summary>
        /// Hides the main menu UI
        /// </summary>
        public void HideMainMenu()
        {
            mainMenu.SetActive(false);
        }

        /// <summary>
        /// Hides the options UI
        /// </summary>
        public void HideOptionsMenu()
        {
            optionsMenu.SetActive(false);
        }

        /// <summary>
        /// Hides the pause menu UI
        /// </summary>
        public void HidePauseMenu()
        {
            pauseMenu.SetActive(false);
        }

        #endregion

        #region Update methods

        /// <summary>
        /// Updates the score's text
        /// </summary>
        /// <param name="score">The new score</param>
        public void UpdateScore(ulong score)
        {
            scoreText.text = $"Score: { score }";
        }

        public void UpdateKnifes(int knifes)
        {
            knifesText.text = $"Knifes: { knifes }";
        }

        public void UpdateBombs(int bombs)
        {
            bombsText.text = $"Bombs: { bombs }";
        }

        #endregion
    }
}
