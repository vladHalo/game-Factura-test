using UnityEngine;

namespace Core.Scripts.Map
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private TrailRenderer _trail;

        public void Init(Vector3 direction)
        {
            _trail.Clear();
            _rigidbody.velocity = direction * _speed;
        }
    }
}