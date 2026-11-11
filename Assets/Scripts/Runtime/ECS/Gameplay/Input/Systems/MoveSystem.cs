using Entitas;

public class MoveSystem : IExecuteSystem
{
    private readonly IGroup<GameEntity> _movable;

    public MoveSystem(Contexts contexts)
    {
        var matcher = GameMatcher.AllOf(GameMatcher.Position, GameMatcher.Rotation, GameMatcher.Movable)
            .NoneOf(GameMatcher.ManualInput);

        _movable = contexts.game.GetGroup(matcher);
    }

    public void Execute()
    {
        if(_movable.count == 0)
            return;

        foreach (var e in _movable.GetEntities())
        {
            UnityEngine.Vector2 direction = e.rotation.rotation;
            var position = e.position.position;
            position += direction * e.movable.speed * UnityEngine.Time.deltaTime;
            e.ReplacePosition(position);
        }
    }
}
