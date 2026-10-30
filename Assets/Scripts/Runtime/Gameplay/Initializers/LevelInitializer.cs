using System.Collections.Generic;
using Runtime.Gameplay.Tank;
using UnityEngine;

namespace Runtime.Gameplay.Initializers
{
    public class LevelInitializer
    {
        private Contexts _context;

        private List<TankView> tanks = new ();

        public LevelInitializer(Contexts context)
        {
            _context = context;
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

            var instance = GameObject.Instantiate(tank, Vector3.zero, Quaternion.identity);
            var viewComponent = tank.GetComponent<TankView>();
            viewComponent.Link(entity);
            
            tanks.Add(viewComponent);
        }
    }
}