using Entitas;
using System.Collections.Generic;
using UnityEngine;

public class DebugMessageSystem : ReactiveSystem<GameEntity>
{
    public DebugMessageSystem(Contexts contexts) : base(contexts.game)
    { }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach(var entity in entities)
        {
            Debug.Log(entity.debugMessage.message);
        }   
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasDebugMessage;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.DebugMessage);
    }
}
