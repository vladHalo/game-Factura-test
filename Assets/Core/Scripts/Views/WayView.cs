using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Core.Scripts.Views
{
    public class WayView : MonoBehaviour
    {
        [SerializeField] private Text _wayText;
        [SerializeField] private Image _bar;

        [Inject] private GameManager _gameManager;

        private float _way;

        public void AddProgressWay()
        {
            _way += Time.deltaTime;
            _wayText.text = _way.ToString("##") + "m";
            _bar.fillAmount = _way / _gameManager.GetWidthWay();
            if (_bar.fillAmount >= 1) _gameManager.Win();
        }
    }
}