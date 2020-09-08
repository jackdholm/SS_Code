using System.Collections;
using UnityEngine;
//white screen flash
namespace CS
{
    public class Flash : MonoBehaviour
    {
        public float Speed;
        private CanvasGroup _screen;

        private void Start()
        {
            _screen = GetComponent<CanvasGroup>();
        }

        public void Play()
        {
            _screen.alpha = 1f;
            StartCoroutine(flash());
        }

        IEnumerator flash()
        {
            while (_screen.alpha > 0)
            {
                _screen.alpha -= Speed * Time.deltaTime;
                yield return null;
            }
        }
    }
}