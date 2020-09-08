using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CS
{
    public class ClickSound : MonoBehaviour
    {
        public AudioSource Source;
        public AudioClip Clip;

        private void Awake()
        {
            Source.clip = Clip;
        }
        public void Play(float pitch)
        {
            Source.pitch = pitch;
            Source.Play();
        }
    }
}