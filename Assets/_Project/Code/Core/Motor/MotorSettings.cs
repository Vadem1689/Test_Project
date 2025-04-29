using UnityEngine;

namespace _Project.Code.Core.Motor
{
    [CreateAssetMenu(fileName = "MotorSettings", menuName = "Game/Motor Settings")]
    public class MotorSettings : ScriptableObject
    {
        [SerializeField] private float _groundCheckRayLength = 0.1f;
        [SerializeField] private float _collisionDetectionRadius = 0.5f;
        [SerializeField] private LayerMask _collisionDetectionLayerMask = ~0;

        public float GroundCheckRayLength => _groundCheckRayLength;
        public float CollisionDetectionRadius => _collisionDetectionRadius;
        public LayerMask CollisionDetectionLayerMask => _collisionDetectionLayerMask;
    }
}
