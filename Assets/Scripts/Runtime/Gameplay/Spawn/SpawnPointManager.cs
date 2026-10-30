using System.Collections.Generic;
using UnityEngine;

namespace Runtime.Gameplay.Spawn
{
    public class SpawnPointManager : MonoBehaviour
    {
        [SerializeField] private List<Transform> _spawnPoints = new();
        [SerializeField] private float _playerCheckRadius = 5f;
        [SerializeField] private LayerMask _playerLayers;

        private readonly List<Collider2D> _overlapBuffer = new();

        private ContactFilter2D _playerFilter;
        private int[] _shuffleOrder;

        private void Awake()
        {
            RebuildShuffleOrder();

            _playerFilter = new ContactFilter2D
            {
                useLayerMask = true,
                layerMask = _playerLayers,
                useTriggers = true,
            };
        }

        public Vector2 GetRandomSpawnPointPosition()
        {
            Shuffle();

            foreach (var index in _shuffleOrder)
            {
                Vector2 position = _spawnPoints[index].position;
                if (!IsPlayerAround(position))
                {
                    return position;
                }
            }

            // Every point is occupied, the order is already shuffled, so the first one is a random pick.
            return _spawnPoints[_shuffleOrder[0]].position;
        }

        private bool IsPlayerAround(Vector2 position) =>
            Physics2D.OverlapCircle(position, _playerCheckRadius, _playerFilter, _overlapBuffer) > 0;

        // Fisher-Yates over a reusable index buffer, so no allocations per call.
        private void Shuffle()
        {
            if (_shuffleOrder == null || _shuffleOrder.Length != _spawnPoints.Count)
            {
                RebuildShuffleOrder();
            }

            for (var i = _shuffleOrder.Length - 1; i > 0; i--)
            {
                var j = Random.Range(0, i + 1);
                (_shuffleOrder[i], _shuffleOrder[j]) = (_shuffleOrder[j], _shuffleOrder[i]);
            }
        }

        private void RebuildShuffleOrder()
        {
            _shuffleOrder = new int[_spawnPoints.Count];
            for (var i = 0; i < _shuffleOrder.Length; i++)
            {
                _shuffleOrder[i] = i;
            }
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.cyan;

            foreach (var point in _spawnPoints)
            {
                if (point != null)
                {
                    Gizmos.DrawWireSphere(point.position, _playerCheckRadius);
                }
            }
        }
    }
}
