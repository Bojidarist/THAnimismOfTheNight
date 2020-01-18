using TH.Core;
using UnityEngine;

namespace TH.Utilities
{
    public class SceneChanger : MonoBehaviour
    {
        public void MainMenu()
        {
            GameManager.Instance.ChangeScene(SceneNames.MainMenu);
        }

        public void MainScene()
        {
            GameManager.Instance.ChangeScene(SceneNames.MainScene);
        }
    }
}
