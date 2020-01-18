﻿using System.IO;
using UnityEngine;

namespace TH.Utilities
{
    public struct Config
    {
        public static float SFXVolume = 0.2f;
        public static float MusicVolume = 0.8f;
        public static float GenericMovementMultiplier = 4f;
        public static float FocusMovementMultiplier = 0.2f;
        public static float FocusHitboxSize = 0.1f;
        public static Vector2 FocusHitboxSize2D = new Vector2(FocusHitboxSize, FocusHitboxSize);
        public static float GenericEnemyMovementMultiplier = 1f;

        public static KeyCode FocusMovementKey = KeyCode.LeftShift;

        public static string PrefabsPath = "Prefabs";
        public static string SakuyaPrefabPath = Path.Combine(PrefabsPath, "Sakuya");
        public static string NigawaraiPrefabPath = Path.Combine(PrefabsPath, "Nigawarai");
        public static string ShiroUneriPrefabPath = Path.Combine(PrefabsPath, "ShiroUneri");
        public static string SoriNoKanmushiPrefabPath = Path.Combine(PrefabsPath, "SoriNoKanmushi");
    }
}
