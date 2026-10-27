using Entitas;

namespace Runtime.Gameplay.Initializers
{
    internal class GameplayInitializer
    {
        private readonly Systems _systems;

        public GameplayInitializer(Contexts context)
        {
            _systems = new GameplaySystems(context);
        }

        public void Initialize()
        {
            _systems.Initialize();
        }

        public void Deinitialize()
        {
            // deinitialize systems if needed
        }

        public void Execute()
        {
            _systems.Execute();
            _systems.Cleanup();
        }
    }
}
