using Entitas;
using Runtime.Gameplay.Input;
using Runtime.Gameplay.Spawn;

namespace Runtime.Gameplay.Initializers
{
    internal class GameplayInitializer
    {
        private readonly Systems _systems;
        private readonly LevelInitializer _levelInitializer;
        private readonly BulletSpawner _bulletSpawner;
        private readonly Contexts _context;

        public GameplayInitializer(Contexts context, SpawnPointManager spawnPointManger, InputReader inputReader, BulletSpawner bulletSpawner)
        {
            _context = context;
            _bulletSpawner = bulletSpawner;
            _levelInitializer = new LevelInitializer(context, spawnPointManger);
            _systems = new GameplaySystems(context, inputReader);
        }

        public void Initialize()
        {
            _bulletSpawner.Initialize(_context);
            _levelInitializer.Initialize();
            _systems.Initialize();
        }

        public void Deinitialize()
        {
            _levelInitializer.Deinitialize();
            _bulletSpawner.Deinitialize();
        }

        public void Execute()
        {
            _systems.Execute();
            _systems.Cleanup();
        }
    }
}
