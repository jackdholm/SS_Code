using UnityEngine;

namespace CS
{
    public class EndParticles : MonoBehaviour
    {
        public ParticleSystem Particles;

        private void OnEnable()
        {
            GoalManager.Event_LevelEnd += startParticles;
            ResetLevel.Event_ResetLevel += resetParticles;
        }

        private void OnDisable()
        {
            GoalManager.Event_LevelEnd -= startParticles;
            ResetLevel.Event_ResetLevel -= resetParticles;
        }

        private void startParticles()
        {
            Particles.Play();
        }

        public void resetParticles()
        {
            Particles.Stop();
        }
    }
}