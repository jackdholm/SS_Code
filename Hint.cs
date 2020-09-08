using UnityEngine;

namespace CS
{
    public class Hint : MonoBehaviour
    {
        public Transform HintText;
        public Transform WaitText;
        private Vector3 offScreenPosition;
        private Vector3 onScreenPosition;

        void Awake()
        {
            offScreenPosition = new Vector3(Screen.width * 2, 0, 0);
            onScreenPosition = Vector3.zero;
            HintText.position = offScreenPosition;
            WaitText.position = offScreenPosition;
        }

        public void showHint()
        {
            HintText.localPosition = onScreenPosition;
        }
    }
}