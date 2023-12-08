using Core.Scripts.Interfaces;
using Core.Scripts.States.Bot.Models;
using Core.Scripts.States.Car;
using UnityEngine;

namespace Core.Scripts.States.Bot.States
{
    public class MoveState : IState
    {
        private readonly BotStateManager _bot;

        private readonly MoveModel _moveModel;

        public MoveState(BotStateManager bot, MoveModel moveModel)
        {
            _bot = bot;
            _moveModel = moveModel;
        }

        public void EnterState()
        {
            
        }

        public void FinishState()
        {
            
        }

        public void OnTriggerState(Collider other)
        {
            if (other.gameObject.TryGetComponent(out CarStateManager car))
            {
                _bot.SetState(_bot.deadState);
            }
        }

        public void UpdateState()
        {
            if (Vector3.Distance(_bot.gameManager.carStateManager.transform.position,
                    _bot.transform.position) < 20)
            {
                _bot.agent.SetDestination(_bot.gameManager.carStateManager.damagePoint.position);
                _bot.animator.SetTrigger(Str.Run);
            }
        }
    }
}