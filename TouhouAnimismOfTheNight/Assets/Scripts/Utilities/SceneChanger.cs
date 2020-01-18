using TH.Core;
using UnityEngine;

namespace TH.Utilities
{
    public class SceneChanger : MonoBehaviour
    {
        /// <summary>
        /// Changes the current scene to Main Menu
        /// </summary>
        public void MainMenu()
        {
            GameManager.Instance.ChangeScene(SceneNames.MainMenu);
        }

        /// <summary>
        /// Changes the current scene to the Main(gameplay) Scene
        /// </summary>
        public void MainScene()
        {
            GameManager.Instance.ChangeScene(SceneNames.MainScene);
        }
    }
}
