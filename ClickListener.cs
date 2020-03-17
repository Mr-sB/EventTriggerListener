using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace GameUtil
{
    public class ClickListener : EventTriggerListenerBase<ClickListener>, IPointerClickHandler
    {
        public event Action<GameObject, PointerEventData> onClick;
        public event Action onClickNull;
        [SerializeField] private UnityEvent onClickPersistentEvent = new UnityEvent();
        public void OnPointerClick(PointerEventData eventData)
        {
            onClick?.Invoke(gameObject, eventData);
            onClickNull?.Invoke();
            onClickPersistentEvent.Invoke();
        }
    }
}