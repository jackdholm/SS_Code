using System.Collections;
using UnityEngine;

namespace CS
{
    public class EndMenu : MonoBehaviour
    {
        public GameObject NextLevelButton;
        public MoveCounter Counter;
        public float EndWaitTime;
        public float FadeSpeed;
        public AudioSource Source;
        public AudioClip EndSound;

        private CanvasGroup _menu;
        private Vector3 offScreenPosition;
        private Vector3 onScreenPosition;

        private void Awake()
        {
            _menu = GetComponent<CanvasGroup>();
            offScreenPosition = new Vector3(0, Screen.height * 2);
            onScreenPosition = Vector3.zero;
            _menu.transform.localPosition = offScreenPosition;
            Source.clip = EndSound;
        }
        private void OnEnable()
        {
            GoalManager.Event_LevelEnd += openMenu;
        }

        private void OnDisable()
        {
            GoalManager.Event_LevelEnd -= openMenu;
        }

        private void openMenu()
        {
            LevelSelector.instance.setComplete();
          //  _menu.transform.localPosition = onScreenPosition;
            if (LevelSelector.instance.completedLevelIsLast())
            {

                NextLevelButton.SetActive(false);
            }
            else
            {
                NextLevelButton.SetActive(true);
            }
            Counter.moveRecord();
            StartCoroutine(fadeInMenu());
            Source.Play();
        }

        IEnumerator fadeInMenu()
        {
            yield return new WaitForSeconds(EndWaitTime);
            while (_menu.transform.localPosition.y >= 0.2f || _menu.transform.localPosition.y <= -0.2f)
            {
                _menu.transform.localPosition = Vector3.Lerp(transform.localPosition, onScreenPosition, Time.deltaTime*FadeSpeed);
                //_menu.alpha += FadeSpeed * Time.deltaTime;
                yield return null;
            }
            _menu.transform.localPosition = onScreenPosition;
        }

        public void closeMenu()
        {
            StopAllCoroutines();
            _menu.transform.localPosition = offScreenPosition;
        }
    }
}