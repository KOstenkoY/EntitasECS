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
        _gameContext = contexts.game;
    }

    public void Execute()
    {
        if (!_inputContext.isFire)
            return;

        foreach(var e in _shooters.GetEntities())
            Fire(e);
    }

    private void Fire(GameEntity shooter)
    {
        var bullet = _gameContext.CreateEntity();
        bullet.isBullet = true;
        bullet.AddDamage(shooter.weapon.damage);
        bullet.AddPosition(shooter.position.position + Rotate(shooter.weapon.spawnOffset, shooter.rotation.rotation));
        bullet.AddRotation(shooter.rotation.rotation);
        bullet.AddMovable(shooter.weapon.bulletSpeed);
    }

    private static UnityEngine.Vector2 Rotate(UnityEngine.Vector2 offset, UnityEngine.Vector2Int direction) =>
        (direction.x, direction.y) switch
        {
            (0, -1) => new UnityEngine.Vector2(-offset.x, -offset.y),
            (-1, 0) => new UnityEngine.Vector2(-offset.y, offset.x),
            (1, 0) => new UnityEngine.Vector2(offset.y, -offset.x),
            _ => offset,
        };
}
