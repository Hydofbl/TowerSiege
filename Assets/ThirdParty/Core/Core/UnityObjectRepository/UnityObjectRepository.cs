using System;
using System.Collections.Generic;
using System.Linq;
using Core.UnityObjectRepository.Utility;

namespace Core.UnityObjectRepository
{
    public class UnityObjectRepository<T> where T : UnityEngine.Object
    {
        private List<T> _items;

        public IReadOnlyCollection<T> Items
        {
            get
            {
                InitializeRepository();
                return _items;
            }
        }

        private bool IsInitialized => _items != null;

        private readonly string _resourcesPath;

        public UnityObjectRepository(string resourcesPath) => _resourcesPath =
            resourcesPath ?? throw new ArgumentNullException(nameof(resourcesPath));

        private void InitializeRepository()
        {
            if (IsInitialized)
            {
                return;
            }

            _items = UnityObjectHelper.GetAllInstancesFromResources<T>(_resourcesPath).ToList();
        }
    }
}