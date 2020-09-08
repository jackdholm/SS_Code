using UnityEngine;

// Sets the page number of the level select screen

namespace CS
{
    public class PageSet : MonoBehaviour
    {
        private ScrollSnapRect lsScreen;

        private void Awake()
        {
            lsScreen = GetComponent<ScrollSnapRect>();
            lsScreen.startingPage = LevelSelector.instance.CurrentPage;
        }
    }
}