using System.Collections;
using UnityEngine;
using Zenject;

namespace Core.Scripts.FactoryBomb
{
    public class FactoryBomb : MonoBehaviour
    {
        [SerializeField] private Factory _factoryBomb;
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
                    int countBomb = Random.Range(1, 3);

                    for (int i = 0; i < countBomb; i++)
                    {
                        // Vector3 pointSpawn = PointSpawn.GetRandomPoint(_plane, PointGenerationType.Random);
                        // pointSpawn = new Vector3(pointSpawn.x, 10, pointSpawn.z);
                        // _factoryBomb.Create<Bomb>(pointSpawn).Init();
                    }
                }

                yield return new WaitForSeconds(Random.Range(_minDelay, _maxDelay));
            }
        }
    }
}