using System.Collections;
using UnityEngine;

namespace _Project.Code.Core.Characters
{
    public class Enemy2D : BaseEnemy
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private float _flashDuration = 0.1f;

        protected override IEnumerator OnDamageEffect()
        {
            if (_spriteRenderer != null)
            {
                _spriteRenderer.color = Color.red;
                yield return new WaitForSeconds(_flashDuration);
                _spriteRenderer.color = Color.white;
            }
            else
            {
                yield return null;
            }
        }
    }
}
