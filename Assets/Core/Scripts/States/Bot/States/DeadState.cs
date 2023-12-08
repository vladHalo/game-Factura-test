using Core.Scripts.States.Bot.Models;
using Lean.Pool;
using UnityEngine;
using IState = Core.Scripts.Interfaces.IState;

namespace Core.Scripts.States.Bot.States
{
    public class DeadState : IState
    {
        private readonly BotStateManager _bot;

        private readonly DeadModel _deadModel;
        private float _startSpeed;

        public DeadState(BotStateManager bot, DeadModel deadModel)
        {
            _bot = bot;
            _deadModel = deadModel;
            _startSpeed = _bot.agent.speed;
        }

        public void EnterState()
        {
            _bot.animator.enabled = false;
            IsKinematic(false);
            LeanPool.Despawn(_bot.gameObject, 4f);
            _bot.gameManager.factoryCoin.Spawn(_bot.transform.position);
            _deadModel.collider.enabled = false;
            _deadModel.rigidbody.isKinematic = true;
            _bot.audioManager.PlaySoundEffect(SoundType.Dead);
            _deadModel.particle.Play();
            _bot.agent.speed = 0;
        }

        public void FinishState()
        {
            _bot.animator.enabled = true;
            IsKinematic(true);
            _deadModel.collider.enabled = true;
            _deadModel.rigidbody.isKinematic = false;
            _bot.agent.speed = _startSpeed;
        }

        public void OnTriggerState(Collider other)
        {
        }

        public void UpdateState()
        {
        }

        public void IsKinematic(bool enable)
        {
            for (int i = 0; i < _deadModel.rigidbodies.Length; i++)
                _deadModel.rigidbodies[i].isKinematic = enable;
        }
    }
}