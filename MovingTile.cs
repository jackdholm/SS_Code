using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CS
{
    public enum Direction { UP, DOWN, LEFT, RIGHT };

    public class MovingTile : MonoBehaviour
    {
        public Direction Direction;
        private Vector3 moveDirection;
        private Vector3 startPosition;

        private void Awake()
        {
            startPosition = transform.position;
            startPosition.y += 0.1f;
            switch(Direction)
            {
                case Direction.UP:
                    moveDirection = Vector3.forward;
                    break;
                case Direction.DOWN:
                    moveDirection = Vector3.back;
                    break;
                case Direction.LEFT:
                    moveDirection = Vector3.left;
                    break;
                case Direction.RIGHT:
                    moveDirection = Vector3.right;
                    break;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            // This doesn't use the recursive moveCheck because if another object is in the way it doesn't matter if it's capable of moving
            if (other.CompareTag("Player"))
            {
                other.gameObject.GetComponent<MoveableObject>().addDirection(startPosition, moveDirection);
            }
        }
    }
}