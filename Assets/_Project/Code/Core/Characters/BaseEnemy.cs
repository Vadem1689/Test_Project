using System.Collections;
using _Project.Code.Core.Health;
using UnityEngine;

namespace _Project.Code.Core.Characters
{
    public abstract class BaseEnemy : MonoBehaviour, IDamageable
    {
        [SerializeField] protected float _healthValue = 3f;
        
        protected Health.Health _health;
        
        protected virtual void Awake()
        {
            _health = new Health.Health(_healthValue, _healthValue);
        }
        
        public virtual void TakeDamage(float damage)
        {
            _health.TakeDamage(damage);
            
            StartCoroutine(OnDamageEffect());
            
            if (_health.Value <= 0) Die();
        }
        
        protected abstract IEnumerator OnDamageEffect();
        
        protected virtual void Die()
        {
            Destroy(gameObject);
        }
    }
}
