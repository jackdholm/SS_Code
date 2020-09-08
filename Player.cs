using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CS
{
    public class Player : MonoBehaviour
    {
        bool moving = false;
        bool onHold = false; // used to prevent input at end of level or for special animations
        public MoveableObject[] objects;
        public delegate void beginMove(Vector3 direction);
        public static event beginMove Event_BeginMove;
        int numFinished;
        Controller controls;
        public MoveCounter counter;

        void Start()
        {
            controls = GetComponent<Controller>();
        }

        private void OnEnable()
        {
            GoalManager.Event_LevelEnd += hold;
            ResetLevel.Event_ResetLevel += resetLevel;
        }

        private void OnDisable()
        {
            GoalManager.Event_LevelEnd -= hold;
            ResetLevel.Event_ResetLevel -= resetLevel;
        }
        void Update()
        {
            if (!moving && !onHold)
            {
                getMovement();
            }
        }

        void getMovement()
        {
            //   float x = Input.GetAxis("Horizontal");
            //  float y = Input.GetAxis("Vertical");
            Vector3 movement = Vector3.zero;

            if (controls.MoveLeft)
            {
                movement = Vector3.left;
            }
            else if (controls.MoveRight)
            {
                movement = Vector3.right;
            }
            else if (controls.MoveUp)
            {
                movement = Vector3.forward;
            }
            else if (controls.MoveDown)
            {
                movement = Vector3.back;
            }
            if (movement != Vector3.zero)
            {
                moving = true;
                move(movement);
            }
        }

        void move(Vector3 direction)
        {
            numFinished = 0;
            foreach (MoveableObject o in objects)
            {
                if (o.flag == checkFlag.UNCHECKED)
                {
                    o.moveCheck(direction);
                }
            }
            Event_BeginMove(direction);
            if (counter != null)
            {
                counter.incrementMoveCount();
            }
        }

        public void finishMoving()
        {
            numFinished++;
            if (numFinished >= objects.Length)
                moving = false;
        }

        public void resetLevel()
        {
            moving = false;
            onHold = false;

            foreach (MoveableObject o in objects)
            {
                o.resetPosition();
                o.stopAnimation();
            }
        }

        void hold()
        {
            onHold = true;
        }
    }
}