using System.IO;
using TH.Utilities;
using UnityEngine;

namespace TH.Core
{
    public class AudioManager : MonoBehaviour
    {
        /// <summary>
        /// The singleton instance of <see cref="AudioManager"/>
        /// </summary>
        public static AudioManager Instance { get; set; }

        /// <summary>
        /// The sound effect played when the player attacks
        /// </summary>
        private AudioSource playerAtackFX;

        /// <summary>
        /// The sound effect played when the player activates a bomb
        /// </summary>
        private AudioSource playerBombFX;

        /// <summary>
        /// The sound effect played when the player grazes
        /// </summary>
        private AudioSource playerGrazeFX;

        /// <summary>
        /// The sound effect played when an enemy attack
        /// </summary>
        private AudioSource enemyAtackFX;

        /// <summary>
        /// The background music
        /// </summary>
        private AudioSource bgMusic;

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(this.gameObject);
            }
            else
            {
                Instance = this;
                InitAudioClips();
            }
        }

        private void Update()
        {
            playerAtackFX.volume = Config.SFXVolume;
            playerBombFX.volume = Config.SFXVolume;
            enemyAtackFX.volume = Config.SFXVolume;
            bgMusic.volume = Config.MusicVolume;
        }

        private void InitAudioClips()
        {
            LoadSound(ref playerAtackFX, Path.Combine("SFX", "Fire"));
            LoadSound(ref playerBombFX, Path.Combine("SFX", "SPELLCARD"));
            LoadSound(ref playerGrazeFX, Path.Combine("SFX", "Graze"));
            LoadSound(ref enemyAtackFX, Path.Combine("SFX", "EnemyAttack"));
            LoadSound(ref bgMusic, Path.Combine("Music", "LivioAmato_Desiree"), true);
        }

        /// <summary>
        /// Load a sound from resources
        /// </summary>
        private void LoadSound(ref AudioSource src, string path, bool isLoop = false, bool playOnAwake = false, bool addComponent = true)
        {
            if (addComponent)
            {
                src = gameObject.AddComponent<AudioSource>();
            }
            src.clip = Resources.Load<AudioClip>(path);
            src.loop = isLoop;
            src.playOnAwake = playOnAwake;

        }

        /// <summary>
        /// Play the sound effect for the player's attack
        /// </summary>
        public void PlayPlayerFireFX()
        {
            playerAtackFX.Play();
        }

        /// <summary>
        /// Play the sound effect for the player's bombing adventures
        /// </summary>
        public void PlayPlayerBombFX()
        {
            playerBombFX.Play();
        }

        /// <summary>
        /// Play the sound effect when the player grazes
        /// </summary>
        public void PlayPlayerGrazeFX()
        {
            playerGrazeFX.Play();
        }

        /// <summary>
        /// Play the sound effect for the enemy's attack
        /// </summary>
        public void PlayEnemyAtackFX()
        {
            enemyAtackFX.Play();
        }

        /// <summary>
        /// Play the background music loop
        /// </summary>
        public void PlayBackgroundMusic()
        {
            bgMusic.Play();
        }
    }
}
