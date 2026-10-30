using Entitas;
using Runtime.Gameplay.Spawn;

namespace Runtime.Gameplay.Initializers
{
    internal class GameplayInitializer
    {
        private readonly Systems _systems;
        private readonly LevelInitializer _levelInitializer;

        public GameplayInitializer(Contexts context, SpawnPointManager spawnPointManger)
        {
            _levelInitializer = new LevelInitializer(context, spawnPointManger);
            _systems = new GameplaySystems(context);

        }

        public void Initialize()
        {
            _levelInitializer.Initialize();
            _systems.Initialize();
        }

        public void Deinitialize()
        {
            _levelInitializer.Deinitialize();
        }

        public void Execute()
        {
            _systems.Execute();
            _systems.Cleanup();
        }
    }
}
