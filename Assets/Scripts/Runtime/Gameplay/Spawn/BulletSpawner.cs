using Runtime.Gameplay.Bullet;
using Runtime.Gameplay.Pool;
using UnityEngine;

namespace Runtime.Gameplay.Spawn
{
    public class BulletSpawner : MonoBehaviour, IAnyBulletListener
    {
        [SerializeField] private ObjectPool _bulletPool;

        private GameEntity _listener;

        public void Initialize(Contexts contexts)
        {
            _listener = contexts.game.CreateEntity();
            _listener.AddAnyBulletListener(this);
        }

        public void Deinitialize()
        {
            _listener.Destroy();
            _listener = null;
        }

        public void OnAnyBullet(GameEntity entity)
        {
            var bullet = _bulletPool.Get();
            bullet.transform.position = entity.position.position;
            bullet.GetComponent<BulletView>().Link(entity);
        }
    }
}
