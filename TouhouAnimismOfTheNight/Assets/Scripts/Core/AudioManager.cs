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
            bgMusic.volume = Config.MusicVolume;
        }

        private void InitAudioClips()
        {
            playerAtackFX = gameObject.AddComponent<AudioSource>();
            bgMusic = gameObject.AddComponent<AudioSource>();

            playerAtackFX.clip = Resources.Load<AudioClip>(Path.Combine("SFX", "Fire"));
            bgMusic.clip = Resources.Load<AudioClip>(Path.Combine("Music", "LivioAmato_Desiree"));

            playerAtackFX.playOnAwake = false;
            bgMusic.playOnAwake = false;

            playerAtackFX.loop = false;
            bgMusic.loop = true;
        }

        /// <summary>
        /// Play the sound effect for the player's attack
        /// </summary>
        public void PlayPlayerFireFX()
        {
            playerAtackFX.Play();
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
