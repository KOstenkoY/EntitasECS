using Entitas;
using UnityEngine;

namespace Assets.Scripts.Runtime
{
    public class GameController : MonoBehaviour
    {
        private Systems _system;

        private void Start()
        {
            var contexts = Contexts.sharedInstance;

            _system = new Feature("Systems")
                .Add(new TutorialSystem(contexts));

            _system.Initialize();
        }

        private void Update()
        {
            _system.Execute();
            _system.Cleanup();
        }
    }
}
