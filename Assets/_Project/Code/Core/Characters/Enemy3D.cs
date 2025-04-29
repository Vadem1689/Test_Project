using System.Collections;
using UnityEngine;

namespace _Project.Code.Core.Characters
{
    public class Enemy : BaseEnemy
    {
        [SerializeField] private SkinnedMeshRenderer[] _meshRenderers;
        [SerializeField] private MeshRenderer[] _meshRenderers2;
        [SerializeField] private float _flashDuration = 0.1f;

        protected override IEnumerator OnDamageEffect()
        {
            foreach (var renderer in _meshRenderers)
            {
                if (renderer != null)
                    renderer.material.color = Color.red;
            }
        
            foreach (var renderer in _meshRenderers2)
            {
                if (renderer != null)
                    renderer.material.color = Color.red;
            }
        
            yield return new WaitForSeconds(_flashDuration);
        
            foreach (var renderer in _meshRenderers)
            {
                if (renderer != null)
                    renderer.material.color = Color.white;
            }
       
            foreach (var renderer in _meshRenderers2)
            {
                if (renderer != null)
                    renderer.material.color = Color.white;
            }
        }
    }
}
