using System.Collections.Generic;
using Core.Scripts.States.Car;
using Core.Scripts.Views;
using Sirenix.Utilities;
using UnityEngine;

namespace Core.Scripts.Store
{
    public class StoreLogic : MonoBehaviour
    {
        [SerializeField] private ActionButtonUpgradeManager _actionButtonUpgradeManager;
        [SerializeField] private Upgrade _upgrade;
        [SerializeField] private StoreMoney _storeMoney;
        [SerializeField] private List<int> _prices;

        private void Start()
        {
            _storeMoney.Start();
            _actionButtonUpgradeManager.AddListener(CheckMoney);

            _prices.ForEach((x, index) => { _actionButtonUpgradeManager.ChangePriceText(index, _prices[index]); });
        }

        public void AddMoney(int count) => _storeMoney.Add(count);

        public void CheckMoney(int index)
        {
            if (_storeMoney.CanMinus(_prices[index]))
            {
                _actionButtonUpgradeManager.NextStep(index);
                _actionButtonUpgradeManager.ChangePriceText(index, _prices[index]);
                _upgrade.UpgradeStats(index);
            }
            else
            {
                StartCoroutine(_storeMoney.DelayFade());
                Debug.Log("Не вистачає грошей!");
            }
        }
    }
}