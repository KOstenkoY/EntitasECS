using UnityEngine;

namespace Runtime.Gameplay.Initializers
{
    public class GameplayInitializerBehaviour : MonoBehaviour
    {
        private GameplayInitializer _gameplayInitializer;

        private void Awake()
        {
            _gameplayInitializer = new GameplayInitializer(Contexts.sharedInstance);
            _gameplayInitializer.Initialize();
        }

        private void Update() => _gameplayInitializer.Execute();
    }
}