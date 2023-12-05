using System;
using UnityEngine;
using UnityEngine.AI;

namespace Core.Scripts.Bot.Zombie.Models
{
    [Serializable]
    public class MoveModel
    {
        public NavMeshAgent agent;
        public CapsuleCollider collider;
        [HideInInspector] public Transform target;
    }
}