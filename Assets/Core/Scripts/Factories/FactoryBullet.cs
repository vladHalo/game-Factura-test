using Core.Scripts.Map;
using Lean.Pool;
using UnityEngine;

namespace Core.Scripts.Factories
{
    public class FactoryBullet : MonoBehaviour
    {
        [SerializeField] private Factory _bulletFactory;

        public void Spawn(Transform aim, Quaternion rotate, Vector3 direction)
        {
            Bullet bullet = _bulletFactory.Create<Bullet>(aim.position, rotate);
            bullet.Init(direction);
            LeanPool.Despawn(bullet, 8);
        }
    }
}