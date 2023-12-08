using System.Collections;
using Core.Scripts.Interfaces;
using Core.Scripts.States.Bot;
using Core.Scripts.States.Car.Models;
using UnityEngine;

namespace Core.Scripts.States.Car.States
{
    public class ShotState : IState
    {
        private readonly CarStateManager _car;

        private readonly ShotModel _shotModel;

        private Vector2 _touchStartPosition;
        private GameManager _gameManager;
        private AudioManager _audioManager;
        private Coroutine _coroutine;

        public ShotState(CarStateManager car, ShotModel shotModel, GameManager gameManager, AudioManager audioManager)
        {
            _car = car;
            _shotModel = shotModel;
            _gameManager = gameManager;
            _audioManager = audioManager;
        }

        public void EnterState()
        {
            _coroutine = _car.StartCoroutine(ShotBullet());
        }

        public void FinishState()
        {
            _car.StopCoroutine(_coroutine);
        }

        public void UpdateState()
        {
            _car.transform.position += Vector3.forward * _shotModel.moveSpeed * Time.deltaTime;

            _shotModel.wayView.AddProgressWay();
#if UNITY_EDITOR
            _shotModel.rotateObjectController.MoveInPC();
#else
            _shotModel.rotateObjectController.MoveInMobile();
#endif
        }

        public void OnTriggerState(Collider other)
        {
            if (other.TryGetComponent(out BotStateManager bot))
            {
                _car.hp.SetDamage(1);
                if (_car.hp.hp <= 0) _car.SetState(_car.deadState);
            }
        }

        private IEnumerator ShotBullet()
        {
            while (true)
            {
                yield return new WaitForSeconds(_shotModel.shotSpeed -
                                                _gameManager.upgrade.GetUpgrade((int)UpgradeType.SpeedShot) * .1f);
                _shotModel.factoryBullet.Spawn(_shotModel.aim, Quaternion.identity, -_shotModel.gun.up);
                _audioManager.PlaySoundEffect(SoundType.Shot);
            }
        }
    }
}