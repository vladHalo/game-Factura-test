using Lean.Pool;
using UnityEngine;

namespace Core.Scripts.Map
{
    public class MoveCoin : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private Vector3 _height;

        private float _time;
        private Transform _firstPoint, _lastPoint;

        private void Update()
        {
            BezierMove();
        }

        public void SetPointMove(Transform firstPoint, Transform lastPoint)
        {
            _firstPoint = firstPoint;
            _lastPoint = lastPoint;
            transform.position = firstPoint.position;
            _time = 0;
        }

        private void BezierMove()
        {
            transform.position = Bezier.GetPoint(
                _firstPoint.position,
                new Vector3(_firstPoint.position.x, _firstPoint.position.y,
                    _firstPoint.position.z),
                new Vector3(_lastPoint.position.x + _height.x, _lastPoint.position.y + _height.y,
                    _lastPoint.position.z),
                _lastPoint.position, _time);

            _time = Mathf.Lerp(_time, 1f, _speed * Time.deltaTime);

            if (_time >= 1) LeanPool.Despawn(gameObject);
        }
    }
}