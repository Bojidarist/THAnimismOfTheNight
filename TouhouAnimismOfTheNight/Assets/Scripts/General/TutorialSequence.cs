using TH.Core;
using TH.Utilities;
using UnityEngine;
using UnityEngine.UI;

namespace TH
{
    public class TutorialSequence : MonoBehaviour
    {
        /// <summary>
        /// The <see cref="Waiter"/> used to execute the tutorial sequence
        /// </summary>
        private Waiter waiter;

        /// <summary>
        /// The X position of the enemy
        /// </summary>
        private float enemySpawnX;

        /// <summary>
        /// The <see cref="Text"/> used to display the tutorial tips
        /// </summary>
        [SerializeField] private Text tutorialText = default;

        /// <summary>
        /// The <see cref="ScreenBorderDetector"/>
        /// </summary>
        private ScreenBorderDetector borderDetector;

        /// <summary>
        /// The <see cref="SceneChanger"/> used for transitions
        /// </summary>
        private SceneChanger sceneChanger;

        /// <summary>
        /// The button that skips the tutorial
        /// </summary>
        [SerializeField] private Button skipButton = default;

        void Awake()
        {
            waiter = FindObjectOfType<Waiter>();
            sceneChanger = FindObjectOfType<SceneChanger>();
            borderDetector = FindObjectOfType<ScreenBorderDetector>();
        }

        private void Start()
        {
            UIManager.Instance.HideScore();
            UIManager.Instance.HideKnifesCount();
            UIManager.Instance.HideBombsCount();
            enemySpawnX = borderDetector.rightBorder - Config.EnemyXOffsetFromRightBorder;
            waiter.InvokeAfterSeconds(() =>
            {
                if (tutorialText == null)
                    return;
                Spawner.SpawnEnemy(new Vector3(enemySpawnX, 0), Quaternion.identity, EnemyType.Nigawarai);
                tutorialText.text = $"New enemy spawns every { Config.TimeBetweenWave } seconds";
            }, 10);
            waiter.InvokeAfterSeconds(() =>
            {
                if (tutorialText == null)
                    return;
                tutorialText.text = $"Focus using ({ Config.FocusMovementKey }) and move near enemy projectiles to get knifes";
            }, 20);
            waiter.InvokeAfterSeconds(() =>
            {
                if (tutorialText == null)
                    return;
                tutorialText.text = $"Knifes can destroy enemy projectiles ({ Config.PlayerShootKey })";
            }, 30);
            waiter.InvokeAfterSeconds(() =>
            {
                if (tutorialText == null)
                    return;
                tutorialText.text = $"Press ({ Config.PlayerBombKey }) to use a bomb";
            }, 40);
            waiter.InvokeAfterSeconds(() =>
            {
                if (tutorialText == null)
                    return;
                tutorialText.text = $"Every { Config.NewBombScore } score you get a bomb";
            }, 50);
            waiter.InvokeAfterSeconds(() =>
            {
                if (tutorialText == null)
                    return;
                tutorialText.text = "Survive, get high score, and have fun!";
            }, 60);
            waiter.InvokeAfterSeconds(() =>
            {
                if (tutorialText == null)
                    return;
                SkipTutorial();
            }, 70);
        }

        private void Update()
        {
            if (GameManager.Instance.isPaused)
            {
                GameManager.Instance.PauseGame();
            }
        }

        /// <summary>
        /// Skips the tutorial
        /// </summary>
        public void SkipTutorial()
        {
            tutorialText.gameObject.SetActive(false);
            skipButton.gameObject.SetActive(false);
            this.gameObject.SetActive(false);
            sceneChanger.MainScene(true);
        }
    }
}
