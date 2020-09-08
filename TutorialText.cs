using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CS
{
    public class TutorialText : MonoBehaviour
    {
        private Canvas _canvas;

        private void Awake()
        {
            _canvas = GetComponent<Canvas>();
        }

        private void OnEnable()
        {
            GoalManager.Event_LevelEnd += hide;
        }

        private void OnDisable()
        {
            GoalManager.Event_LevelEnd -= hide;
        }

        private void hide()
        {
            _canvas.enabled = false;
        }
    }
}