using UnityEngine;

namespace CS
{
    public class TutorialTransition : MonoBehaviour
    {
        public Transform Camera;
        public Vector3 CameraLocation;
        public GameObject Controller1;
        public GameObject Controller2;
        
        private void OnTriggerEnter(Collider other)
        {
            Camera.localPosition = CameraLocation;
            Controller1.SetActive(false);
            Controller2.SetActive(true);
        }
    }
}