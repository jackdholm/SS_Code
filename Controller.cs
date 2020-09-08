using UnityEngine;

namespace CS
{
    public class Controller : MonoBehaviour
    {
        protected bool moveLeft, moveRight, moveUp, moveDown;
        
        public bool MoveLeft { get { return moveLeft; } }
        public bool MoveRight { get { return moveRight; } }
        public bool MoveUp { get { return moveUp; } }
        public bool MoveDown { get { return moveDown; } }
        
        private bool isDragging;
        private Vector2 startTouch, swipeDelta;
        private float deadZone;

        private void Awake()
        {
            deadZone = Sensitivity.value;
        }
        private void Update()
        {
#if (UNITY_STANDALONE || UNITY_EDITOR || UNITY_WEBGL)
            moveLeft = moveRight = moveUp = moveDown = false;
            if (Input.GetButtonDown("Left"))
                moveLeft = true;
            else if (Input.GetButtonDown("Right"))
                moveRight = true;
            else if (Input.GetButtonDown("Up"))
                moveUp = true;
            else if (Input.GetButtonDown("Down"))
                moveDown = true;
#endif
#if (UNITY_ANDROID || UNITY_IOS) // touchscreen swipe controls
            moveLeft = moveRight = moveUp = moveDown = false;

            if (Input.touchCount > 0)
            {
                if (Input.GetTouch(0).phase == TouchPhase.Began)
                {
                    isDragging = true;
                    startTouch = Input.touches[0].position;
                }
                else if (Input.GetTouch(0).phase == TouchPhase.Ended || Input.GetTouch(0).phase == TouchPhase.Canceled)
                {
                    isDragging = false;
                    Reset();
                }
            }

            swipeDelta = Vector2.zero;
            if (isDragging)
            {
                if (Input.touchCount > 0)
                {
                    swipeDelta = Input.GetTouch(0).position - startTouch;
                }
            }

            // Did it cross the deadzone
            if (swipeDelta.magnitude > deadZone)
            {
                float x = swipeDelta.x;
                float y = swipeDelta.y;
                if (Mathf.Abs(x) > Mathf.Abs(y))
                {
                    if (x < 0)
                        moveLeft = true;
                    else
                        moveRight = true;
                }
                else
                {
                    if (y < 0)
                        moveDown = true;
                    else
                        moveUp = true;
                }
                Reset();
            }
#endif

        }

        private void Reset()
        {
            startTouch = swipeDelta = Vector2.zero;
            isDragging = false;
        }
    }
}
