using Entitas;
using Entitas.Unity;
using UnityEngine;

namespace Runtime.Gameplay.View
{
    public abstract class EntityView : MonoBehaviour, IView, IPositionListener, IRotationListener
    {
        private GameEntity _linkedEntity;
        private Transform _transform;

        private Vector2Int _cachedDirection;

        protected virtual void Awake()
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

        public void OnPosition(GameEntity entity, Vector2 position) =>
            _transform.position = position;

        public void OnRotation(GameEntity entity, Vector2Int direction)
        {
            if (direction == Vector2Int.zero || _cachedDirection == direction)
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
