using UnityEngine;

namespace Core.Scripts.Interfaces
{
    public interface IState
    {
        void EnterState();
        void FinishState();
        void UpdateState();
        void OnTriggerState(Collider other);
    }
}