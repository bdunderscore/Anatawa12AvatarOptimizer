using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Anatawa12.AvatarOptimizer
{
    internal class OptimizerSession
    {
        private readonly GameObject _rootObject;
        private readonly HashSet<Object> _added = new HashSet<Object>();
        private readonly DummyObject _assetFileObject;
        public bool IsTest { get; }
        public ObjectMappingBuilder MappingBuilder { get; }

        public OptimizerSession(GameObject rootObject, bool addToAsset, bool isTest) :
            this(rootObject, addToAsset ? Utils.CreateAssetFile() : null, isTest)
        {
        }

        public OptimizerSession(GameObject rootObject, DummyObject assetFileObject, bool isTest)
        {
            this.IsTest = isTest;
            _rootObject = rootObject;
            _assetFileObject = assetFileObject;
            MappingBuilder = new ObjectMappingBuilder(rootObject);
        }

        public T GetRootComponent<T>() where T : Component
        {
            return _rootObject != null ? _rootObject.GetComponent<T>() : null;
        }

        public IEnumerable<T> GetComponents<T>() where T : Component
        {
            return (_rootObject != null ? _rootObject.GetComponentsInChildren<T>(true) : Object.FindObjectsOfType<T>())
                .Where(x => x);
        }

        public T AddToAsset<T>(T obj) where T : Object
        {
            if (obj)
            {
                // already added to some asset
                if (!string.IsNullOrEmpty(AssetDatabase.GetAssetPath(obj))) return obj;
                _added.Add(obj);
                if (_assetFileObject)
                    AssetDatabase.AddObjectToAsset(obj, _assetFileObject);
            }
            return obj;
        }

        public T MayInstantiate<T>(T obj) where T : Object =>
            _added.Contains(obj) ? obj : AddToAsset(Object.Instantiate(obj));

        public void MarkDirtyAll()
        {
            foreach (var o in _added)
                EditorUtility.SetDirty(o);
        }

        public string RelativePath(Transform child)
        {
            return Utils.RelativePath(_rootObject.transform, child) ??
                   throw new ArgumentException("child is not child of rootObject", nameof(child));
        }
    }
}
