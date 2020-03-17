using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace GameUtil
{
    public class PointerEnterExitListener : EventTriggerListenerBase<PointerEnterExitListener>, IPointerEnterHandler, IPointerExitHandler
    {
        public event Action<GameObject, PointerEventData> onEnter;
        public event Action<GameObject, PointerEventData, bool> onExit;
        
        public event Action onEnterNull;
        public event Action onExitNull;
        
        public bool IsPointerStay { private set; get; }
        public int PointerCount { private set; get; }

        public void OnPointerEnter(PointerEventData eventData)
        {
            PointerCount++;
            IsPointerStay = true;
            onEnter?.Invoke(gameObject, eventData);
            onEnterNull?.Invoke();
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (--PointerCount <= 0)
            {
                PointerCount = 0;
                IsPointerStay = false;
            }

            onExit?.Invoke(gameObject, eventData, IsPointerStay);
            onExitNull?.Invoke();
        }

        private void OnDisable()
        {
            PointerCount = 0;
            IsPointerStay = false;
        }
    }
}