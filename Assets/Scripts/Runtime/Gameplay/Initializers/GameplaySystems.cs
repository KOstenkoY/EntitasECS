using Runtime.Gameplay.Input;

namespace Runtime.Gameplay.Initializers
{
    internal class GameplaySystems : Feature
    {
        public GameplaySystems(Contexts context, InputReader inputReader)
        {
            // Systems
            Add(new EmitInputSystem(context, inputReader));
            Add(new MoveSystem(context));

            // Event Systems
            Add(new HealthEventSystem(context));
            Add(new PositionEventSystem(context));
        }
    }
}
