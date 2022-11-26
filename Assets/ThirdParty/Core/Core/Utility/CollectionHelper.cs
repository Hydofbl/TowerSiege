using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.Utility
{
    public static class CollectionHelper
    {
        private static readonly Random Random = new Random();
        
        public static T GetRandomItem<T>(this IEnumerable<T> @this, Predicate<T> predicate = null)
        {
            if (@this == null)
            {
                throw new ArgumentNullException(nameof(@this));
            }
            
            bool useFilter = predicate != null;
            IEnumerable<T> collection = @this as T[] ?? @this.ToArray();
            IEnumerable<T> desiredItemsInCollection = useFilter
                ? collection.Where(predicate.Invoke)
                : collection;

 
            int selectedIndex = Random.Next(0, desiredItemsInCollection.Count());
            return collection.ElementAt(selectedIndex);
        }

        public static void ForEach<T>(this IEnumerable<T> @this, Action<T> action)
        {
            if (@this == null)
            {
                throw new ArgumentNullException(nameof(@this));
            }

            foreach (T t in @this)
            {
                action?.Invoke(t);
            }
        }
    }
}