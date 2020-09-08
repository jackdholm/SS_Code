using UnityEngine;

namespace CS
{
    [System.Serializable]
    public class Level
    {
        public string name;
        public bool unlocked;
        public int moveRecord = -1;
        public int moveTarget;
        public bool perfect = false;
    }
}