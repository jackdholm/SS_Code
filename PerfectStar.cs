using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CS
{
    public class PerfectStar : MonoBehaviour
    {
        public Transform Star;
        public float EndWaitTime;
        public float TransitionSpeed;
        public ParticleSystem Particles;
        public Flash FlashScreen;
        private Vector3 offScreenPosition;
        private Vector3 onScreenPosition;
        private AudioSource _source;

        private void Awake()
        {
            offScreenPosition = new Vector3(Screen.width * 2, 0);
            onScreenPosition = Vector3.zero;
            Star.localPosition = offScreenPosition;
            _source = GetComponent<AudioSource>();
        }

        public void showStar()
        {
            StartCoroutine(starSlideIn());
        }

        private IEnumerator starSlideIn()
        {
            yield return new WaitForSeconds(EndWaitTime);
            while (Star.localPosition.x >= 0.2f || Star.localPosition.x <= -0.2f)
            {
                Star.localPosition = Vector3.Lerp(Star.localPosition, onScreenPosition, Time.deltaTime * TransitionSpeed);
                yield return null;
            }
            Star.localPosition = onScreenPosition;
            _source.Play();
            Particles.Play();
            FlashScreen.Play();
        }

        public void resetStar()
        {
            StopAllCoroutines();
            Star.localPosition = offScreenPosition;
        }
    }
}