using UnityEngine;

namespace _Project.Code.Core.Characters
{
    public interface IPlayer
    {
        Vector3 Position { get; }
        Quaternion Rotation { get; }
        void TakeDamage(float damage);
        bool IsGrounded();
    }
}
