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
            var builder = new TankBuilder(_context, _spawnPointManager);
            var player = builder.BuildTank(LoadTank("Prefabs/Player"), 3, 3)
                .AddManualControl()
                .Build();

            var enemy = builder.BuildTank(LoadTank("Prefabs/Enemy"), 3, 0)
                .Build();
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
    }
}