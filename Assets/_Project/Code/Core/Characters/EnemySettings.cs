using UnityEngine;

namespace _Project.Code.Core.Characters
{
    [CreateAssetMenu(fileName = "EnemySettings", menuName = "Game/Enemy Settings")]
    public class EnemySettings : ScriptableObject
    {
        [SerializeField] private float _healthValue = 3f;
        [SerializeField] private float _flashDuration = 0.1f;
        [SerializeField] private float _attackDamage = 1f;
        [SerializeField] private float _moveSpeed = 5f;

        public float HealthValue => _healthValue;
        public float FlashDuration => _flashDuration;
        public float AttackDamage => _attackDamage;
        public float MoveSpeed => _moveSpeed;
    }
}
