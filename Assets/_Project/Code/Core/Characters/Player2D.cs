using _Project.Code.Architecture;
using _Project.Code.Core.Characters;
using _Project.Code.Core.Motor.Jumping;
using _Project.Code.Core.Motor.Movement;
using _Project.Code.Core.Motor.Movement._2D;
using _Project.Code.Core.Motor.Velocity;
using UnityEngine;
using Zenject;

namespace _Project.Code.Core
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Player2D : BasePlayer
    {
        [Inject] private PlayerSettings _playerSettings;
        
        protected override void InitializeComponents()
        {
            var rigidbody = GetComponent<Rigidbody2D>();
            var velocity = new UniversalRigidbodyVelocity(rigidbody);

            float moveSpeed = _settings != null ? _settings.MoveSpeed : _playerSettings.MoveSpeed;
            float jumpForce = _settings != null ? _settings.JumpForce : _playerSettings.JumpForce;
            float attackDamage = _settings != null ? _settings.AttackDamage : _playerSettings.AttackDamage;
            float attackRadius = _settings != null ? _settings.AttackRadius : _playerSettings.AttackRadius;

            _mover = new RigidBodyMover(velocity, moveSpeed);
            _jumper = new Jumper(velocity, jumpForce);
            _groundChecker = new GroundChecker(_groundCheckPoint, true);

            _componentCollisionDetector = new OverlapCollisionDetector2D(_attackPoint, attackRadius, ~0);
            _attacker = new Attacker(attackDamage);
        }

        protected override Vector3 GetMovementDirection()
        {
            return new Vector3(_input.Axis.x, 0, 0);
        }

        protected override void CheckForEnemyCollision()
        {
            if (_componentCollisionDetector.IsColliding(out Enemy2D enemy))
            {
                _attacker.Attack(enemy);
            }
        }
    }
}
