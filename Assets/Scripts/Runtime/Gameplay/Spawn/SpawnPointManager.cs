using System.Collections.Generic;
using UnityEngine;

namespace Runtime.Gameplay.Spawn
{
    public class SpawnPointManager : MonoBehaviour
    {
        [SerializeField] private List<Transform> _spawnPoints = new();

        private int[] _shuffleOrder;

        private void Awake()
        {
            RebuildShuffleOrder();
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

        private bool IsPlayerAround(Vector2 position)
        {
            return false;
        }

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
    }
}
