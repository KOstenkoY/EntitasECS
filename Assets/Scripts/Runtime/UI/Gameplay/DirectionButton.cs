using Runtime.Gameplay.Input;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Runtime.UI
{
    public class DirectionButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler
    {
        [SerializeField] private InputReader _inputReader;
        [SerializeField] private MoveDirection _direction;

        public void OnPointerDown(PointerEventData eventData) => _inputReader.Press(_direction.ToVector());

        public void OnPointerUp(PointerEventData eventData) => _inputReader.Release(_direction.ToVector());

        public void OnPointerExit(PointerEventData eventData) => _inputReader.Release(_direction.ToVector());
    }
}
