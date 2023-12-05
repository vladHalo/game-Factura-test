using System.Collections;
using Core.Scripts.Bot.Zombie;
using UnityEngine;
using Zenject;

namespace Core.Scripts.FactoryZombie
{
    public class FactoryZombie : MonoBehaviour
    {
        [SerializeField] private Factory _factoryZombie;
        [SerializeField] private float _minDelay, _maxDelay;
        [SerializeField] private Renderer _plane;

        [Inject] private GameManager _gameManager;

        private void Start()
        {
            StartCoroutine(Spawn());
        }

        private IEnumerator Spawn()
        {
            while (true)
            {
                if (_gameManager.statusGame == StatusGame.Play)
                {
                    int countZombie = Random.Range(1, 4);

                    for (int i = 0; i < countZombie; i++)
                    {
                        // Vector3 pointSpawn = PointSpawn.GetRandomPoint(_plane, PointGenerationType.Edge);
                        // var zombie = _factoryZombie.Create<ZombieStateManager>(pointSpawn);
                        // zombie.Init(_gameManager.player);
                        // zombie.transform.LookAt(_gameManager.player);
                    }
                }

                yield return new WaitForSeconds(Random.Range(_minDelay, _maxDelay));
            }
        }
    }
}