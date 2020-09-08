using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CS
{
    public class GoalManager : MonoBehaviour
    {
        public Goal[] goals;
        private int goalCount;
        public delegate void levelEnd();
        public static event levelEnd Event_LevelEnd;

        private void OnEnable()
        {
            goalCount = 0;
            foreach (Goal g in goals)
            {
                g.Event_PlayerEnterGoal += playerEnterGoal;
                g.Event_PlayerExitGoal += playerLeaveGoal;
            }
        }
        private void OnDisable()
        {
            foreach (Goal g in goals)
            {
                g.Event_PlayerEnterGoal -= playerEnterGoal;
                g.Event_PlayerExitGoal -= playerLeaveGoal;
            }
        }

        private void playerEnterGoal()
        {
            goalCount++;
            if (goalCount >= goals.Length)
            {
                Event_LevelEnd();
            }
        }
        private void playerLeaveGoal()
        {
            goalCount--;
        }

    }
}