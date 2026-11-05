using Runtime.Gameplay.Input;
using Runtime.Gameplay.Spawn;
using UnityEngine;

namespace Runtime.Gameplay.Initializers
{
    public class GameplayInitializerBehaviour : MonoBehaviour
    {
        [SerializeField] private SpawnPointManager spawnPointManager;
        [SerializeField] private InputReader inputReader;

        private GameplayInitializer _gameplayInitializer;

        private void Awake()
        {
            _gameplayInitializer = new GameplayInitializer(Contexts.sharedInstance, spawnPointManager, inputReader);
            _gameplayInitializer.Initialize();
        }

        private void Update() => _gameplayInitializer.Execute();
    }
}
