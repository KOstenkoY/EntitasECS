using Entitas;
using Entitas.Unity;
using Runtime.Gameplay.View;
using UnityEngine;

namespace Runtime.Gameplay.Tank
{
    public class TankView : MonoBehaviour, IView, IPositionListener
    {
        private GameEntity _linkedEntity;
        private Transform _transform;

        private void Awake()
        {
            _transform = transform;
        }

        public void Link(IEntity entity)
        {
            gameObject.Link(entity);
            _linkedEntity = (GameEntity)entity;
            _linkedEntity.AddPositionListener(this);
        }

        public void Unlink()
        {
            _linkedEntity.RemovePositionListener(this);
            gameObject.Unlink();
            _linkedEntity = null;
        }

        public void OnPosition(GameEntity entity, Vector2 position) =>
            _transform.position = position;
    }
}
