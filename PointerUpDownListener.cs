using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace GameUtil
{
    public class PointerUpDownListener : EventTriggerListenerBase<PointerUpDownListener>, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler
    {
        public event Action<GameObject, PointerEventData> onDown;
        public event Action<GameObject, PointerEventData> onUp;
        public event Action<GameObject, PointerEventData> onEnter;
        public event Action<GameObject, PointerEventData> onExit;
        
        public event Action onDownNull;
        public event Action onUpNull;
        public event Action onEnterNull;
        public event Action onExitNull;
        
        public bool IsPointerStay { private set; get; }
        public bool IsLongClick { private set; get; }

        public void OnPointerDown(PointerEventData eventData)
        {
            IsLongClick = true;
            onDown?.Invoke(gameObject, eventData);
            onDownNull?.Invoke();
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            IsLongClick = false;
            onUp?.Invoke(gameObject, eventData);
            onUpNull?.Invoke();
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            IsPointerStay = true;
            onEnter?.Invoke(gameObject, eventData);
            onEnterNull?.Invoke();
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            IsPointerStay = false;
            IsLongClick = false;
            onExit?.Invoke(gameObject, eventData);
            onExitNull?.Invoke();
        }

        private void OnDisable()
        {
            IsPointerStay = false;
            IsLongClick = false;
        }
    }
}