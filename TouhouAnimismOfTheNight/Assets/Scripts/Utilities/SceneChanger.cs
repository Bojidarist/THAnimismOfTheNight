using System;
using TH.Core;
using UnityEngine;

namespace TH.Utilities
{
    public class SceneChanger : MonoBehaviour
    {
        private Waiter waiter;

        public Animator transition;
        public float transitionTime = 1f;

        private void Awake()
        {
            waiter = FindObjectOfType<Waiter>();
        }

        public void PlayOpeningTransition(Action callback = null)
        {
            transition.SetBool("Start", true);
            waiter.InvokeAfterSeconds(() =>
            {
                if (callback != null)
                {
                    callback.Invoke();
                }
            }, transitionTime);
        }

        public void PlayClosingTransition(Action callback = null)
        {
            transition.SetBool("Start", false);
            waiter.InvokeAfterSeconds(() =>
            {
                if (callback != null)
                {
                    callback.Invoke();
                }
            }, transitionTime);
        }

        /// <summary>
        /// Changes the current scene to Main Menu
        /// </summary>
        public void MainMenu(bool transition = false)
        {
            if (transition)
            {
                PlayClosingTransition(() =>
                {
                    GameManager.Instance.ChangeScene(SceneNames.MainMenu);
                });
            }
            else
            {
                GameManager.Instance.ChangeScene(SceneNames.MainMenu);
            }
        }

        /// <summary>
        /// Changes the current scene to the Main(gameplay) Scene
        /// </summary>
        public void MainScene(bool transition = false)
        {
            if (transition)
            {
                PlayClosingTransition(() =>
                {
                    GameManager.Instance.ChangeScene(SceneNames.MainScene);
                });
            }
            else
            {
                GameManager.Instance.ChangeScene(SceneNames.MainScene);
            }
        }

        /// <summary>
        /// Changes the current scene to the tutorial
        /// </summary>
        public void TutorialScene(bool transition = false)
        {
            if (transition)
            {
                PlayClosingTransition(() =>
                {
                    GameManager.Instance.ChangeScene(SceneNames.TutorialScene);
                });
            }
            else
            {
                GameManager.Instance.ChangeScene(SceneNames.TutorialScene);
            }
        }

        /// <summary>
        /// Manages which scene should be loaded when 'start' is pressed
        /// </summary>
        public void StartGame()
        {
            if (Config.IsTutorialPlayed)
            {
                MainScene(true);
            }
            else
            {
                TutorialScene(true);
                Config.IsTutorialPlayed = true;
            }
        }
    }
}
