using UnityEngine;
// Restricts level select buttons on UI depending on whether they've been unlocked
namespace CS
{
    public class ButtonLock : MonoBehaviour
    {
        public TMPro.TMP_Text NumberText;
        public TMPro.TMP_Text MovesText;
        public GameObject LockImage;
        public GameObject PerfectImage;
        public GameObject PerfectBorder;

        private UnityEngine.UI.Button button;

        public void Awake()
        {
            button = GetComponent<UnityEngine.UI.Button>();
        }
        public void lockLevel()
        {
            NumberText.gameObject.SetActive(false);
            MovesText.gameObject.SetActive(false);
            LockImage.gameObject.SetActive(true);
        }

        public void unlockLevel()
        {
            button.interactable = true;
            NumberText.gameObject.SetActive(true);
            MovesText.gameObject.SetActive(true);
            LockImage.gameObject.SetActive(false);
        }

        public void setLevelNumber(string s)
        {
            NumberText.text = s;
        }

        public void setMoves(string s)
        {
            MovesText.text = s;
        }
        
        public void setPerfect()
        {
            PerfectImage.SetActive(true);
            PerfectBorder.SetActive(true);
        }
    }

}