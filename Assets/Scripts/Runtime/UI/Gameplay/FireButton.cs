using Runtime.Gameplay.Input;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Runtime.UI
{
    public class FireButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler
    {
        [SerializeField] private InputReader _inputReader;

        public void OnPointerDown(PointerEventData eventData) => _inputReader.PressFireButton();
        public void OnPointerUp(PointerEventData eventData) => _inputReader.ReleaseFireButton();
        public void OnPointerExit(PointerEventData eventData) => _inputReader.ReleaseFireButton();
    }
}
