using UnityEditor;
using UnityEngine;

namespace Anatawa12.AvatarOptimizer
{
    [CustomEditor(typeof(TraceAndOptimize))]
    internal class TraceAndOptimizeEditor : AvatarGlobalComponentEditorBase
    {
        private SerializedProperty _freezeBlendShape;
        private SerializedProperty _removeUnusedObjects;
        private SerializedProperty _mmdWorldCompatibility;

        private void OnEnable()
        {
            _freezeBlendShape = serializedObject.FindProperty(nameof(TraceAndOptimize.freezeBlendShape));
            _removeUnusedObjects = serializedObject.FindProperty(nameof(TraceAndOptimize.removeUnusedObjects));
            _mmdWorldCompatibility = serializedObject.FindProperty(nameof(TraceAndOptimize.mmdWorldCompatibility));
        }

        protected override void OnInspectorGUIInner()
        {
            base.OnInspectorGUIInner();
            serializedObject.UpdateIfRequiredOrScript();

            GUILayout.Label("General Settings", EditorStyles.boldLabel);
            EditorGUILayout.PropertyField(_mmdWorldCompatibility);
            GUILayout.Label("Features", EditorStyles.boldLabel);
            EditorGUILayout.PropertyField(_freezeBlendShape);
            EditorGUILayout.PropertyField(_removeUnusedObjects);

            serializedObject.ApplyModifiedProperties();
        }
    }
}