using UnityEngine;

namespace _Project.Code.Core.Characters
{
    [CreateAssetMenu(fileName = "PlayerSettings", menuName = "Game/Player Settings")]
    public class PlayerSettings : ScriptableObject
    {
        [SerializeField] private float _moveSpeed = 10f;
        [SerializeField] private float _rotationSpeed = 10f;
        [SerializeField] private float _jumpForce = 10f;
        [SerializeField] private float _attackDamage = 1f;
        [SerializeField] private float _attackRadius = 0.5f;

        public float MoveSpeed => _moveSpeed;
        public float RotationSpeed => _rotationSpeed;
        public float JumpForce => _jumpForce;
        public float AttackDamage => _attackDamage;
        public float AttackRadius => _attackRadius;
    }
}
