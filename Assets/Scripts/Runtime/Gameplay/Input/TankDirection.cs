using UnityEngine;
using UnityEngine.EventSystems;

namespace Runtime.Gameplay.Input
{
    public static class TankDirectionExtensions
    {
        public static Vector2Int ToVector(this MoveDirection direction) => direction switch
        {
            MoveDirection.Up => Vector2Int.up,
            MoveDirection.Down => Vector2Int.down,
            MoveDirection.Left => Vector2Int.left,
            MoveDirection.Right => Vector2Int.right,
            _ => Vector2Int.zero,
        };
    }
}
