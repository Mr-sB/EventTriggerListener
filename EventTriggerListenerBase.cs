using UnityEngine;

namespace GameUtil
{
    public class EventTriggerListenerBase<T> : MonoBehaviour where T : EventTriggerListenerBase<T>
    {
        public static T Get(GameObject go)
        {
            if (!go) return null;
            T listener = go.GetComponent<T>();
            if (!listener) listener = go.AddComponent<T>();
            return listener;
        }

        public static T Get(Component component)
        {
            if (!component) return null;
            return Get(component.gameObject);
        }
    }
}