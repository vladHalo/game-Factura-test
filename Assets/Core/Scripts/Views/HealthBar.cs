using UnityEngine;
using UnityEngine.UI;

namespace Core.Scripts.Views
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private Gradient _gradient;
        [SerializeField] private Slider _slider;
        [SerializeField] private Image _fill;
        [SerializeField] private Renderer _renderer;

        public void SetMaxHealth(int health)
        {
            if (_slider != null && _fill != null)
            {
                _slider.value = health;
                _slider.maxValue = health;
                _fill.color = _gradient.Evaluate(1f);
            }

            if (_renderer != null)
            {
                _renderer.material.color = _gradient.Evaluate(1f);
            }
        }

        public void SetHealth(int health)
        {
            if (_slider != null && _fill != null)
            {
                _slider.gameObject.SetActive(true);
                _slider.value = health;
                _fill.color = _gradient.Evaluate(_slider.normalizedValue);
            }

            if (_renderer != null)
            {
                _renderer.material.color = _gradient.Evaluate(_slider.normalizedValue);
            }
        }
    }
}