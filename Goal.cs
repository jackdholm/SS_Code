using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CS
{
    public class Goal : MonoBehaviour
    {
        public ObjectColor color;
        public delegate void playerGoal();
        public event playerGoal Event_PlayerEnterGoal;
        public event playerGoal Event_PlayerExitGoal;

        private void OnTriggerEnter(Collider other)
        {  
            if (other.gameObject.CompareTag("Player"))
            {
                if (other.gameObject.GetComponent<MoveableObject>().color == color)
                {
                    Event_PlayerEnterGoal();
                }
            }
        }
        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                if (other.gameObject.GetComponent<MoveableObject>().color == color)
                {
                    Event_PlayerExitGoal();
                }
            }
        }
    }
}
