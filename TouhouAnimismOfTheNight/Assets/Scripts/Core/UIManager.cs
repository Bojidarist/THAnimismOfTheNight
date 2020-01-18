using UnityEngine;

namespace TH.Core
{
    public class UIManager : MonoBehaviour
    {
        /// <summary>
        /// Singleton instance of <see cref="UIManager"/>
        /// </summary>
        public static UIManager Instance { get; set; }

        [SerializeField]
        public GameObject mainMenu;

        [SerializeField]
        public GameObject optionsMenu;

        [SerializeField]
        public GameObject pauseMenu;

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

        public void ShowMainMenu()
        {
            HideOptionsMenu();
            HidePauseMenu();
            mainMenu.SetActive(true);
        }

        public void ShowOptionsMenu()
        {
            HideMainMenu();
            HidePauseMenu();
            optionsMenu.SetActive(true);
        }

        public void ShowPauseMenu()
        {
            pauseMenu.SetActive(GameManager.Instance.isPaused);
        }

        #endregion

        #region Hide methods

        public void HideMainMenu()
        {
            mainMenu.SetActive(false);
        }

        public void HideOptionsMenu()
        {
            optionsMenu.SetActive(false);
        }

        public void HidePauseMenu()
        {
            pauseMenu.SetActive(false);
        }

        #endregion
    }
}
