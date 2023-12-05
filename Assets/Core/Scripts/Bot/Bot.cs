using System;
using Sirenix.OdinInspector;
using Sirenix.Utilities;
using UnityEngine;

namespace Core.Scripts.Bot
{
    [Serializable]
    public class Bot
    {
        public Animator animator;
        public Rigidbody rigidbody;
        public ParticleSystem[] particlesDead;

        [SerializeField] private Rigidbody[] rigidbodies;

        public void IsKinematic(bool enable)
        {
            for (int i = 0; i < rigidbodies.Length; i++)
                rigidbodies[i].isKinematic = enable;
        }

        [Button]
        public void Dead()
        {
            particlesDead.ForEach(x => x.Play());
            animator.enabled = false;
            IsKinematic(false);
            rigidbody.isKinematic = true;
        }
    }
}