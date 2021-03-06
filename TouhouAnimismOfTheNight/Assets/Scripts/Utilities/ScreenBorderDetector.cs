﻿using UnityEngine;

namespace TH.Utilities
{
    public class ScreenBorderDetector : MonoBehaviour
    {
        /// <summary>
        /// The main <see cref="Camera"/> that will be used as reference
        /// </summary>
        [SerializeField] private Camera mainCamera = default;

        /// <summary>
        /// The coordinates for the left border of the screen
        /// </summary>
        [HideInInspector] public float leftBorder;

        /// <summary>
        /// The coordinates for the right border of the screen
        /// </summary>
        [HideInInspector] public float rightBorder;

        /// <summary>
        /// The coordinates for the upper border of the screen
        /// </summary>
        [HideInInspector] public float upperBorder;

        /// <summary>
        /// The coordinates for the bottom border of the screen
        /// </summary>
        [HideInInspector] public float bottomBorder;

        private void Awake()
        {
            if (mainCamera == null)
                return;

            // Initialize the values
            UpdateValues();
        }

        private void LateUpdate()
        {
            UpdateValues();
        }

        private void UpdateValues()
        {
            if (mainCamera == null)
                return;

            leftBorder = mainCamera.ViewportToWorldPoint(Vector3.zero).x;
            rightBorder = mainCamera.ViewportToWorldPoint(Vector3.right).x;
            upperBorder = mainCamera.ViewportToWorldPoint(Vector3.up).y;
            bottomBorder = mainCamera.ViewportToWorldPoint(Vector3.right).y;
        }
    }
}
