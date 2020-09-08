using UnityEngine;
// Moves a slider back in case of an unseen collision
namespace CS
{
    public class BounceBack : MonoBehaviour
    {
        public MoveableObject Slider;

        private void OnTriggerEnter(Collider other)
        {
            Slider.moveBack();
        }
    }
}
