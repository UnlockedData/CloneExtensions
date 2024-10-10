using System;
using System.Collections.Generic;

namespace UnlockedData.CloneExtensions
{
    public static class CloneFactory
    {
        private const CloningFlags _defaultFlags
            = CloningFlags.Fields | CloningFlags.Properties | CloningFlags.CollectionItems;

        private static HashSet<Type> _knownImmutableTypes = new HashSet<Type>() {
            typeof(string), typeof(DateTime), typeof(TimeSpan)
        };

        public static CloningFlags DefaultFlags
        {
            get => _defaultFlags;
        }

        public static IEnumerable<Type> KnownImmutableTypes
        {
            get => _knownImmutableTypes;
        }

        public static IDictionary<Type, Func<object, object>> CustomInitializers { get; } = new Dictionary<Type, Func<object, object>>();

        public static T GetClone<T>(this T source, CloningFlags flags = _defaultFlags)
        {
            return GetClone(source, flags, CustomInitializers);
        }

        public static T GetClone<T>(this T source, IDictionary<Type, Func<object, object>> initializers)
        {
            return GetClone(source, _defaultFlags, initializers);
        }

        public static T GetClone<T>(this T source, CloningFlags flags, IDictionary<Type, Func<object, object>> initializers)
        {
            if (initializers == null)
                throw new ArgumentNullException();

            return GetClone(source, flags, initializers, new Dictionary<object, object>());
        }

        internal static T GetClone<T>(this T source, CloningFlags flags, IDictionary<Type, Func<object, object>> initializers, Dictionary<object, object> clonedObjects)
        {
            return CloneManager<T>.Clone(source, flags, initializers, clonedObjects);
        }
    }
}
