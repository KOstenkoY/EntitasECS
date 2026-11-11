using Entitas;

public class ManualFireSystem : IExecuteSystem
{
    private readonly InputContext _inputContext;
    private readonly IGroup<GameEntity> _shooters;

    public ManualFireSystem(Contexts contexts)
    {
        var matcher = GameMatcher.AllOf(GameMatcher.Rotation, GameMatcher.Position, GameMatcher.ManualInput);
        _shooters = contexts.game.GetGroup(matcher);
        _inputContext = contexts.input;
    }

    public void Execute()
    {
        if (!_inputContext.isFire)
            return;

        foreach(var entity in _shooters.GetEntities())
        {
            
        }
    }
}
