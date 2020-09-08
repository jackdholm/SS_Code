using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CS
{
    public class StandardControl : Controller
    {
        // Update is called once per frame
        void Update()
        {
            moveLeft = moveRight = moveUp = moveDown = false;
            if (Input.GetButtonDown("Left"))
                moveLeft = true;
            else if (Input.GetButtonDown("Right"))
                moveRight = true;
            else if (Input.GetButtonDown("Up"))
                moveUp = true;
            else if (Input.GetButtonDown("Down"))
                moveDown = true;
        }
    }
}
