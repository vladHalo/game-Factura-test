using Core.Scripts.Interfaces;
using Core.Scripts.States.Car.Models;
using Core.Scripts.States.Car.States;
using UnityEngine;
using Zenject;

namespace Core.Scripts.States.Car
{
    public class CarStateManager : MonoBehaviour
    {
        public HP hp;
        public Transform damagePoint;

        public ShotState shotState;
        public DeadState deadState;

        [SerializeField] private ShotModel _shotModel;
        [SerializeField] private DeadModel _deadModel;

        [Inject] private AudioManager _audioManager;
        [Inject] private GameManager _gameManager;
        private IState _currentState;

        private void Start()
        {
            hp.healthBar.SetMaxHealth(hp.hp);
            shotState = new ShotState(this, _shotModel, _gameManager, _audioManager);
            deadState = new DeadState(this, _deadModel);
        }

        private void Update()
        {
            if (_currentState != null)
                _currentState.UpdateState();
        }

        private void OnTriggerEnter(Collider other)
        {
            _currentState.OnTriggerState(other);
        }

        public void SetState(IState newState)
        {
            if (_currentState != null)
                _currentState.FinishState();
            _currentState = newState;
            _currentState.EnterState();
        }
    }
}