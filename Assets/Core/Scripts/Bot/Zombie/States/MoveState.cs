using Core.Scripts.Bot.Player;
using Core.Scripts.Interfaces;
using Core.Scripts.Bot.Zombie.Models;
using UnityEngine;

namespace Core.Scripts.Bot.Zombie.States
{
    public class MoveState : IState
    {
        private readonly ZombieStateManager _zombie;

        private readonly Bot _bot;
        private readonly MoveModel _moveModel;

        public MoveState(ZombieStateManager zombie, Bot bot, MoveModel moveModel)
        {
            _zombie = zombie;
            _bot = bot;
            _moveModel = moveModel;
        }

        public void EnterState()
        {
            
        }

        public void FinishState()
        {
            _moveModel.agent.speed = 0;
            _moveModel.collider.enabled = false;
        }

        public void OnCollisionState(Collision other)
        {
            if (other.gameObject.TryGetComponent(out PlayerStateManager player))
            {
                //_bot.animator.SetTrigger(Str.AttackZombie);
            }
        }

        public void UpdateState()
        {
            _moveModel.agent.SetDestination(_moveModel.target.position);
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