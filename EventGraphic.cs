using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace GameUtil
{
    /// <summary>
    /// If you need a blank UI to listen event, you can use this component which will not interrupt batch.
    /// </summary>
    public class EventGraphic : Graphic
    {
        public override void Rebuild(CanvasUpdate update) { }
    }
    
#if UNITY_EDITOR
    [CustomEditor(typeof(EventGraphic))]
    public class EventGraphicEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            //Hide unused fields
            EditorGUI.BeginChangeCheck();
            serializedObject.UpdateIfRequiredOrScript();
            var script = serializedObject.FindProperty("m_Script");
            var raycastTarget = serializedObject.FindProperty("m_RaycastTarget");
            using (new EditorGUI.DisabledScope(true))
                EditorGUILayout.PropertyField(script);
            EditorGUILayout.PropertyField(raycastTarget);
            serializedObject.ApplyModifiedProperties();
            EditorGUI.EndChangeCheck();
        }
    }
#endif
}
