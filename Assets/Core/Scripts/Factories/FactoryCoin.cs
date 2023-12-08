using System.Collections;
using Core.Scripts.Map;
using UnityEngine;
using Zenject;

namespace Core.Scripts.Factories
{
    public class FactoryCoin : MonoBehaviour
    {
        [SerializeField] private Factory _coinFactory;

        [Inject] private GameManager _gameManager;

        public void Spawn(Vector3 position)
        {
            MoveCoin moveCoin = _coinFactory.Create<MoveCoin>(position, Quaternion.identity);
            StartCoroutine(DelayMoveCoin(moveCoin));
        }

        private IEnumerator DelayMoveCoin(MoveCoin moveCoin)
        {
            moveCoin.SetPointMove(moveCoin.transform, _gameManager.carStateManager.transform);
            yield return new WaitForSeconds(1);
            _gameManager.storeLogic.AddMoney(1);
        }
    }
}