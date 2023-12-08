using System.Collections;
using Core.Scripts.Interfaces;
using Core.Scripts.States.Car.Models;
using UnityEngine;

namespace Core.Scripts.States.Car.States
{
    public class DeadState : IState
    {
        private readonly CarStateManager _car;

        private readonly DeadModel _deadModel;

        public DeadState(CarStateManager car, DeadModel deadModel)
        {
            _car = car;
            _deadModel = deadModel;
        }

        public void EnterState()
        {
            _deadModel.particle.Play();
            _car.StartCoroutine(Lose());
        }

        public void FinishState()
        {
        }

        public void UpdateState()
        {
        }

        public void OnTriggerState(Collider other)
        {
        }

        private IEnumerator Lose()
        {
            yield return new WaitForSeconds(2);
            _deadModel.actionPanelManager.OpenPanels(1);
        }
    }
}