using System;
using UnityEngine;
using UnityEngine.AI;

namespace Core.Scripts.States.Bot.Models
{
    [Serializable]
    public class DeadModel
    {
        public Rigidbody rigidbody;
        public Rigidbody[] rigidbodies;
        public Collider collider;
        public ParticleSystem particle;
    }
}