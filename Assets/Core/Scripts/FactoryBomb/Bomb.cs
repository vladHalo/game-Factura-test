using System.Collections;
using System.Collections.Generic;
using Core.Scripts.Bot.Zombie;
using Lean.Pool;
using UnityEngine;

namespace Core.Scripts.FactoryBomb
{
    public class Bomb : MonoBehaviour
    {
        [SerializeField] private float _timeDetonation;
        [SerializeField] private ParticleSystem _particle;
        [SerializeField] private Renderer _renderer;
        [SerializeField] private List<ZombieStateManager> _zombies;

        private bool _isDetonation;

        public void Init()
        {
            _isDetonation = false;
            _renderer.material.color = Color.white;
            _zombies.Clear();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out ZombieStateManager zombie))
            {
                _zombies.Add(zombie);
                if (!_isDetonation)
                {
                    _isDetonation = true;
                    StartCoroutine(Detonation());
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out ZombieStateManager zombie))
            {
                _zombies.Remove(zombie);
            }
        }

        private IEnumerator Detonation()
        {
            float time = _timeDetonation;
            while (time > 0)
            {
                _renderer.material.color = _renderer.material.color == Color.white ? Color.red : Color.white;
                time -= .5f;
                yield return new WaitForSeconds(.5f);
            }

            //AudioManager.instance.PlaySoundEffect(SoundType.Bomb);
            _particle.Play();
            _zombies.ForEach(x => x.SetState(x.deadState));
            LeanPool.Despawn(gameObject, .4f);
        }
    }
}