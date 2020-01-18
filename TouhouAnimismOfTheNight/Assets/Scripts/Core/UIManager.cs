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
            mainMenu.SetActive(true);
        }

        public void ShowOptionsMenu()
        {
            HideMainMenu();
            optionsMenu.SetActive(true);
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

        #endregion
    }
}
