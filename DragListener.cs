using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace GameUtil
{
    public class DragListener : EventTriggerListenerBase<DragListener>, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler
    {
        public event Action<GameObject, PointerEventData> onBeginDrag;
        public event Action<GameObject, PointerEventData> onDrag;
        public event Action<GameObject, PointerEventData> onEndDrag;
        public event Action<GameObject, PointerEventData> onDrop;
        
        public event Action onBeginDragNull;
        public event Action onDragNull;
        public event Action onEndDragNull;
        public event Action onDropNull;
        
        public bool IsDrag { private set; get; }

        
        public void OnBeginDrag(PointerEventData eventData)
        {
            IsDrag = true;
            onBeginDrag?.Invoke(gameObject, eventData);
            onBeginDragNull?.Invoke();
        }

        public void OnDrag(PointerEventData eventData)
        {
            onDrag?.Invoke(gameObject, eventData);
            onDragNull?.Invoke();
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            IsDrag = false;
            onEndDrag?.Invoke(gameObject, eventData);
            onEndDragNull?.Invoke();
        }

        public void OnDrop(PointerEventData eventData)
        {
            IsDrag = false;
            onDrop?.Invoke(gameObject, eventData);
            onDropNull?.Invoke();
        }

        private void OnDisable()
        {
            IsDrag = false;
        }
    }
}