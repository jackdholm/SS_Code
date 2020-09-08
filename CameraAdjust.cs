using UnityEngine;
// Adjusts camera distance depending on aspect ratio
namespace CS
{
    public class CameraAdjust : MonoBehaviour
    {
        private Camera _camera;
        public float PortraitPosition;
        public float LandscapePosition;

        void Start()
        {
            _camera = GetComponent<Camera>();

            if (_camera.aspect < 1f) // Portrait
            {
                transform.position = new Vector3(transform.position.x, PortraitPosition, transform.position.z);
            }
            else // Landscape
            {
                transform.position = new Vector3(transform.position.x, LandscapePosition, transform.position.z);
            }
        }
    }
}