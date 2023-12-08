using System;
using Core.Scripts.Views;
using UnityEngine;

namespace Core.Scripts.States.Car.Models
{
    [Serializable]
    public class DeadModel
    {
        public ActionPanelManager actionPanelManager;
        public ParticleSystem particle;
    }
}