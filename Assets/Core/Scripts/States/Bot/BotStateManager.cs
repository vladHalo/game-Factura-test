using Core.Scripts.Interfaces;
using Core.Scripts.Map;
using Core.Scripts.States.Bot.Models;
using Core.Scripts.States.Bot.States;
using Lean.Pool;
using UnityEngine;
using UnityEngine.AI;

namespace Core.Scripts.States.Bot
{
    public class BotStateManager : MonoBehaviour
    {
        public MoveState moveState;
        public DeadState deadState;
        public Animator animator;
        public NavMeshAgent agent;
        
        [SerializeField] private HP hp;
        [HideInInspector] public GameManager gameManager;
        [HideInInspector] public AudioManager audioManager;

        [SerializeField] private MoveModel _moveModel;
        [SerializeField] private DeadModel _deadModel;

        private IState _currentState;

        private void Awake()
        {
            hp.healthBar.SetMaxHealth(hp.hp);
            moveState = new MoveState(this, _moveModel);
            deadState = new DeadState(this, _deadModel);
            _currentState = moveState;
        }

        private void Update()
        {
            _currentState.UpdateState();
        }

        private void OnTriggerEnter(Collider other)
        {
            _currentState.OnTriggerState(other);
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.TryGetComponent(out Bullet bullet))
            {
                hp.SetDamage(gameManager.upgrade.GetUpgrade((int)UpgradeType.Damage));
                if (hp.hp <= 0)
                {
                    SetState(deadState);
                }

                LeanPool.Despawn(bullet);
            }
        }

        public void SetState(IState newState)
        {
            _currentState = newState;
            _currentState.EnterState();
        }

        public void Init(GameManager game, AudioManager audio)
        {
            gameManager = game;
            audioManager = audio;
            animator.SetTrigger(Str.Idle);
            SetState(moveState);
        }
    }
}