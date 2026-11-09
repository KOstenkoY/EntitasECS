using UnityEngine;

namespace Runtime.UI
{
    public class HealthView : MonoBehaviour, IHealthListener
    {
        private GameEntity _entity;

        private void Awake()
        {
            //RegisterListeners(entity);
        }

        public void OnHealth(GameEntity entity, int health)
        {
        }

        private void RegisterListeners(GameEntity entity)
        {
            _entity = entity;
            entity.AddHealthListener(this);
        }

        public void OnHealthChanged(GameEntity entity, int health)
        {
            // Update the health view based on the new health value
            Debug.Log($"Health changed to: {health}");
        }

        private void OnDestroy()
        {
            if(_entity != null)
            {
                _entity.RemoveHealthListener(this);
            }
        }

        public void OnAnyHealth(GameEntity entity, int health)
        {
            throw new System.NotImplementedException();
        }
    }
}