using CustomLocalization4EditorExtension;
using UnityEngine;

namespace Anatawa12.AvatarOptimizer
{
    // previously known as Automatic Configuration
    [AddComponentMenu("Avatar Optimizer/AAO Trace And Optimize")]
    [DisallowMultipleComponent]
    internal class TraceAndOptimize : AvatarGlobalComponent
    {
        [CL4EELocalized("TraceAndOptimize:prop:freezeBlendShape")]
        [ToggleLeft]
        public bool freezeBlendShape = true;
        [CL4EELocalized("TraceAndOptimize:prop:removeUnusedObjects")]
        [ToggleLeft]
        public bool removeUnusedObjects = true;
        [CL4EELocalized("TraceAndOptimize:prop:mmdWorldCompatibility",
            "TraceAndOptimize:tooltip:mmdWorldCompatibility")]
        [ToggleLeft]
        public bool mmdWorldCompatibility = true;
    }
}