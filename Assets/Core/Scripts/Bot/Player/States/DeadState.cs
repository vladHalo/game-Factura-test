using System.Collections;
using Core.Scripts.Interfaces;
using Core.Scripts.Bot.Player.Models;
using UnityEngine;

namespace Core.Scripts.Bot.Player.States
{
    public class DeadState : IState
    {
        private readonly PlayerStateManager _player;

        private readonly Bot _bot;
        private readonly DeadModel _deadModel;
        private readonly GameManager _gameManager;

        public DeadState(PlayerStateManager player, Bot bot, DeadModel deadModel, GameManager gameManager)
        {
            _player = player;
            _bot = bot;
            _deadModel = deadModel;
            _gameManager = gameManager;
        }

        public void EnterState()
        {
            //AudioManager.instance.PlaySoundEffect(SoundType.DeadMan);
            _bot.Dead();
            //_gameManager.ChangeStatusGame(StatusGame.Stop);
            _player.StartCoroutine(Lose());
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
        }

        public void OnCollisionEnter()
        {
            throw new System.NotImplementedException();
        }

        public void OnCollisionState(Collision other)
        {
        }

        private IEnumerator Lose()
        {
            yield return new WaitForSeconds(2);
            _deadModel.actionPanelManager.OpenPanels(0);
        }
    }
}