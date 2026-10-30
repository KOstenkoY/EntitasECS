using System.Collections.Generic;
using Runtime.Gameplay.Spawn;
using Runtime.Gameplay.Tank;
using UnityEngine;

namespace Runtime.Gameplay.Initializers
{
    public class LevelInitializer
    {
        private Contexts _context;
        private SpawnPointManager _spawnPointManager;

        private List<TankView> tanks = new ();

        public LevelInitializer(Contexts context, SpawnPointManager spawnPointManager)
        {
            _context = context;
            _spawnPointManager = spawnPointManager;
        }

        public void Initialize()
        {
            InitializeTank(LoadTank("Prefabs/Player"));
            InitializeTank(LoadTank("Prefabs/Enemy"));
        }


        public void Deinitialize()
        {
            foreach(var tank in tanks)
            {
                tank.Unlink();
                GameObject.Destroy(tank);
            }
        }

        private GameObject LoadTank(string path) => 
            Resources.Load(path) as GameObject;

        private void InitializeTank(GameObject tank)
        {
            var entity = _context.game.CreateEntity();
            entity.AddHealth(3);
            entity.AddMovement(3);
            entity.AddPosition(Vector2Int.zero);

            var instance = GameObject.Instantiate(tank, _spawnPointManager.GetRandomSpawnPointPosition(), Quaternion.identity);
            var viewComponent = instance.GetComponent<TankView>();
            viewComponent.Link(entity);
            
            tanks.Add(viewComponent);
        }
    }
}