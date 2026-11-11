using Runtime.Gameplay.Input;

namespace Runtime.Gameplay.Initializers
{
    internal class GameplaySystems : Feature
    {
        public GameplaySystems(Contexts context, InputReader inputReader)
        {
            // Systems
            Add(new EmitInputSystem(context, inputReader));
            Add(new ManualMoveSystem(context));
            Add(new ManualFireSystem(context));
            Add(new MoveSystem(context));

            // Event Systems
            Add(new HealthEventSystem(context));
            Add(new PositionEventSystem(context));
            Add(new RotationEventSystem(context));
        }
    }
}
