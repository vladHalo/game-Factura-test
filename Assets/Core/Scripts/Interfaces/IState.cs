namespace Core.Scripts.Interfaces
{
    public interface IState
    {
        void EnterState();
        void FinishState();
        void UpdateState();
        void FixedUpdateState();
        void OnCollisionEnter();
    }
}