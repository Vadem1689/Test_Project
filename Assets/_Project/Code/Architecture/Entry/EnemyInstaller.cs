using _Project.Code.Core.Characters;
using UnityEngine;
using Zenject;

namespace _Project.Code.Architecture
{
    public class EnemyInstaller : MonoInstaller
    {
        [SerializeField] private EnemySettings _enemySettings;
        
        public override void InstallBindings()
        {
            if (_enemySettings != null)
            {
                Container.BindInstance(_enemySettings).AsSingle();
            }
            else
            {
                Debug.LogWarning("EnemySettings not assigned to EnemyInstaller");
                Container.Bind<EnemySettings>().FromScriptableObjectResource("Settings/EnemySettings").AsSingle();
            }
        }
    }
}
