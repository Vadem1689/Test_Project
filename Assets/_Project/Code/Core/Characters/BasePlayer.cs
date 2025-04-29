using _Project.Code.Architecture;
using _Project.Code.Core.Health;
using _Project.Code.Core.Motor.Jumping;
using _Project.Code.Core.Motor.Movement;
using _Project.Code.Core.Motor.Movement._2D;
using _Project.Code.Core.Motor.Velocity;
using UnityEngine;
using Zenject;

namespace _Project.Code.Core.Characters
{
    public abstract class BasePlayer : MonoBehaviour, IPlayer, IDamageable
    {
        [SerializeField] protected Transform _groundCheckPoint;
        [SerializeField] protected Transform _attackPoint;
        [SerializeField] protected PlayerSettings _settings;
        [SerializeField] protected float _maxHealth = 100f;
   
        [Inject] protected ICharacterInput _input;
        
        protected GroundChecker _groundChecker;
        protected Jumper _jumper;
        protected RigidBodyMover _mover;
        protected IComponentCollisionDetector _componentCollisionDetector;
        protected Attacker _attacker;
        protected Health.Health _health;

        public Vector3 Position => transform.position;
        public Quaternion Rotation => transform.rotation;

        protected virtual void Awake()
        {
            _health = new Health.Health(_maxHealth, _maxHealth);
            InitializeComponents();
        }

        protected abstract void InitializeComponents();

        protected virtual void FixedUpdate()
        {
            HandleMotor();
            HandleCollision();
        }

        protected virtual void HandleMotor()
        {
            if (_input.IsJumping && IsGrounded())
            {
                _jumper.Jump();
            }

            Vector3 direction = GetMovementDirection();
            _mover.Move(direction);
        }

        protected abstract Vector3 GetMovementDirection();

        protected virtual void HandleCollision()
        {
            CheckForEnemyCollision();
            CheckForLevelFinishCollision();
        }

        protected abstract void CheckForEnemyCollision();

        protected virtual void CheckForLevelFinishCollision()
        {
            if (_componentCollisionDetector.IsColliding(out LevelFinish levelFinish))
            {
                levelFinish.Trigger();
            }
        }

        public virtual bool IsGrounded()
        {
            return _groundChecker.IsGrounded();
        }

        public virtual void TakeDamage(float damage)
        {
            _health.TakeDamage(damage);
            
            if (_health.Value <= 0)
            {
                Die();
            }
        }

        protected virtual void Die()
        {
            gameObject.SetActive(false);
        }
    }
}
