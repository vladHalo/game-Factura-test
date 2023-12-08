using Sirenix.OdinInspector;
using UnityEngine;

namespace Core.Scripts.Map
{
    public class GenerateRoad : MonoBehaviour
    {
        [SerializeField] private int _countRoad, _width;
        [SerializeField] private Transform _parent;
        [SerializeField] private Transform _road;

        [Button]
        private void SpawnRoad()
        {
            float posZ = 0;
            for (int i = 0; i < _countRoad; i++)
            {
                Instantiate(_road, new Vector3(_road.position.x, _road.position.y, posZ),
                        _road.rotation, _parent).name = $"{i}";
                posZ += _width;
            }
        }
    }
}