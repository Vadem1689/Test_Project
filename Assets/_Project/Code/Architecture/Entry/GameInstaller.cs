using _Project.Code.Core.Motor;
using UnityEngine;
using Zenject;

namespace _Project.Code.Architecture
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private MotorSettings _motorSettings;
        
        public override void InstallBindings()
        {
            Container.Bind<ICharacterInput>().To<KeyboardCharacterInput>().AsSingle();
            Container.Bind<ISceneLoader>().To<DefaultSceneLoader>().AsSingle();
            Container.Bind<ResourcesLoader>().AsSingle();
            
            if (_motorSettings != null)
            {
                Container.BindInstance(_motorSettings).AsSingle();
            }
            else
            {
                Debug.LogWarning("MotorSettings not assigned to GameInstaller");
            }

            Container.Bind<CoroutinePerformer>()
                .FromComponentInNewPrefabResource(ResourcesPaths.CoroutinePerformerPath)
                .AsSingle();
            
            Container.Bind<LoadingCurtain>()
                .FromComponentInNewPrefabResource(ResourcesPaths.LoadingCurtainPath)
                .AsSingle();
        }
    }
}
