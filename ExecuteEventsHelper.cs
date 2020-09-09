using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace GameUtil
{
    public static class ExecuteEventsHelper
    {
        private static List<RaycastResult> mRaycastResults;
        
        /// <summary>
        /// 获得下一个响应事件的对象
        /// </summary>
        /// <param name="gameObject">当前响应事件的游戏对象</param>
        public static GameObject GetNext(GameObject gameObject, PointerEventData eventData)
        {
            if(mRaycastResults == null)
                mRaycastResults = new List<RaycastResult>();
            EventSystem.current.RaycastAll(eventData, mRaycastResults);
            GameObject nextGo = null;
            foreach (var r in mRaycastResults)
            {
                if (r.gameObject == gameObject) continue;
                nextGo = r.gameObject;
                break;
            }
            mRaycastResults.Clear();
            return nextGo;
        }
        
        /// <summary>
        /// 往下层渗透
        /// </summary>
        /// <param name="gameObject">当前响应事件的游戏对象</param>
        public static void PassNext<T>(GameObject gameObject, PointerEventData eventData, ExecuteEvents.EventFunction<T> functor)
            where T : IEventSystemHandler
        {
            var go = GetNext(gameObject, eventData);
            if (go == null) return;
            Execute(go, eventData, functor);
        }
        
        public static void Execute<T>(GameObject target, BaseEventData eventData, ExecuteEvents.EventFunction<T> functor)
            where T : IEventSystemHandler
        {
            if (!target) return;
            ExecuteEvents.Execute(target, eventData, functor);
        }

        public static void ExecuteClick(GameObject target)
        {
            BaseEventData eventData = new BaseEventData(EventSystem.current)
            {
                selectedObject = target
            };
            Execute(target, eventData, ExecuteEvents.submitHandler);
        }
    }
}