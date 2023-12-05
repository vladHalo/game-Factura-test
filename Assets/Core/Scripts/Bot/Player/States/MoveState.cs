using Core.Scripts.Interfaces;
using Core.Scripts.Bot.Player.Models;
using Core.Scripts.Bot.Zombie;
using UnityEngine;

namespace Core.Scripts.Bot.Player.States
{
    public class MoveState : IState
    {
        private readonly PlayerStateManager _player;

        private readonly Bot _bot;
        private readonly MoveModel _moveModel;

        public MoveState(PlayerStateManager player, Bot bot, MoveModel moveModel)
        {
            _player = player;
            _bot = bot;
            _moveModel = moveModel;
        }

        public void EnterState()
        {
            _bot.IsKinematic(true);
        }

        public void FinishState()
        {
        }

        public void UpdateState()
        {
            throw new System.NotImplementedException();
        }

        public void FixedUpdateState()
        {
            throw new System.NotImplementedException();
        }

        public void OnCollisionEnter()
        {
            throw new System.NotImplementedException();
        }

        public void OnCollisionState(Collision other)
        {
            if (other.gameObject.TryGetComponent(out ZombieStateManager zombie))
            {
                _player.SetState(_player.deadState);
            }
        }
    }
}