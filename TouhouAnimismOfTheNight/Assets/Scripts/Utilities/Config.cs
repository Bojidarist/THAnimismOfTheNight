﻿using System.IO;
using UnityEngine;

namespace TH.Utilities
{
    public struct Config
    {
        public static float SFXVolume = 0.5f;
        public static float MusicVolume = 0.5f;

        public static float GenericMovementMultiplier = 3.2f;
        public static float FocusMovementMultiplier = 0.4f;
        public static float FocusHitboxSize = 0.05f;
        public static Vector2 FocusHitboxSize2D = new Vector2(FocusHitboxSize, FocusHitboxSize);
        public static float GenericEnemyMovementMultiplier = 1f;
        public static float GenericBulletSpeedMultiplier = 1f;
        public static float PlayerXOffsetFromBorder = 1f;
        public static float EnemyXOffsetFromRightBorder = 0.5f;
        public static float TimeBetweenWave = 60f;
        public static int WaveLimit = 10;
        public static ulong NewBombScore = 30000;
        public static bool IsTutorialPlayed = false;

        public static Vector2 EnemyShootLeftDirection = new Vector2(-180, 0);
        public static Vector2 EnemyShootLeftUpDirection = new Vector2(-180, 35);
        public static Vector2 EnemyShootLeftTopDirection = new Vector2(-180, 70);
        public static Vector2 EnemyShootLeftDownDirection = new Vector2(-180, -35);

        public static KeyCode FocusMovementKey = KeyCode.LeftShift;
        public static KeyCode PlayerShootKey = KeyCode.Z;
        public static KeyCode PlayerBombKey = KeyCode.X;
        public static KeyCode PauseKey = KeyCode.Escape;

        public static string PrefabsPath = "Prefabs";
        public static string SakuyaPrefabPath = Path.Combine(PrefabsPath, "Sakuya");
        public static string NigawaraiPrefabPath = Path.Combine(PrefabsPath, "Nigawarai");
        public static string ShiroUneriPrefabPath = Path.Combine(PrefabsPath, "ShiroUneri");
        public static string SoriNoKanmushiPrefabPath = Path.Combine(PrefabsPath, "SoriNoKanmushi");
    }
}
