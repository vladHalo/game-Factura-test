using Core.Scripts.Interfaces;
using Core.Scripts.Bot.Zombie.Models;
using Core.Scripts.Bot.Zombie.States;
using UnityEngine;

namespace Core.Scripts.Bot.Zombie
{
    public class ZombieStateManager : MonoBehaviour
    {
        public MoveState moveState;
        public DeadState deadState;

        [SerializeField] private Bot _bot;
        [SerializeField] private MoveModel _moveModel;
        [SerializeField] private DeadModel _deadModel;

        private IState _currentState;

        private void Start()
        {
            _bot.IsKinematic(true);
            moveState = new MoveState(this, _bot, _moveModel);
            deadState = new DeadState(this, _bot, _deadModel);
            _currentState = moveState;
        }

        private void Update()
        {
            _currentState.UpdateState();
        }

        private void OnCollisionEnter(Collision other)
        {
        }

        public void SetState(IState newState)
        {
            _currentState.FinishState();
            _currentState = newState;
            _currentState.EnterState();
        }

        public void Init(Transform target)
        {
            _currentState = moveState;
            _moveModel.target = target;
            _moveModel.agent.speed = .4f;
            _moveModel.collider.enabled = true;
            _bot.IsKinematic(true);
            _bot.rigidbody.isKinematic = false;
            _bot.animator.enabled = true;
            //_bot.animator.SetTrigger(Str.MoveZombie);
        }
    }
}