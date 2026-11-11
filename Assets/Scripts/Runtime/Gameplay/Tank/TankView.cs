using Entitas;
using Entitas.Unity;
using Runtime.Gameplay.Pool;
using Runtime.Gameplay.View;
using UnityEngine;

namespace Runtime.Gameplay.Tank
{
    public class TankView : MonoBehaviour, IView, IPositionListener, IRotationListener
    {
        [SerializeField] private ObjectPool _bulletPool;
        [field: SerializeField] public Transform spawnPoint { get; private set; }

        private GameEntity _linkedEntity;
        private Transform _transform;

        private Vector2Int _cachedDirection;

        private void Awake()
        {
            _transform = transform;
        }

        public void Link(IEntity entity)
        {
            gameObject.Link(entity);
            _linkedEntity = (GameEntity)entity;
            _linkedEntity.AddPositionListener(this);
            _linkedEntity.AddRotationListener(this);
        }

        public void Unlink()
        {
            _linkedEntity.RemovePositionListener(this);
            _linkedEntity.RemoveRotationListener(this);
            gameObject.Unlink();
            _linkedEntity = null;
        }

        public void Fire()
        {
            var bullet = _bulletPool.Get();
        }

        public void OnPosition(GameEntity entity, Vector2 position) =>
            _transform.position = position;

        public void OnRotation(GameEntity entity, Vector2Int direction)
        {
            if(direction == Vector2Int.zero || _cachedDirection == direction)
            {
                return;
            }

            _cachedDirection = direction;

            _transform.rotation = (direction.x, direction.y) switch
            {
                (0, 1) => Quaternion.Euler(0f, 0f, 0f),
                (0, -1) => Quaternion.Euler(0f, 0f, 180f),
                (-1, 0) => Quaternion.Euler(0f, 0f, 90f),
                (1, 0) => Quaternion.Euler(0f, 0f, -90f),
                _ => _transform.rotation,
            };
        }
    }
}
