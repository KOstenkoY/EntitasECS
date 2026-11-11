using UnityEngine;
using UnityEngine.InputSystem;

namespace Runtime.Gameplay.Input
{
    public class InputReader : MonoBehaviour
    {        
        private const string GameplayMapName = "Gameplay";
        private const string MoveActionName = "Move";
        private const string FireActionName = "Fire";
     
        private const float PressThreshold = 0.5f;
        
        [SerializeField] private InputActionAsset _actions;

        private InputAction _move;
        private InputAction _fire;
        private Vector2Int _direction;
        private Vector2Int _screenDirection;
        private bool _firePressed;

        private void Awake()
        {
            _move = _actions.FindActionMap(GameplayMapName, true).FindAction(MoveActionName, true);
            _fire = _actions.FindActionMap(GameplayMapName, true).FindAction(FireActionName, true);
        }

        private void OnEnable()
        {
            _move.Enable();
            _fire.Enable();
        }

        private void OnDisable()
        {
            _move.Disable();
            _fire.Disable();
            _screenDirection = Vector2Int.zero;
            _direction = Vector2Int.zero;
        }

        public Vector2Int ReadDirection()
        {
            _direction = _screenDirection != Vector2Int.zero
                ? _screenDirection
                : ToSingleAxis(_move.ReadValue<Vector2>(), _direction);

            return _direction;
        }

        public bool ReadFire() => _firePressed && _fire.IsPressed();

        public void PressMoveButton(Vector2Int direction) => _screenDirection = direction;

        public void ReleaseMoveButton(Vector2Int direction)
        {
            if (_screenDirection == direction)
                _screenDirection = Vector2Int.zero;
        }

        public void PressFireButton() => _firePressed = true;

        public void ReleaseFireButton() => _firePressed = false;

        private static Vector2Int ToSingleAxis(Vector2 raw, Vector2Int current)
        {
            var horizontal = Mathf.Abs(raw.x);
            var vertical = Mathf.Abs(raw.y);

            if (horizontal < PressThreshold && vertical < PressThreshold)
            {
                return Vector2Int.zero;
            }

            if (Mathf.Approximately(horizontal, vertical))
            {
                if (current.x != 0)
                    return new Vector2Int(SignOf(raw.x), 0);

                if (current.y != 0)
                    return new Vector2Int(0, SignOf(raw.y));
            }

            return horizontal >= vertical
                ? new Vector2Int(SignOf(raw.x), 0)
                : new Vector2Int(0, SignOf(raw.y));
        }

        private static int SignOf(float value) => value > 0f ? 1 : -1;
    }
}
