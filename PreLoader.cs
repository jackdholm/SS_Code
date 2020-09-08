using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CS
{
    public class PreLoader : MonoBehaviour
    {
        private void Start()
        {
            if (LevelSelector.instance != null)
                LevelSelector.instance.destroy();
            if (ScreenLoader.instance != null)
                ScreenLoader.instance.destroy();
            StartCoroutine(load());
        }
        IEnumerator load()
        {
            AsyncOperation async = SceneManager.LoadSceneAsync("Menu");

            while (async.isDone == false)
            {
                yield return null;
            }
        }
    }
}