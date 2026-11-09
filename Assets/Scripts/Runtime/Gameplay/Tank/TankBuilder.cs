using Runtime.Gameplay.Spawn;
using UnityEngine;

namespace Runtime.Gameplay.Tank
{
    public class TankBuilder
    {
        private readonly Contexts _contexts;
        private readonly SpawnPointManager _spawnPointManager;

        private GameEntity _entity;
        private GameObject _tankPrefab;

        public TankBuilder(Contexts contexts, SpawnPointManager spawnPointManager)
        {
            _contexts = contexts;
            _spawnPointManager = spawnPointManager;
        }

        public TankBuilder BuildTank(GameObject tankPrefab, int maxHealth, float speed)
        {
            _tankPrefab = tankPrefab;
            _entity = _contexts.game.CreateEntity();
            
            _entity.AddHealth(maxHealth);
            _entity.AddMovable(speed);
            _entity.AddPosition(Vector2Int.zero);

            return this;
        }

        public TankBuilder AddManualControl()
        {
            _entity.isManualInput = true;
            return this;
        }

        public TankView Build()
        {
            var spawnPosition = _spawnPointManager.GetRandomSpawnPointPosition();
            var instance = GameObject.Instantiate(_tankPrefab, spawnPosition, Quaternion.identity);

            var viewComponent = instance.GetComponent<TankView>();
            viewComponent.Link(_entity);

            return viewComponent;
        }
    }
}