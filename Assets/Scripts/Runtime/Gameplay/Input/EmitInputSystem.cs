using Entitas;

namespace Runtime.Gameplay.Input
{
    internal class EmitInputSystem : IExecuteSystem
    {
        private readonly InputContext _context;
        private readonly InputReader _inputReader;

        public EmitInputSystem(Contexts contexts, InputReader inputReader)
        {
            _context = contexts.input;
            _inputReader = inputReader;
        }

        public void Execute() => _context.ReplaceDirection(_inputReader.ReadDirection());
    }
}
