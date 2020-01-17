using UnityEngine;

namespace TH.Utilities
{
    public struct Config
    {
        public static float SFXVolume = 0.2f;
        public static float MusicVolume = 1f;
        public static float GenericMovementMultiplier = 7.5f;
        public static float FocusMovementMultiplier = 0.2f;
        public static float FocusHitboxSize = 0.1f;
        public static Vector2 FocusHitboxSize2D = new Vector2(FocusHitboxSize, FocusHitboxSize);
        public static KeyCode FocusMovementKey = KeyCode.LeftShift;
    }
}
