using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

// Screen wipe transition between levels and the menu
namespace CS
{
    public enum TransitionMode { SLIDE, FADE };

    public class Transition : MonoBehaviour
    {
        public static Transition instance;
        public Transform SlideTransition;
        public float SlideTime;
        public CanvasGroup FadeTransition;
        public float FadeTime;

        public bool Enabled
        {
            get
            {
                return transitionsEnabled;
            }
            set
            {
                transitionsEnabled = value;
                gameObject.SetActive(value);
            }
        }
        private bool transitionsEnabled = true;
        private bool currentlyTransitioning = false; // Used when SlideIn has been called. This prevents transitions when the game first loads
        private Canvas _canvas;
        private Vector3 offScreenStart;
        private Vector3 offScreenEnd;
        private Vector3 onScreenPosition;
        private TransitionMode mode;

        private void Awake()
        {
            if (instance != null)
            {
                Destroy(this.gameObject);
                return;
            }
            else
            {
                instance = this;
            }
            DontDestroyOnLoad(this);
            _canvas = GetComponent<Canvas>();
            offScreenStart = new Vector3(Screen.width * 2, 0, 0);
            offScreenEnd = new Vector3(Screen.width * -2, 0, 0);
            onScreenPosition = Vector3.zero;
            SlideTransition.localPosition = offScreenStart;
        }

        private void OnEnable()
        {
            SceneManager.sceneLoaded += TEnd;
        }

        private void OnDisable()
        {
            SceneManager.sceneLoaded -= TEnd;
        }

        public void TStart(TransitionMode m)
        {
            mode = m;
            if (transitionsEnabled)
            {
                _canvas.enabled = true;
                currentlyTransitioning = true;
                if (mode == TransitionMode.SLIDE)
                    StartCoroutine(slideTransition(offScreenStart, onScreenPosition, SlideTime, false));
                else
                    StartCoroutine(fadeTransition(FadeTime, true));
            }
        }

        private void TEnd(Scene scene, LoadSceneMode mode)
        {
            if (currentlyTransitioning)
            {
                currentlyTransitioning = false;
                if (this.mode == TransitionMode.SLIDE)
                    StartCoroutine(slideTransition(onScreenPosition, offScreenEnd, SlideTime, true));
                else
                    StartCoroutine(fadeTransition(FadeTime, false));
            }
        }

        IEnumerator slideTransition(Vector3 startPos, Vector3 endPos, float t, bool transitionEnd)
        {
            float i = 0f;
            float rate = 1 / t;

            while (i < 1)
            {
                i += Time.deltaTime * rate;
                SlideTransition.localPosition = Vector3.Lerp(startPos, endPos, i);
                yield return null;
            }
            if (transitionEnd)
            {
                _canvas.enabled = false;
            }
        }

        IEnumerator fadeTransition(float t, bool fadeIn)
        {
            int direction = fadeIn == true ? 1 : -1;
            float timeElapsed = 0f;
            float rate = 1 / t;

            while (timeElapsed < t)
            {
                timeElapsed += Time.deltaTime;
                FadeTransition.alpha += rate * direction * Time.deltaTime;
                yield return null;
            }

            if (!fadeIn)
            {
                _canvas.enabled = false;
            }
        }
    }
}