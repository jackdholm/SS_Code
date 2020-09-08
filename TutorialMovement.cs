using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CS
{
    public class TutorialMovement : MonoBehaviour
    {
        public Controller controller;
        public TMPro.TMP_Text moveText;
        public GameObject goalText;
        public GameObject goalArrow;
        
        void Update()
        {
            if (controller.MoveLeft || controller.MoveRight || controller.MoveUp || controller.MoveDown)
            {
                goalText.SetActive(true);
                goalArrow.SetActive(true);
                gameObject.SetActive(false);
            }
        }
    }
}