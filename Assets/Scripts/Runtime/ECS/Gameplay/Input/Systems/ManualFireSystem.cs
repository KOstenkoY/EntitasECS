using Entitas;

public class ManualFireSystem : IExecuteSystem
{
    private readonly InputContext _inputContext;
    private readonly GameContext _gameContext;

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

        foreach(var e in _shooters.GetEntities())
        {
            var bullet = _gameContext.CreateEntity();
            bullet.isBullet = true;
            bullet.AddDamage(1);
            bullet.AddPosition(e.position.position);
            bullet.AddRotation(e.rotation.rotation);
            bullet.AddMovable(3f);
            // some logic
        }
    }
}
