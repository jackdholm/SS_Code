using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CS
{
    public enum checkFlag { UNCHECKED, MOVEABLE, UNMOVEABLE };
    public enum ObjectColor { RED, BLUE, GREEN };

    /// <summary>
    /// Player controlled slider objects
    /// </summary>
    public class MoveableObject : MonoBehaviour
    {
        Player _manager;
        public float moveSpeed = 5f;
        public LayerMask rayMask;
        public checkFlag flag = checkFlag.UNCHECKED;
        public ObjectColor color;
        private Vector3 originalPosition;
        private bool ended = false;
        private Vector3 nextDirection;
        private Vector3 previousPosition;
        Animator _animator;

        void Start()
        {
            _manager = GetComponentInParent<Player>();
            originalPosition = transform.position;
            _animator = GetComponent<Animator>();
        }

        private void OnEnable()
        {
            Player.Event_BeginMove += moveObject;
            GoalManager.Event_LevelEnd += endingAnimation;
        }

        private void OnDisable()
        {
            Player.Event_BeginMove -= moveObject;
            GoalManager.Event_LevelEnd -= endingAnimation;
        }

        public void resetPosition()
        {
            StopAllCoroutines();
            flag = checkFlag.UNCHECKED;
            transform.position = originalPosition;
        }
        public bool moveCheck(Vector3 direction)
        {
            RaycastHit hitInfo;
            bool canMove = false;

            if (Physics.Raycast(transform.position, direction, out hitInfo, 1f, rayMask))
            {
                if (hitInfo.transform.gameObject.CompareTag("Player")) // If the space it's moving to is occupied by another slider, checks to see if that slider is able to move
                {
                    bool nextIsMoveable = hitInfo.transform.GetComponent<MoveableObject>().moveCheck(direction);
                    if (nextIsMoveable)
                    {
                        flag = checkFlag.MOVEABLE;
                        canMove = true;
                    }
                    else
                    {
                        flag = checkFlag.UNMOVEABLE;
                        canMove = false;
                    }
                }
                else
                {
                    flag = checkFlag.UNMOVEABLE;
                    canMove = false;
                }
            }
            else
            {
                flag = checkFlag.MOVEABLE;
                canMove = true;
            }

            return canMove;
        }

        public IEnumerator move(Vector3 direction)
        {
            nextDirection = direction; // used to account for special events that move the slider an additional space.
            while (nextDirection != Vector3.zero)
            {
                Vector3 targetPos = transform.position + nextDirection;
                nextDirection = Vector3.zero;
                while (transform.position != targetPos)
                {
                    transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
                    yield return null;
                }
                previousPosition = transform.position;
            }
            flag = checkFlag.UNCHECKED;
            _manager.finishMoving();
        }

        void moveObject(Vector3 direction)
        {
            if (flag == checkFlag.MOVEABLE)
            {
                StartCoroutine(move(direction));
            }
            else
            {
                flag = checkFlag.UNCHECKED;
                _manager.finishMoving();
            }
        }
        void endingAnimation()
        {
            _animator.ResetTrigger("resetLevel");
            ended = true;
            _animator.SetTrigger("endLevel");
        }
        public void stopAnimation()
        {
            if (ended)
            {
                _animator.SetTrigger("resetLevel");
            }
        }

        public void addDirection(Vector3 startPosition, Vector3 dir)
        {
            if (!Physics.Raycast(transform.position, dir, 1.2f, rayMask))
            {
                nextDirection = dir;
            }
        }

        public void moveBack()
        {
            StopAllCoroutines();
            StartCoroutine(movePrevious());
        }

        IEnumerator movePrevious()
        {
            while (transform.position != previousPosition)
            {
                transform.position = Vector3.MoveTowards(transform.position, previousPosition, moveSpeed * Time.deltaTime);
                yield return null;
            }
            previousPosition = transform.position;
            flag = checkFlag.UNCHECKED;
            _manager.finishMoving();
        }
    }
}