using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Core.Scripts.States.Car
{
    public class Upgrade : MonoBehaviour
    {
        [SerializeField] private List<UpgradeModel> _upgradeModel;

        [Inject] private GameManager _gameManager;

        private void Start()
        {
            for (int i = 0; i < _upgradeModel.Count; i++)
            {
                if (ES3.KeyExists(_upgradeModel[i].name))
                    _upgradeModel[i].indexUpgrade = ES3.Load<int>(_upgradeModel[i].name);
                if (i == (int)UpgradeType.HP)
                {
                    _gameManager.SetHP();
                }
            }
        }

        public void UpgradeStats(int index)
        {
            _upgradeModel[index].indexUpgrade++;
            ES3.Save(_upgradeModel[index].name, _upgradeModel[index].indexUpgrade);
            if (index == (int)UpgradeType.HP)
            {
                _gameManager.SetHP();
            }
        }

        public int GetUpgrade(int index) => _upgradeModel[index].indexUpgrade;
    }

    [Serializable]
    class UpgradeModel
    {
        public string name;
        public int indexUpgrade;
    }
}