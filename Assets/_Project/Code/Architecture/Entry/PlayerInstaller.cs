using _Project.Code.Core;
using _Project.Code.Core.Characters;
using UnityEngine;
using Zenject;

namespace _Project.Code.Architecture
{
    public class PlayerInstaller : MonoInstaller
    {
        [SerializeField] private PlayerSettings _playerSettings;
        
        public override void InstallBindings()
        {
            if (_playerSettings != null)
            {
                Container.BindInstance(_playerSettings).AsSingle();
            }
            else
            {
                Debug.LogWarning("PlayerSettings not assigned to PlayerInstaller");
                Container.Bind<PlayerSettings>().FromScriptableObjectResource("Settings/PlayerSettings").AsSingle();
            }
            
            string currentScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
            
            if (currentScene == SceneID.Gameplay2D.ToString())
            {
                Container.Bind<IPlayer>().To<Player2D>().FromComponentInHierarchy().AsSingle();
            }
            else if (currentScene == SceneID.Gameplay3D.ToString())
            {
                Container.Bind<IPlayer>().To<Player3D>().FromComponentInHierarchy().AsSingle();
            }
            else
            {
                Debug.LogWarning($"Unknown scene '{currentScene}' for player binding");
            }
        }
    }
}
