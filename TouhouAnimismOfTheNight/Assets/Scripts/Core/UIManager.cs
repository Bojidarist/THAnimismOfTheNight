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
        [SerializeField] private GameObject mainMenu = default;

        /// <summary>
        /// The options menu UI object
        /// </summary>
        [SerializeField] private GameObject optionsMenu = default;

        /// <summary>
        /// The pause menu UI object
        /// </summary>
        [SerializeField] private GameObject pauseMenu = default;

        /// <summary>
        /// The score text
        /// </summary>
        [SerializeField] private Text scoreText = default;

        /// <summary>
        /// The text displaying the amount of knifes left
        /// </summary>
        [SerializeField] private Text knifesText = default;


        /// <summary>
        /// The text displaying the amount of bombs left
        /// </summary>
        [SerializeField] private Text bombsText = default;

        /// <summary>
        /// The death menu
        /// </summary>
        [SerializeField] private GameObject youDiedMenu = default;

        /// <summary>
        /// The score display for when the player dies
        /// </summary>
        [SerializeField] private Text youDiedScore = default;

        /// <summary>
        /// The menu that displays when the How To Play button is clicked
        /// </summary>
        [SerializeField] private GameObject howToPlayMenu = default;

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

        /// <summary>
        /// Shows the How To Play menu
        /// </summary>
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

        /// <summary>
        /// Shows the knifes count UI
        /// </summary>
        public void ShowKnifesCount()
        {
            knifesText.gameObject.SetActive(true);
        }

        /// <summary>
        /// Shows the bomb count UI
        /// </summary>
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

        /// <summary>
        /// Hides the How To Play menu
        /// </summary>
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

        /// <summary>
        /// Hides the knife count UI
        /// </summary>
        public void HideKnifesCount()
        {
            knifesText.gameObject.SetActive(false);
        }

        /// <summary>
        /// Hides the bomb count UI
        /// </summary>
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

        /// <summary>
        /// Updates the knife count UI
        /// </summary>
        /// <param name="knifes">The amount of knifes</param>
        public void UpdateKnifes(int knifes)
        {
            knifesText.text = $"Knifes: { knifes }";
        }

        /// <summary>
        /// Updates the bomb count UI
        /// </summary>
        /// <param name="bombs">The amount of bombs</param>
        public void UpdateBombs(int bombs)
        {
            bombsText.text = $"Bombs: { bombs }";
        }

        #endregion
    }
}
