using UnityEngine;

namespace TH.Utilities
{
    public class SceneOpeningTransition : MonoBehaviour
    {
        private SceneChanger sceneChanger;

        private void Awake()
        {
            sceneChanger = FindObjectOfType<SceneChanger>();
        }

        // Start is called before the first frame update
        void Start()
        {
            sceneChanger.PlayOpeningTransition();
        }
    }
}
