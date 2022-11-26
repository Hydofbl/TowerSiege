using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace  Core.UnityObjectRepository.Utility
{
    public static class UnityObjectHelper
     {
         public static IEnumerable<T> GetAllInstancesFromResources<T>(string path) where T : Object =>
             Resources.LoadAll(path, typeof(T)).Cast<T>();
     }
 }