using System;
using JetBrains.Annotations;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Core.Utility
{
    public static class TransformHelper
    {
        public static void DestroyChildren([NotNull] this Transform @this)
        {
            if (@this == null)
            {
                throw new ArgumentNullException(nameof(@this));
            }
            
            for (int index = 0; index < @this.childCount; index++)
            {
                Object.Destroy(@this.GetChild(index).gameObject);
            }
        }
    }
}
