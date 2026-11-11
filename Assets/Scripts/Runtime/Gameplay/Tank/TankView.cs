using Runtime.Gameplay.Pool;
using Runtime.Gameplay.View;
using UnityEngine;

namespace Runtime.Gameplay.Tank
{
    public class TankView : EntityView
    {
        [SerializeField] private ObjectPool _bulletPool;
        [field: SerializeField] public Transform spawnPoint { get; private set; }

        public void Fire()
        {
            var bullet = _bulletPool.Get();
        }
    }
}
