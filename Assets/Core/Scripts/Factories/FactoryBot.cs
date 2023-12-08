using Core.Scripts.States.Bot;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Core.Scripts.Factories
{
    public class FactoryBot : MonoBehaviour
    {
        [SerializeField] private Factory _factoryBot;
        [SerializeField] private Vector2 _widthMinMax, _lenghtMinMax;
        [SerializeField] private float _startLenght = 80;

        [Inject] private GameManager _gameManager;
        [Inject] private AudioManager _audioManager;

        private void Start()
        {
            Spawn();
        }

        private void Spawn()
        {
            for (int i = 0; i < _gameManager.GetIndexBot(); i++)
            {
                BotStateManager bot = _factoryBot.Create<BotStateManager>(RandomPosition(), Quaternion.identity);
                bot.Init(_gameManager, _audioManager);
            }
        }

        private Vector3 RandomPosition()
        {
            float width = Random.Range(_widthMinMax.x, _widthMinMax.y);
            _startLenght += Random.Range(_lenghtMinMax.x, _lenghtMinMax.y);
            return new Vector3(width, 0, _startLenght);
        }
    }
}