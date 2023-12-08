using System;
using Core.Scripts.Factories;
using Core.Scripts.Views;
using UnityEngine;

namespace Core.Scripts.States.Car.Models
{
    [Serializable]
    public class ShotModel
    {
        public float moveSpeed;
        public float shotSpeed;
        public Transform aim;
        public Transform gun;
        public FactoryBullet factoryBullet;
        public RotateObjectController rotateObjectController;
        public WayView wayView;
    }
}