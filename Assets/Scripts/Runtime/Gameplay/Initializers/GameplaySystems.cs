using Entitas;
using Runtime.Gameplay.Input;

namespace Runtime.Gameplay.Initializers
{
    internal class GameplaySystems : Feature
    {
        public GameplaySystems(Contexts context, InputReader inputReader)
        {
            Add(new EmitInputSystem(context, inputReader));
            Add(new HealthEventSystem(context));
        }
    }
}
