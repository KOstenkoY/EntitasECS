using UnityEngine;

public class SpawnerTest : MonoBehaviour
{
    [SerializeField]
    private PlayerView _playerPrefab;

    private readonly Vector3 _defaultPos = new Vector3(0.01f, 0, 0);

    private GameEntity _playerEntity;
    private Entitas.Systems _system;

    private void Start()
    {
        var contexts = Contexts.sharedInstance;
        _system = new Feature("Game event")
            .Add(new GameEventSystems(contexts))
            .Add(new DestroySystem(contexts));

        _system.Initialize();

        var playerView = Instantiate(_playerPrefab);

        _playerEntity = contexts.game.CreateEntity();

        playerView.Link(contexts, _playerEntity);

        _playerEntity.AddUnityView(playerView);
        _playerEntity.AddPosition(Vector3.zero);
    }

    private void Update()
    {
        _system.Execute();

        var oldPos = _playerEntity.position.Value;

        _playerEntity.ReplacePosition(
            new Vector3(
                oldPos.x + _defaultPos.x,
                oldPos.y,
                oldPos.z
            )
        );
    }
}
