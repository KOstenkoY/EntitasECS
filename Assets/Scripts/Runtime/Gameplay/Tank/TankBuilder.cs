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

        public TankBuilder BuildTank(GameObject tankPrefab, int maxHealth, float speed, float bulletSpeed, int bulletDamage)
        {
            _tankPrefab = tankPrefab;
            _entity = _contexts.game.CreateEntity();
            
            _entity.AddHealth(maxHealth);
            _entity.AddMovable(speed);
            _entity.AddPosition(_spawnPointManager.GetRandomSpawnPointPosition());
            _entity.AddRotation(Vector2Int.up);
            _entity.AddWeapon(bulletSpeed, bulletDamage, GetSpawnOffset(_tankPrefab));

            return this;
        }

        public TankBuilder AddManualControl()
        {
            _entity.isManualInput = true;
            return this;
        }

        public TankView Build()
        {
            var spawnPosition = _entity.position.position;
            var instance = GameObject.Instantiate(_tankPrefab, spawnPosition, Quaternion.identity);

            var tankView = instance.GetComponent<TankView>();
            tankView.Link(_entity);

            return tankView;
        }

        private static Vector2 GetSpawnOffset(GameObject prefab)
        {
            var tankView = prefab.GetComponent<TankView>();
            return tankView.transform.InverseTransformPoint(tankView.spawnPoint.position);
        }
    }
}