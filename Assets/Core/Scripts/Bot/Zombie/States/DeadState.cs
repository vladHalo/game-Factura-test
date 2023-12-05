using Core.Scripts.Interfaces;
using Core.Scripts.Bot.Zombie.Models;
using Lean.Pool;
using UnityEngine;

namespace Core.Scripts.Bot.Zombie.States
{
    public class DeadState : IState
    {
        private readonly ZombieStateManager _zombie;

        private readonly Bot _bot;
        private readonly DeadModel _deadModel;

        public DeadState(ZombieStateManager zombie, Bot bot, DeadModel deadModel)
        {
            _zombie = zombie;
            _bot = bot;
            _deadModel = deadModel;
        }

        public void EnterState()
        {
            _bot.Dead();
            LeanPool.Despawn(_zombie.gameObject, 4f);
        }

        public void FinishState()
        {
        }

        public void OnCollisionState(Collision other)
        {
        }

        public void UpdateState()
        {
        }

        public void FixedUpdateState()
        {
            throw new System.NotImplementedException();
        }

        public void OnCollisionEnter()
        {
            throw new System.NotImplementedException();
        }
    }
}