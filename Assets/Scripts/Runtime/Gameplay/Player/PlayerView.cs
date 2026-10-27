using Entitas;
using Entitas.Unity;
using Runtime.Gameplay.View;
using UnityEngine;

namespace Runtime.Gameplay.Player
{
    public class PlayerView : MonoBehaviour, IView
    {
        private GameEntity _linkedEntity;

        public void Link(IEntity entity)
        {
            gameObject.Link(entity);
            _linkedEntity = (GameEntity)entity;
        }

        public void Unlink()
        {
            gameObject.Unlink();
            _linkedEntity = null;
        }
    }
}
