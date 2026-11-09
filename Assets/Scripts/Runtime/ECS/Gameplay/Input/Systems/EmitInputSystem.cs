using Entitas;

namespace Runtime.Gameplay.Input
{
    internal class EmitInputSystem : IExecuteSystem
    {
        private readonly InputContext _inputContext;
        private readonly InputReader _inputReader;

        private readonly GameEntity _gameEntity;

        public EmitInputSystem(Contexts contexts, InputReader inputReader)
        {
            _inputContext = contexts.input;
            _inputReader = inputReader;
        }

        public void Execute() =>
            _inputContext.ReplaceDirection(_inputReader.ReadDirection());
    }
}
