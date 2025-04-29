using System.Collections;
using _Project.Code.Architecture;
using UnityEngine;
using Zenject;

namespace _Project.Code.Core
{
    public class LevelFinish : MonoBehaviour
    {
        [Inject] private CoroutinePerformer _coroutineRunner;
        [Inject] private ISceneLoader _sceneLoader;
        [Inject] private LoadingCurtain _loadingCurtain;
        
        [SerializeField] private SceneID _nextSceneID = SceneID.Gameplay3D;
    
        private bool _isTriggered;

        public void Trigger()
        {
            if (_isTriggered) return;
            
            _coroutineRunner.StartPerform(SwitchScene());            
            
            _isTriggered = true;
        }
        
        public void Trgger()
        {
            Trigger();
        }
        
        private IEnumerator SwitchScene()
        {
            yield return _loadingCurtain.Show();
            yield return _sceneLoader.LoadAsync(_nextSceneID);
            yield return _loadingCurtain.Hide();
        }
    }
}
