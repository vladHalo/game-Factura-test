using Core.Scripts.Interfaces;
using Core.Scripts.Bot.Player.Models;
using Core.Scripts.Bot.Player.States;
using UnityEngine;
using Zenject;

namespace Core.Scripts.Bot.Player
{
    public class PlayerStateManager : MonoBehaviour
    {
        public MoveState moveState;
        public DeadState deadState;

        [SerializeField] private Bot _bot;
        [SerializeField] private MoveModel _moveModel;
        [SerializeField] private DeadModel _deadModel;

        [Inject] private GameManager _gameManager;
        private IState _currentState;

        private void Start()
        {
            _bot.IsKinematic(true);
            moveState = new MoveState(this, _bot, _moveModel);
            deadState = new DeadState(this, _bot, _deadModel, _gameManager);
            _currentState = moveState;
        }

        private void FixedUpdate()
        {
            _currentState.FixedUpdateState();
        }

        public void SetState(IState newState)
        {
            _currentState.FinishState();
            _currentState = newState;
            _currentState.EnterState();
        }
    }
}