using System.Collections.Generic;
using Entitas;
using Entitas.Unity;

public class DestroyedComponent : IComponent 
{ }

public class DestroySystem : ReactiveSystem<GameEntity>
{
    public DestroySystem(Contexts contexts) : base(contexts.game) { }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach(var e in entities)
        {
            if (e.hasUnityView)
            {
                e.unityView.Value.gameObject.Unlink();
                e.unityView.Value.DestroyView();
            }

            e.Destroy();
        }
    }

    protected override bool Filter(GameEntity entity) => entity.isDestroyed;

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) => 
        context.CreateCollector(GameMatcher.Destroyed);
}
