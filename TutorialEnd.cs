using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CS
{
    public class TutorialEnd : MonoBehaviour
    {
        public CanvasGroup fadeScreen;
        public float fadeSpeed;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                LevelSelector.instance.unlock(0);
                ScreenLoader.instance.LevelButtons[0].unlockLevel();
                ScreenLoader.instance.ContinueButton.setLoadTutorial();
                StartCoroutine(loadFirstLevel());
            }
        }

        IEnumerator loadFirstLevel()
        {
            Transition.instance.TStart(TransitionMode.FADE);
            yield return new WaitForSeconds(Transition.instance.FadeTime);
            LevelSelector.instance.loadHighest();
        }
    }
}