using UnityEngine;

namespace _Project.Code.Core.Motor.Movement._2D
{
    public class GroundChecker 
    {
        private readonly Transform _groundCheckPoint;
        private readonly bool _is2D;
        private readonly float _rayLength;

        public GroundChecker(Transform groundCheckPoint, bool is2D = false, float rayLength = 0.1f)
        {
            _groundCheckPoint = groundCheckPoint;
            _is2D = is2D;
            _rayLength = rayLength;
        }

        public bool IsGrounded()
        {
            if (_groundCheckPoint == null)
                return false;
                
            return _is2D
                ? Physics2D.Raycast(_groundCheckPoint.position, Vector2.down, _rayLength)
                : Physics.Raycast(_groundCheckPoint.position, Vector3.down, _rayLength);
        }
    }
}
