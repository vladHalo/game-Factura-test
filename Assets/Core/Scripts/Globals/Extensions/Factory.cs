using System;
using Lean.Pool;
using UnityEngine;

[Serializable]
public class Factory
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private Transform _parent;

    public T Create<T>(Vector3 position, Quaternion rotate)
    {
        return LeanPool.Spawn(_prefab, position, rotate, _parent).GetComponent<T>();
    }
}